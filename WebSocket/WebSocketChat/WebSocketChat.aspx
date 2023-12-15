<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebSocketChat.aspx.cs" Inherits="WebSocketChat.WebSocketChat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <div class="body-content">

        <div class="jumbotron">
            <h2>Probando websocket para un chat</h2>
            <p class="lead">Abrir dos navegadores y probar.</p>
        </div>

        <div class="container">

            <div class="col  p-3 mb-3">
                <div class="form-group text-center p-3 mb-3" style="background-color: #d6e1ed;">
                    <label for="tbRecibidos">Mensajes recibidos:</label>
                    <asp:TextBox ID="tbRecibidos" CssClass="form-control" Style="width: 100%; max-width: none; text-align: left;" placeholder="Mensajes a recibir." TextMode="MultiLine" Rows="10" Enabled="false" runat="server" />
                </div>

                <div class="form-group  text-center p-3 mb-3" style="background-color: #d6e1ed;">
                    <label class="col-form-label" for="tbEnviados">Mensajes enviados:</label>
                    <asp:TextBox ID="tbEnviados" CssClass="form-control" Style="width: 100%; max-width: none; text-align: left;" TextMode="MultiLine" Rows="10" placeholder="Ingrese el mensaje a enviar." runat="server" />
                </div>

                <div class="text-center">
                    <button class="btn btn-primary" id="btnEnviar"><i class="fa fa-send"></i>Enviar</button>
                </div>
            </div>
        </div>

    </div>
    <script>
        var socket;
        var btnEnviar = document.getElementById('btnEnviar');


        function iniciarWebSocket() {
            // var port = 8082;// window.location.port; // Obtiene el puerto actual del proyecto
            // var host = "localhost";//window.location.hostname; // Obtiene el host actual del proyecto
            // var url = `ws://${host}:${port}/mywebsocket`; // Crea la URL WebSocket
            socket = new WebSocket("ws://localhost:8082/mywebsocket");

            socket.onopen = function (event) {
                console.log("WebSocket connection opened.");
            };

            socket.onmessage = function (event) {
                var mensajeRecibido = event.data;
                console.log("Received message: " + mensajeRecibido);

                document.getElementById('<%= tbRecibidos.ClientID %>').value += mensajeRecibido + "\r\n";
            };

            socket.onclose = function (event) {
                console.log("WebSocket connection closed.");
            };


            btnEnviar.addEventListener('click', function (event) {

                // Evitar que el botón realice su acción predeterminada (enviar formulario)
                //no pasa con el elemento input
                event.preventDefault();

                var mensajeAEnviar = document.getElementById('<%= tbEnviados.ClientID %>').value;
                console.log(mensajeAEnviar);
                socket.send(mensajeAEnviar);

                document.getElementById('<%= tbEnviados.ClientID %>').value = "";
            });

        }
        window.onload = iniciarWebSocket;

    </script>

</asp:Content>
