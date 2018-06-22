using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ServiceModel;
using PKI.eBusiness.WMService;
using PKI.eBusiness.WMService.Entities.Orders;
using PKI.eBusiness.WMService.Entities.Errors;
using PKI.eBusiness.WMService.Utility;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TestWebMethodService();
    }

    private void TestWebMethodService()
    {
        WMServiceClient client = new WMServiceClient();

        Order mainOrder = TestUtilities.GetMockOrder();
        
        client.ClientCredentials.UserName.UserName = "PEIStorefront";
        client.ClientCredentials.UserName.Password = "!pei?sf";

        // Use the 'client' variable to call operations on the service.
        try
        {
            string result = client.ProcessOrderSubmission(mainOrder);
            Response.Write("Result: " + result);
        }            
        catch (FaultException<CustomError> ex) // Each exception coming from WebMethodService
        {
            Response.Write("Fault Exception has been raised: " + ex.Detail.ErrorMessage);
        }        

        // Always close the client.
        client.Close();
    }
}