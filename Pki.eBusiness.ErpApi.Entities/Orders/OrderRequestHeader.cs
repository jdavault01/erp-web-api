namespace Pki.eBusiness.ErpApi.Entities.Orders
{    
    
    public class OrderRequestHeader : EntityBase
    {
        #region Properties

        
        public string RequestDate { get; set; }
        
        public string RequestTime { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Address { get; set; }
        
        public string AptSuite { get; set; }
        
        public string City { get; set; }
        
        public string State { get; set; }
        
        public string Zip { get; set; }
        
        public string Telephone { get; set; }
        
        public string Email { get; set; }
        
        public string NumOfChildren { get; set; }
        
        public string Questions { get; set; }
        
        public string HeardAboutUs { get; set; }
        
        public string RequestType { get; set; }
        
        public string OrderID { get; set; }

        
        public string AreYouAViacordCustomer { get; set; }

        #endregion
            
    }
}
