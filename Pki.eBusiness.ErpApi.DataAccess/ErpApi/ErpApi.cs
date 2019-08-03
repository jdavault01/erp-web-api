/* 
 * eCommerce
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Pki.eBusiness.ErpApi.DataAccess.ErpApi.Model;
using RestSharp;

namespace Pki.eBusiness.ErpApi.DataAccess.ErpApi
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IErpApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// PartnerLookupProcess
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="partnerLookupRequest"></param>
        /// <returns>PartnerLookupResponseRoot</returns>
        PartnerLookupResponseRoot PartnerLookupPost (PartnerLookupRequestRoot partnerLookupRequest);

        /// <summary>
        /// PartnerLookupProcess
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="partnerLookupRequest"></param>
        /// <returns>ApiResponse of PartnerLookupResponseRoot</returns>
        ApiResponse<PartnerLookupResponseRoot> PartnerLookupPostWithHttpInfo (PartnerLookupRequestRoot partnerLookupRequest);
        /// <summary>
        /// SimulateOrderProcess
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="simulateOrderRequest2"></param>
        /// <returns>SimulateOrderResponseRoot</returns>
        SimulateOrderResponseRoot SimulateOrderPost (SimulateOrderRequestRoot simulateOrderRequest2);

        /// <summary>
        /// SimulateOrderProcess
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="simulateOrderRequest2"></param>
        /// <returns>ApiResponse of SimulateOrderResponseRoot</returns>
        ApiResponse<SimulateOrderResponseRoot> SimulateOrderPostWithHttpInfo (SimulateOrderRequestRoot simulateOrderRequest2);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// PartnerLookupProcess
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="partnerLookupRequest"></param>
        /// <returns>Task of PartnerLookupResponseRoot</returns>
        System.Threading.Tasks.Task<PartnerLookupResponseRoot> PartnerLookupPostAsync (PartnerLookupRequestRoot partnerLookupRequest);

        /// <summary>
        /// PartnerLookupProcess
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="partnerLookupRequest"></param>
        /// <returns>Task of ApiResponse (PartnerLookupResponseRoot)</returns>
        System.Threading.Tasks.Task<ApiResponse<PartnerLookupResponseRoot>> PartnerLookupPostAsyncWithHttpInfo (PartnerLookupRequestRoot partnerLookupRequest);
        /// <summary>
        /// SimulateOrderProcess
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="simulateOrderRequest2"></param>
        /// <returns>Task of SimulateOrderResponseRoot</returns>
        System.Threading.Tasks.Task<SimulateOrderResponseRoot> SimulateOrderPostAsync (SimulateOrderRequestRoot simulateOrderRequest2);

        /// <summary>
        /// SimulateOrderProcess
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="simulateOrderRequest2"></param>
        /// <returns>Task of ApiResponse (SimulateOrderResponseRoot)</returns>
        System.Threading.Tasks.Task<ApiResponse<SimulateOrderResponseRoot>> SimulateOrderPostAsyncWithHttpInfo (SimulateOrderRequestRoot simulateOrderRequest2);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ErpApi : IErpApi
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErpApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ErpApi(String basePath, String userName, string passWord)
        {
            this.Configuration = new Configuration { BasePath = basePath, Username = userName, Password = passWord};

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErpApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public ErpApi(Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Configuration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public IDictionary<String, String> DefaultHeader()
        {
            return new ReadOnlyDictionary<string, string>(this.Configuration.DefaultHeader);
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }

        /// <summary>
        /// PartnerLookupProcess 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="partnerLookupRequest"></param>
        /// <returns>PartnerLookupResponseRoot</returns>
        public PartnerLookupResponseRoot PartnerLookupPost (PartnerLookupRequestRoot partnerLookupRequest)
        {
             ApiResponse<PartnerLookupResponseRoot> localVarResponse = PartnerLookupPostWithHttpInfo(partnerLookupRequest);
             return localVarResponse.Data;
        }

        /// <summary>
        /// PartnerLookupProcess 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="partnerLookupRequest"></param>
        /// <returns>ApiResponse of PartnerLookupResponseRoot</returns>
        public ApiResponse< PartnerLookupResponseRoot > PartnerLookupPostWithHttpInfo (PartnerLookupRequestRoot partnerLookupRequest)
        {
            // verify the required parameter 'partnerLookupRequest' is set
            if (partnerLookupRequest == null)
                throw new ApiException(400, "Missing required parameter 'partnerLookupRequest' when calling ErpApi->PartnerLookupPost");

            var localVarPath = "/partnerLookup";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (partnerLookupRequest != null && partnerLookupRequest.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(partnerLookupRequest); // http body (model) parameter
            }
            else
            {
                localVarPostBody = partnerLookupRequest; // byte array
            }

            // authentication (basic) required
            // http basic authentication required
            if (!String.IsNullOrEmpty(Configuration.Username) || !String.IsNullOrEmpty(Configuration.Password))
            {
                localVarHeaderParams["Authorization"] = "Basic " + ApiClient.Base64Encode(Configuration.Username + ":" + Configuration.Password);
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PartnerLookupPost", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<PartnerLookupResponseRoot>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (PartnerLookupResponseRoot) Configuration.ApiClient.Deserialize(localVarResponse, typeof(PartnerLookupResponseRoot)));
        }

        /// <summary>
        /// PartnerLookupProcess 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="partnerLookupRequest"></param>
        /// <returns>Task of PartnerLookupResponseRoot</returns>
        public async System.Threading.Tasks.Task<PartnerLookupResponseRoot> PartnerLookupPostAsync (PartnerLookupRequestRoot partnerLookupRequest)
        {
             ApiResponse<PartnerLookupResponseRoot> localVarResponse = await PartnerLookupPostAsyncWithHttpInfo(partnerLookupRequest);
             return localVarResponse.Data;

        }

        /// <summary>
        /// PartnerLookupProcess 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="partnerLookupRequest"></param>
        /// <returns>Task of ApiResponse (PartnerLookupResponseRoot)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<PartnerLookupResponseRoot>> PartnerLookupPostAsyncWithHttpInfo (PartnerLookupRequestRoot partnerLookupRequest)
        {
            // verify the required parameter 'partnerLookupRequest' is set
            if (partnerLookupRequest == null)
                throw new ApiException(400, "Missing required parameter 'partnerLookupRequest' when calling ErpApi->PartnerLookupPost");

            var localVarPath = "/partnerLookup";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (partnerLookupRequest != null && partnerLookupRequest.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(partnerLookupRequest); // http body (model) parameter
            }
            else
            {
                localVarPostBody = partnerLookupRequest; // byte array
            }

            // authentication (basic) required
            // http basic authentication required
            if (!String.IsNullOrEmpty(Configuration.Username) || !String.IsNullOrEmpty(Configuration.Password))
            {
                localVarHeaderParams["Authorization"] = "Basic " + ApiClient.Base64Encode(Configuration.Username + ":" + Configuration.Password);
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PartnerLookupPost", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<PartnerLookupResponseRoot>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (PartnerLookupResponseRoot) Configuration.ApiClient.Deserialize(localVarResponse, typeof(PartnerLookupResponseRoot)));
        }

        /// <summary>
        /// SimulateOrderProcess 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="simulateOrderRequest2"></param>
        /// <returns>SimulateOrderResponseRoot</returns>
        public SimulateOrderResponseRoot SimulateOrderPost (SimulateOrderRequestRoot simulateOrderRequest2)
        {
             ApiResponse<SimulateOrderResponseRoot> localVarResponse = SimulateOrderPostWithHttpInfo(simulateOrderRequest2);
             return localVarResponse.Data;
        }

        /// <summary>
        /// SimulateOrderProcess 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="simulateOrderRequest2"></param>
        /// <returns>ApiResponse of SimulateOrderResponseRoot</returns>
        public ApiResponse< SimulateOrderResponseRoot > SimulateOrderPostWithHttpInfo (SimulateOrderRequestRoot simulateOrderRequest2)
        {
            // verify the required parameter 'simulateOrderRequest2' is set
            if (simulateOrderRequest2 == null)
                throw new ApiException(400, "Missing required parameter 'simulateOrderRequest2' when calling ErpApi->SimulateOrderPost");

            var localVarPath = "/simulateOrder";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (simulateOrderRequest2 != null && simulateOrderRequest2.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(simulateOrderRequest2); // http body (model) parameter
            }
            else
            {
                localVarPostBody = simulateOrderRequest2; // byte array
            }

            // authentication (basic) required
            // http basic authentication required
            if (!String.IsNullOrEmpty(Configuration.Username) || !String.IsNullOrEmpty(Configuration.Password))
            {
                localVarHeaderParams["Authorization"] = "Basic " + ApiClient.Base64Encode(Configuration.Username + ":" + Configuration.Password);
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SimulateOrderPost", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<SimulateOrderResponseRoot>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (SimulateOrderResponseRoot) Configuration.ApiClient.Deserialize(localVarResponse, typeof(SimulateOrderResponseRoot)));
        }

        /// <summary>
        /// SimulateOrderProcess 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="simulateOrderRequest2"></param>
        /// <returns>Task of SimulateOrderResponseRoot</returns>
        public async System.Threading.Tasks.Task<SimulateOrderResponseRoot> SimulateOrderPostAsync (SimulateOrderRequestRoot simulateOrderRequest2)
        {
             ApiResponse<SimulateOrderResponseRoot> localVarResponse = await SimulateOrderPostAsyncWithHttpInfo(simulateOrderRequest2);
             return localVarResponse.Data;

        }

        /// <summary>
        /// SimulateOrderProcess 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="simulateOrderRequest2"></param>
        /// <returns>Task of ApiResponse (SimulateOrderResponseRoot)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<SimulateOrderResponseRoot>> SimulateOrderPostAsyncWithHttpInfo (SimulateOrderRequestRoot simulateOrderRequest2)
        {
            // verify the required parameter 'simulateOrderRequest2' is set
            if (simulateOrderRequest2 == null)
                throw new ApiException(400, "Missing required parameter 'simulateOrderRequest2' when calling ErpApi->SimulateOrderPost");

            var localVarPath = "/simulateOrder";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (simulateOrderRequest2 != null && simulateOrderRequest2.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(simulateOrderRequest2); // http body (model) parameter
            }
            else
            {
                localVarPostBody = simulateOrderRequest2; // byte array
            }

            // authentication (basic) required
            // http basic authentication required
            if (!String.IsNullOrEmpty(Configuration.Username) || !String.IsNullOrEmpty(Configuration.Password))
            {
                localVarHeaderParams["Authorization"] = "Basic " + ApiClient.Base64Encode(Configuration.Username + ":" + Configuration.Password);
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SimulateOrderPost", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<SimulateOrderResponseRoot>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (SimulateOrderResponseRoot) Configuration.ApiClient.Deserialize(localVarResponse, typeof(SimulateOrderResponseRoot)));
        }

    }
}
