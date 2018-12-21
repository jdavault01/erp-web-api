namespace Pki.eBusiness.ErpApi.Entities.Account
{
    public class SalesArea
    {
        //private string salesOrg;

        public SalesArea(string salesOrg)
        {
            this.SalesOrgId = salesOrg;
            DistChannelId = "01";
            DivisionId = "02";
        }

        public string SalesOrgId { get; set; }
        public string DistChannelId { get; set; }
        public string DivisionId { get; set; }

    }
}
