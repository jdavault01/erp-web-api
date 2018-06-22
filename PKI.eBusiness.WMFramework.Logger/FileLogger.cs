using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using PKI.eBusiness.WMService.Logger;
using PKI.eBusiness.WMService.Utility;

namespace PKI.eBusiness.WMService.Logger
{
    /// <summary>
    /// Subscriber implementing save to file functionality for logging
    /// </summary>
    internal class FileLogger : ILogSubscriber
    {
        #region Private elements and consts

        private static FileLogger _instance;
        private const string FILE_HEADER = "Log Level\tThreadId\tLog Time\t\tLog Description";
        private const string DEFAULT_AREA = "COMMON";
        private const string APP = "WMService_";
        private const string FILE_NAME = "Log.txt";
        private const string NO_EXCEPTION = "{0}{0}No Exception object has been provided.{0}";
        private const string SOURCE = "Source: {0}";
        private const string FULL_NAME = "FullName: {0}";
        private const string STACK_TRACE = "StackTrace: {0} ";
        private const string EXCEPTIONS_AREA = "EXCEPTIONS";
        private const string FILENAME_BASE = "{0}{1}{2}_{3}{4}";
        private const string DATEFORMAT = "yyyyMMdd";
        private const string TRACE_FORMAT = "{0}{1}\t\t{2}\t{3}\t";
        private const string ERROR_HEADER = "Error Log Begins here:";
        private const string ERROR_MACHINENAME = "MachineName: {0}";
        private const string ERROR_TIMESTAMP = "TimeStamp: {0}";
        private const string ERROR_DOMAINNAME = "AppDomainName: {0}";
        private const string ERROR_THREAD = "ThreadIdentity: {0}";
        private const string ERROR_WINDOWSID = "WindowsIdentity: {0}";
        private const string ERROR_BROWSER = "Browser Type: {0}";
        private const string ERROR_TRACKNAME = "TrackName: {0}";
        
        private static string LogFileDirectory
        {
            get { return ConfigurationManager.AppSettings[Constants.LOG_FILE_DIRECTORY]; }
        }

        #endregion

        #region Public properties

        public string DefaultArea
        {
            get { return DEFAULT_AREA; }
        }

        public string ExceptionsArea
        {
            get { return EXCEPTIONS_AREA; }
        }

        public bool LogToFile
        {
            get { return ConfigurationManager.AppSettings[Constants.LOG_TO_FILE] == Constants.TRUE; }
        }

        public string TraceLevelConfValue
        {
            get { return ConfigurationManager.AppSettings[Constants.TRACE_LEVEL]; }
        }

        #endregion

        #region Constructors
        
        // Using lazy initialization to ensure only started when needed
        public static FileLogger Instance
        {
            get { return _instance ?? (_instance = new FileLogger()); }
        }
        
        private FileLogger() { }

        #endregion


        #region ILogSubscriber members

        /// <summary>
        /// Log exception to file
        /// </summary>
        /// <param name="exception">Exception to be recorded</param>
        /// <param name="userId">Id of the user connected to the exception</param>
        /// <param name="nestedExceptions">Connected nested exceptions</param>
        /// <returns>True if written successfully or false otherwise</returns>
        public bool Log(Exception exception, string userId, List<Exception> nestedExceptions)
        {
            try
            {
                string logFilePath = GetLogFilePath(EXCEPTIONS_AREA);
                if (!string.IsNullOrEmpty(LogFileDirectory) && !Directory.Exists(LogFileDirectory))
                    Directory.CreateDirectory(LogFileDirectory);

                // Create StringBuilder to maintain publishing information.
                StringBuilder strInfo = new StringBuilder();

                // Add title information for each exception
                strInfo.Append(ERROR_HEADER + Environment.NewLine);
                strInfo.AppendFormat(ERROR_MACHINENAME, Environment.MachineName + Environment.NewLine);
                strInfo.AppendFormat(ERROR_TIMESTAMP, DateTime.Now + Environment.NewLine);
                strInfo.AppendFormat(ERROR_DOMAINNAME, AppDomain.CurrentDomain.FriendlyName + Environment.NewLine);
                strInfo.AppendFormat(ERROR_THREAD, Thread.CurrentPrincipal.Identity.Name + Environment.NewLine);
                var windowsIdentity = WindowsIdentity.GetCurrent();
                if (windowsIdentity != null)
                    strInfo.AppendFormat(ERROR_WINDOWSID, windowsIdentity.Name + Environment.NewLine);

                // code added to identify the browser type and log it during exceptions

                if (HttpContext.Current != null)
                {
                    HttpRequest req = HttpContext.Current.Request;
                    strInfo.AppendFormat(ERROR_BROWSER, req.Browser.Browser + " " + req.Browser.Version + Environment.NewLine);
                }


                if (!string.IsNullOrEmpty(userId))
                {
                    userId = userId.Trim();
                    strInfo.AppendFormat(ERROR_TRACKNAME, userId + Environment.NewLine);
                }
                // Write the entry to the  log.   
                WriteToLog(strInfo.ToString(), logFilePath);

                LogException(exception,logFilePath);
                //Traverse through the nested exceptions and publish them
                foreach (Exception nestedException in nestedExceptions)
                {
                    LogException(nestedException,logFilePath);
                }
                return true;

            }
            catch (Exception)
            {
                return false;
                // do not handle this part as it is already in the logger object trying to track an exception
            }
        }

