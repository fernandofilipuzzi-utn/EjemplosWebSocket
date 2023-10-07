using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace WebSocket.Controllers
{

    public class MyWebSocketHandler : WebSocketBehavior
    {
        private static List<MyWebSocketHandler> activeConnections = new List<MyWebSocketHandler>();

        protected override void OnOpen()
        {
            // Cuando un cliente WebSocket se conecta, lo agregamos a la lista de conexiones activas.
            activeConnections.Add(this);
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            if (e.IsText)
            {
                var msg = e.Data;

                // Iteramos sobre todas las conexiones activas y enviamos el mensaje a cada una.
                foreach (var connection in activeConnections)
                {
                    connection.Send(msg);
                }
            }
        }

        protected override void OnClose(CloseEventArgs e)
        {
            // Cuando un cliente WebSocket se desconecta, lo eliminamos de la lista de conexiones activas.
            activeConnections.Remove(this);
        }
    }

}