<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="WebSocketCliente.aspx.cs"
    Inherits="WebSocket.WebSocketCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script>
        var socket = new WebSocket("ws://localhost:8080/mywebsocket");

        socket.onopen = function (event) {
            console.log("WebSocket connection opened.");
            socket.send("Hello, WebSocket!");
        };

        socket.onmessage = function (event) {
            console.log("Received message: " + event.data);
        };

        socket.onclose = function (event) {
            console.log("WebSocket connection closed.");
        };
    </script>

      Revisar la consola del navegador.
</asp:Content>
