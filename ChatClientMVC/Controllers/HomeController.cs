using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChatClientMVC.ChatServiceClient;

namespace ChatClientMVC.Controllers
{
    public class HomeController : Controller
    {
        Service1Client client;
        bool isConnected = false;
        int Id;

        public ActionResult Index()
        {
            client = new Service1Client(new System.ServiceModel.InstanceContext(this));
            
            return View();
        }

        //void ConnectUser()
        //{
        //    if (!isConnected)
        //    {
        //        client = new Service1Client(new System.ServiceModel.InstanceContext(this));
        //        Id = client.Connect(tbUserName.Text);
        //        using (var context = new ChatContext())
        //        {
        //            context.Users.Add(new ChatModel.User
        //            {
        //                Name = tbUserName.Text,
        //            });
        //        }

        //        tbUserName.IsEnabled = false;
        //        bConnDiscon.Content = "Disconnect";
        //        isConnected = true;
        //    }
        //}

        //void DisconnectUser()
        //{
        //    if (isConnected)
        //    {
        //        client.Disconnect(Id);
        //        client = null;
        //        tbUserName.IsEnabled = true;
        //        bConnDiscon.Content = "Connect";
        //        isConnected = false;
        //    }
        //}
    }
}