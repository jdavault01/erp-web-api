
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PKI.eBusiness.WMSHttpApi.UIHelpers
{
    public sealed class Constants
    {
    }

    public sealed class ErrorMessages
    {
    }

    public sealed class InfoMessage
    {
        #region storefront constants

        public const string ERROR_MSG_INVALID_PRICE_REQUEST = "Invalid Price Request.";
        public const string ERROR_MSG_INVALID_PRICE_REQUEST_MODEL = "Invalid Model on Price Request.";
        public const string ERROR_MSG_UNABLE_TO_GET_PRICE_RESPONSE = "Unable to get Price for this response.";

        public const string ERROR_MSG_INVALID_INVENTORY_REQUEST = "Invalid Inventory Request.";
        public const string ERROR_MSG_INVALID_INVENTORY_REQUEST_MODEL = "Invalid Model on Inventory Request.";
        public const string ERROR_MSG_UNABLE_TO_GET_INVENTORY_RESPONSE = "Unable to get Inventory for this response.";

        public const string ERROR_MSG_INVALID_PARTNER_REQUEST = "Invalid Partner Request.";
        public const string ERROR_MSG_INVALID_PARTNER_REQUEST_MODEL = "Invalid Model on Partner Request.";
        public const string ERROR_MSG_UNABLE_TO_GET_PARTNER_RESPONSE = "Unable to get Partrner for this response.";

        public const string ERROR_MSG_INVALID_CREATE_ORDER_REQUEST = "Invalid Order Create Request.";
        public const string ERROR_MSG_INVALID_CREATE_ORDER_REQUEST_MODEL = "Invalid Model on Order Create Request.";
        public const string ERROR_MSG_UNABLE_TO_GET_CREATE_ORDER_RESPONSE = "Unable to get Order Create for this response";

        public const string ERROR_MSG_INVALID_GET_COMPANY_INFO_REQUEST = "Invalid Get Company Info Request.";
        public const string ERROR_MSG_INVALID_GET_COMPANY_INFO_REQUEST_MODEL = "Invalid Model for Company Info Request.";
        public const string ERROR_MSG_UNABLE_TO_GET_COMPANY_INFO_RESPONSE = "Unable to get Company Info response.";

        public const string ERROR_MSG_UNABLE_TO_GET_CREATE_CONTENT_RESPONSE = "Unable to get CreateContent response for this request.";
        public const string WEBAPI_STOREFRONT_LOG_AREA_ACCOUNT = "WebApiAccount";
        public const string WEBAPI_STOREFRONT_LOG_AREA_PRODUCT = "WebApiProduct";

        #endregion

    }
}
