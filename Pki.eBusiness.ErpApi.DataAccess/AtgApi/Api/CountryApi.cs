/* 
 * ATG Store
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
using RestSharp;
using Pki.eBusiness.ErpApi.DataAccess.Client;
using Pki.eBusiness.ErpApi.DataAccess.Model;

namespace Pki.eBusiness.ErpApi.DataAccess.AtgApi
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ICountryApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Retrieve the contactUs info with Country name.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Pki.eBusiness.ErpApi.DataAccess.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="countryName"></param>
        /// <returns>ContactUsDto</returns>
        ContactUsDto GetContactDetails (string countryName);

        /// <summary>
        /// Retrieve the contactUs info with Country name.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Pki.eBusiness.ErpApi.DataAccess.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="countryName"></param>
        /// <returns>ApiResponse of ContactUsDto</returns>
        ApiResponse<ContactUsDto> GetContactDetailsWithHttpInfo (string countryName);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Pki.eBusiness.ErpApi.DataAccess.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>CountriesList</returns>
        CountriesList GetCountries ();

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Pki.eBusiness.ErpApi.DataAccess.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of CountriesList</returns>
        ApiResponse<CountriesList> GetCountriesWithHttpInfo ();
        /// <summary>
        /// Retrieve all the country names.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Pki.eBusiness.ErpApi.DataAccess.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>DisplayContentDtoList</returns>
        DisplayContentDtoList GetCuntryNames ();

        /// <summary>
        /// Retrieve all the country names.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Pki.eBusiness.ErpApi.DataAccess.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of DisplayContentDtoList</returns>
        ApiResponse<DisplayContentDtoList> GetCuntryNamesWithHttpInfo ();
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Retrieve the contactUs info with Country name.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Pki.eBusiness.ErpApi.DataAccess.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="countryName"></param>
        /// <returns>Task of ContactUsDto</returns>
        System.Threading.Tasks.Task<ContactUsDto> GetContactDetailsAsync (string countryName);

        /// <summary>
        /// Retrieve the contactUs info with Country name.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Pki.eBusiness.ErpApi.DataAccess.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="countryName"></param>
        /// <returns>Task of ApiResponse (ContactUsDto)</returns>
        System.Threading.Tasks.Task<ApiResponse<ContactUsDto>> GetContactDetailsAsyncWithHttpInfo (string countryName);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Pki.eBusiness.ErpApi.DataAccess.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of CountriesList</returns>
        System.Threading.Tasks.Task<CountriesList> GetCountriesAsync ();

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Pki.eBusiness.ErpApi.DataAccess.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (CountriesList)</returns>
        System.Threading.Tasks.Task<ApiResponse<CountriesList>> GetCountriesAsyncWithHttpInfo ();
        /// <summary>
        /// Retrieve all the country names.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Pki.eBusiness.ErpApi.DataAccess.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of DisplayContentDtoList</returns>
        System.Threading.Tasks.Task<DisplayContentDtoList> GetCuntryNamesAsync ();

        /// <summary>
        /// Retrieve all the country names.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Pki.eBusiness.ErpApi.DataAccess.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (DisplayContentDtoList)</returns>
        System.Threading.Tasks.Task<ApiResponse<DisplayContentDtoList>> GetCuntryNamesAsyncWithHttpInfo ();
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class CountryApi : ICountryApi
    {
        private Pki.eBusiness.ErpApi.DataAccess.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryApi"/> class.
        /// </summary>
        /// <returns></returns>
        public CountryApi(String basePath)
        {
            this.Configuration = new Configuration { BasePath = basePath };

            ExceptionFactory = Pki.eBusiness.ErpApi.DataAccess.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public CountryApi(Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = Pki.eBusiness.ErpApi.DataAccess.Client.Configuration.DefaultExceptionFactory;
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
        public Pki.eBusiness.ErpApi.DataAccess.Client.ExceptionFactory ExceptionFactory
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
        /// Retrieve the contactUs info with Country name. 
        /// </summary>
        /// <exception cref="Pki.eBusiness.ErpApi.DataAccess.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="countryName"></param>
        /// <returns>ContactUsDto</returns>
        public ContactUsDto GetContactDetails (string countryName)
        {
             ApiResponse<ContactUsDto> localVarResponse = GetContactDetailsWithHttpInfo(countryName);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve the contactUs info with Country name. 
        /// </summary>
        /// <exception cref="Pki.eBusiness.ErpApi.DataAccess.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="countryName"></param>
        /// <returns>ApiResponse of ContactUsDto</returns>
        public ApiResponse< ContactUsDto > GetContactDetailsWithHttpInfo (string countryName)
        {
            // verify the required parameter 'countryName' is set
            if (countryName == null)
                throw new ApiException(400, "Missing required parameter 'countryName' when calling CountryApi->GetContactDetails");

            var localVarPath = "/country/contact/{countryName}";
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

            if (countryName != null) localVarPathParams.Add("countryName", Configuration.ApiClient.ParameterToString(countryName)); // path parameter

            // authentication (apiKey) required
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("x-api-key")))
            {
                localVarHeaderParams["x-api-key"] = Configuration.GetApiKeyWithPrefix("x-api-key");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetContactDetails", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ContactUsDto>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ContactUsDto) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ContactUsDto)));
        }

        /// <summary>
        /// Retrieve the contactUs info with Country name. 
        /// </summary>
        /// <exception cref="Pki.eBusiness.ErpApi.DataAccess.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="countryName"></param>
        /// <returns>Task of ContactUsDto</returns>
        public async System.Threading.Tasks.Task<ContactUsDto> GetContactDetailsAsync (string countryName)
        {
             ApiResponse<ContactUsDto> localVarResponse = await GetContactDetailsAsyncWithHttpInfo(countryName);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Retrieve the contactUs info with Country name. 
        /// </summary>
        /// <exception cref="Pki.eBusiness.ErpApi.DataAccess.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="countryName"></param>
        /// <returns>Task of ApiResponse (ContactUsDto)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<ContactUsDto>> GetContactDetailsAsyncWithHttpInfo (string countryName)
        {
            // verify the required parameter 'countryName' is set
            if (countryName == null)
                throw new ApiException(400, "Missing required parameter 'countryName' when calling CountryApi->GetContactDetails");

            var localVarPath = "/country/contact/{countryName}";
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

            if (countryName != null) localVarPathParams.Add("countryName", Configuration.ApiClient.ParameterToString(countryName)); // path parameter

            // authentication (apiKey) required
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("x-api-key")))
            {
                localVarHeaderParams["x-api-key"] = Configuration.GetApiKeyWithPrefix("x-api-key");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetContactDetails", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ContactUsDto>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ContactUsDto) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ContactUsDto)));
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="Pki.eBusiness.ErpApi.DataAccess.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>CountriesList</returns>
        public CountriesList GetCountries ()
        {
             ApiResponse<CountriesList> localVarResponse = GetCountriesWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="Pki.eBusiness.ErpApi.DataAccess.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of CountriesList</returns>
        public ApiResponse< CountriesList > GetCountriesWithHttpInfo ()
        {

            var localVarPath = "/country/countries";
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


            // authentication (apiKey) required
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("x-api-key")))
            {
                localVarHeaderParams["x-api-key"] = Configuration.GetApiKeyWithPrefix("x-api-key");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetCountries", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CountriesList>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CountriesList) Configuration.ApiClient.Deserialize(localVarResponse, typeof(CountriesList)));
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="Pki.eBusiness.ErpApi.DataAccess.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of CountriesList</returns>
        public async System.Threading.Tasks.Task<CountriesList> GetCountriesAsync ()
        {
             ApiResponse<CountriesList> localVarResponse = await GetCountriesAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="Pki.eBusiness.ErpApi.DataAccess.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (CountriesList)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<CountriesList>> GetCountriesAsyncWithHttpInfo ()
        {

            var localVarPath = "/country/countries";
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


            // authentication (apiKey) required
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("x-api-key")))
            {
                localVarHeaderParams["x-api-key"] = Configuration.GetApiKeyWithPrefix("x-api-key");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetCountries", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CountriesList>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CountriesList) Configuration.ApiClient.Deserialize(localVarResponse, typeof(CountriesList)));
        }

        /// <summary>
        /// Retrieve all the country names. 
        /// </summary>
        /// <exception cref="Pki.eBusiness.ErpApi.DataAccess.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>DisplayContentDtoList</returns>
        public DisplayContentDtoList GetCuntryNames ()
        {
             ApiResponse<DisplayContentDtoList> localVarResponse = GetCuntryNamesWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve all the country names. 
        /// </summary>
        /// <exception cref="Pki.eBusiness.ErpApi.DataAccess.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of DisplayContentDtoList</returns>
        public ApiResponse< DisplayContentDtoList > GetCuntryNamesWithHttpInfo ()
        {

            var localVarPath = "/country/countryNames";
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


            // authentication (apiKey) required
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("x-api-key")))
            {
                localVarHeaderParams["x-api-key"] = Configuration.GetApiKeyWithPrefix("x-api-key");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetCuntryNames", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<DisplayContentDtoList>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DisplayContentDtoList) Configuration.ApiClient.Deserialize(localVarResponse, typeof(DisplayContentDtoList)));
        }

        /// <summary>
        /// Retrieve all the country names. 
        /// </summary>
        /// <exception cref="Pki.eBusiness.ErpApi.DataAccess.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of DisplayContentDtoList</returns>
        public async System.Threading.Tasks.Task<DisplayContentDtoList> GetCuntryNamesAsync ()
        {
             ApiResponse<DisplayContentDtoList> localVarResponse = await GetCuntryNamesAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        /// Retrieve all the country names. 
        /// </summary>
        /// <exception cref="Pki.eBusiness.ErpApi.DataAccess.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (DisplayContentDtoList)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<DisplayContentDtoList>> GetCuntryNamesAsyncWithHttpInfo ()
        {

            var localVarPath = "/country/countryNames";
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


            // authentication (apiKey) required
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("x-api-key")))
            {
                localVarHeaderParams["x-api-key"] = Configuration.GetApiKeyWithPrefix("x-api-key");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetCuntryNames", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<DisplayContentDtoList>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DisplayContentDtoList) Configuration.ApiClient.Deserialize(localVarResponse, typeof(DisplayContentDtoList)));
        }

    }
}
