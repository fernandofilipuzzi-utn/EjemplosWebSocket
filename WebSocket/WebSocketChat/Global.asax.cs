using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using WebSocketSharp.Server;
using WebSocket.Controllers;

namespace WebSocketChat
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            /*
           var wssv = new WebSocketServer("ws://localhost:8080");
           wssv.AddWebSocketService<MyWebSocketHandler>("/mywebsocket");
           wssv.Start();
           */
            /*
            var app = (HttpApplication)source;
            var uriObject = app.Context.Request.Url;
            //app.Context.Request.Url.OriginalString
            */
            // Code that runs on register routes
            int port = 8082;// HttpContext.Current.Request.Url.Port; // Obtiene el puerto actual del proyecto
            string host = "localhost";// HttpContext.Current.Request.Url.Host; // Obtiene el host actual del proyecto
            var wssv = new WebSocketServer($"ws://{host}:{port}");
            wssv.AddWebSocketService<MyWebSocketHandler>("/mywebsocket");
            wssv.Start();

           // string host2 = HttpContext.Current.Request.Url.Authority;
        }

        void Application_BeginRequest(Object source, EventArgs e)
        {
           
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs on application error
        }

        private void RegisterRoutes(RouteCollection routes)
        {
            
        }
    }
}