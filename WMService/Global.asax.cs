using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Microsoft.Practices.Unity;
using PKI.eBusiness.WMService.ServiceGatewContracts.WMService;
using AutoMapper;

namespace WMService
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            // Initialize Order To Pediatrix Mapper which is used for OrderService objects
            Mapper.CreateMap<PKI.eBusiness.WMService.Entities.Orders.OrderRequestHeader, OrderRequestHeader>()
                .ForMember(dest => dest.areYouAViacordCustomer, opts => opts.MapFrom(src => src.AreYouAViacordCustomer));
            Mapper.CreateMap<PKI.eBusiness.WMService.Entities.Orders.OrderRequestDetail, OrderRequestDetail>();

            Mapper.CreateMap<PKI.eBusiness.WMService.Entities.Orders.Patient, Patients>();

            Mapper.CreateMap<PKI.eBusiness.WMService.Entities.Orders.OrderRequest,OrderRequest>();
            Mapper.CreateMap<PKI.eBusiness.WMService.Entities.Orders.Order, Pediatrix>();

          
        }
        
        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}