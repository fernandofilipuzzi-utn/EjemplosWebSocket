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
        protected override void OnOpen()
        {
            // Evento cuando un cliente WebSocket se conecta.
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            // Evento cuando se recibe un mensaje del cliente WebSocket.
            if (e.IsText)
            {
                var msg = e.Data;
                Send("Server received: " + msg);
            }
        }

        protected override void OnClose(CloseEventArgs e)
        {
            // Evento cuando un cliente WebSocket se desconecta.
        }
    }

}