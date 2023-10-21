using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.WebSockets;
using System.Threading;

namespace WebSocketClientWinForm
{
    public partial class Form1 : Form
    {
        private ClientWebSocket webSocket = new ClientWebSocket();

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var port = 8082;// HttpContext.Current.Request.Url.Port; // Obtiene el puerto actual del proyecto
            var host = "localhost";// HttpContext.Current.Request.Url.Host; // Obtiene el host actual del proyecto
            var url = new Uri($"ws://{host}:{port}/mywebsocket"); // Crea la URL WebSocket

            try
            {
                await webSocket.ConnectAsync(url, CancellationToken.None);
                MessageBox.Show("Conexión WebSocket exitosa.");

                // Comienza a recibir mensajes
                await ReceiveMessages();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar al WebSocket: " + ex.Message);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var mensajeAEnviar = textBox2.Text;
                var mensajeBytes = Encoding.UTF8.GetBytes(mensajeAEnviar);
                var buffer = new ArraySegment<byte>(mensajeBytes);

                await webSocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
                //MessageBox.Show("Mensaje enviado al servidor WebSocket.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar mensaje: " + ex.Message);
            }

        }

        private async Task ReceiveMessages()
        {
            var buffer = new byte[1024]; // Tamaño del búfer de recepción

            while (webSocket.State == WebSocketState.Open)
            {
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                if (result.MessageType == WebSocketMessageType.Text)
                {
                    // Procesa y muestra el mensaje recibido
                    var mensajeRecibido = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    MostrarMensajeEnTextBox(mensajeRecibido);
                }
            }
        }

        private void MostrarMensajeEnTextBox(string mensaje)
        {
            if (textBox1.InvokeRequired)
            {
                textBox1.Invoke(new Action<string>(MostrarMensajeEnTextBox), mensaje);
            }
            else
            {
                textBox1.AppendText(mensaje + Environment.NewLine);
            }
        }

    }
}
