using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebSocket.Controllers;
using WebSocketSharp.Server;

namespace WebSocketChat
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var wssv = new WebSocketServer("ws://localhost:8080");
            wssv.AddWebSocketService<MyWebSocketHandler>("/mywebsocket");
            wssv.Start();

           

        }
    }
}
