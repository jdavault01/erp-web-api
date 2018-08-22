namespace PKI.eBusiness.WMService.Entities
{
    public sealed class Constants
    {
        public static string PEDIATRIX_ENDPOINT_NAME = "PKIPediatrix_flows_ProcessPediatrixOrder_WSD_Port";
        
        public static string ORDER_LOOKUP_ENDPOINT_NAME = "PELASOrderInfo_WebService_OrderInfo_WebService_Port";
        public static string STORE_FRONT_ENDPOINT_NAME = "services_StorefrontWebServices_Port";

        public const string LOG_FILE_DIRECTORY = "LogFileDirectory";
        public const string LOG_TO_FILE = "LogToFile";
        public const string LOG_SUBSCRIBERS = "LogSubscribers";
        public const string INSTANCE = "Instance";
        public const string TRUE = "true";
        public const string FALSE = "false";
        public const string TRACE_LEVEL = "TraceLevel";
        public const string LOG_AREA = "LSI_WEBSERVICE_ORDER_LOOKUP";
        public const string WEBAPI_STOREFRONT_LOG_AREA_PRODUCT = "WebApiProduct";
        public const string WEBAPI_STOREFRONT_LOG_AREA_ACCOUNT = "WebApiAccount";
        public const string WEBAPI_STOREFRONT_LOG_AREA_ = "WebApi";
        public const string LOG_AREA_STOREFRONT = "STOREFRONT";
        public const string SP_UPDATE_ORDER_STATUS = "sp_updateOrderStatus";
        public const string PENDING_ORDER_STATUS_KEY = "PendingOrderStatusCode";
        public const string LAB_NUMBER_PREPEND_VALUE = "LabNumberPrependValue";

        # region OrderLookup constants

        public  const  string ORDER_SUMMARY_REQUEST_ELEMENT="OrderSummaryRequest";
        public const string DTD_SUMMARY_REQUEST_SYSID = "OrderSummaryInput.dtd";

        public const string ORDER_DETAIL_REQUEST_ELEMENT = "OrderDetailRequest";
        public const string DTD_DETAIL_REQUEST_SYSID = "OrderDetailRequestInput.dtd";

        public const string LOGICAL_ID = "SF";

        public const string OrderLookUp_STUB_NAME = "OrderLookupStubName";

        public const string STOREFRONT_STUB_NAME = "StoreFrontStubName";
        public const string STOREFRONT_STUB_ADDRESS = "StoreFrontStubAddress";
        public const string GENETICS_STUB_NAME = "GeneticsStubName";
        public const string GENETICS_STUB_ENDPOINT = "GeneticsStubAddress";
        public const string SHOP_SVC_NAME = "ShopSVCName";
        public const string SHOP_SVC_ENDPOINT = "ShopSVCAddress";


        #endregion

    }
}