        /// <summary>
        /// Log trace message in file
        /// </summary>
        /// <param name="message">Message to be written</param>
        /// <param name="level">TraceLevel of message</param>
        /// <param name="area">Area file to write to</param>
        /// <returns>True if written successfully or false otherwise</returns>
        public bool Log(string message, TraceLevel level, string area)
        {
            try
            {
                // Return if web.config does not have LogToFile value set to "true"
                // or the level parameter is different than Error.
                if (!LogToFile || (Convert.ToInt16(TraceLevelConfValue) > 0 && level != TraceLevel.Error))
                    return false;

                string logFilePath = LogFileDirectory;

                // Get default area or trim the parameter
                area = string.IsNullOrEmpty(area) ? DEFAULT_AREA : area.Trim();

                // Create directory if doesn't exist
                if (!string.IsNullOrEmpty(LogFileDirectory) && !Directory.Exists(LogFileDirectory))
                    Directory.CreateDirectory(LogFileDirectory);

                // Get full log file path
                logFilePath = GetLogFilePath(area);

                // Use StringBuilder to append message
                StringBuilder strInfo = new StringBuilder();

                // Write header if new log file
                if (!File.Exists(logFilePath))
                    strInfo.Append(FILE_HEADER);
                strInfo.AppendFormat(TRACE_FORMAT, Environment.NewLine, level, Thread.CurrentThread.Name, DateTime.Now + "-" + DateTime.Now.Millisecond);
                strInfo.Append(message);

                WriteToLog(strInfo.ToString(), logFilePath);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion


        #region Public helper methods

        /// <summary>
        /// Get full path for the logged file
        /// </summary>
        /// <param name="area">The area for which the path will be returned</param>
        /// <returns>Full path to file(with file name)</returns>
        public string GetLogFilePath(string area = null)
        {
            return string.Format(FILENAME_BASE, LogFileDirectory, APP, area, DateTime.Today.Date.ToString(DATEFORMAT), FILE_NAME);
        }

        #endregion


        #region Private helper methods

        /// <summary>
        /// Writes to given log
        /// </summary>
        /// <param name="entry">Entry to write</param>
        /// <param name="logFilePath">Full path to file to write to</param>
        private static void WriteToLog(string entry, string logFilePath)
        {
            try
            {
                // File will be created if doesn't exist
                using (StreamWriter sw = File.AppendText(logFilePath))
                {
                    sw.Write(entry);
                    sw.Close();
                }
            }
            catch (Exception exception)
            {
                EventLog.WriteEntry("PKI.eBusiness.WMService.Logger.FileLogger", exception.Message, EventLogEntryType.Error);
            }
        }

        /// <summary>
        /// Private method for writing exceptions
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="logFilePath"></param>
        private static void LogException(Exception exception, string logFilePath)
        {

            // Create StringBuilder to maintain publishing information.
            StringBuilder strInfo = new StringBuilder();
            if (exception == null)
                strInfo.AppendFormat(NO_EXCEPTION, Environment.NewLine);
            else
            {
                // Append source information
                strInfo.AppendFormat(SOURCE, exception.Source + Environment.NewLine);
                strInfo.AppendFormat(FULL_NAME, exception.GetType().FullName + Environment.NewLine);

                // Record the StackTrace.
                if (exception.StackTrace != null)
                    strInfo.AppendFormat(STACK_TRACE, exception.StackTrace);
            }

            // Write the entry to the  log.   
            strInfo.Append(Environment.NewLine);
            strInfo.Append(Environment.NewLine);
            WriteToLog(strInfo.ToString(), logFilePath);
        }

        #endregion


    }
}
