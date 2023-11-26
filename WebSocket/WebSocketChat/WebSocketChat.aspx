<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="WebSocketChat.aspx.cs" Inherits="WebSocketChat.WebSocketChat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2>Probando websocket para un chat</h2>
        Abrir dos navegadores y probar
    </div>

    <div class="container body-content text-center">

        <div class="form-group text-center">
            <label for="tbRecibidos">Mensajes recibidos:</label>
            <asp:TextBox ID="tbRecibidos" CssClass="form-control" Style="width: 100%; max-width: none; text-align: center;" placeholder="Mensajes a recibir."
                TextMode="MultiLine" Enabled="false" runat="server" />
        </div>

        <div class="form-group  text-center">
            <label for="tbEnviados">Mensajes enviados:</label>
            <asp:TextBox ID="tbEnviados" CssClass="form-control" Style="width: 100%; max-width: none; text-align: center;" TextMode="MultiLine" placeholder="Ingrese el mensaje a enviar."
                runat="server" /><br />
        </div>

        <div class="text-center">
            <button class="btn btn-primary" id="btnEnviar">Enviar</button>
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


            btnEnviar.addEventListener('click', function () {

                // Evitar que el botón realice su acción predeterminada (enviar formulario)
                //no pasa con el elemento input
                event.preventDefault();

                var mensajeAEnviar = document.getElementById('<%= tbEnviados.ClientID %>').value;
                console.log(mensajeAEnviar);
                socket.send(mensajeAEnviar);
            });

        }
        window.onload = iniciarWebSocket;

    </script>

</asp:Content>
