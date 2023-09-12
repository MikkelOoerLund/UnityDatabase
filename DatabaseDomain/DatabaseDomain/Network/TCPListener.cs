using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DatabaseDomain.Network
{
    public class TCPListener
    {
        private TcpListener _listener;
        private RequestPublisher _publisher;

        public TCPListener(int port, RequestPublisher publisher = default)
        {
            _publisher = publisher;
            _listener = new TcpListener(IPAddress.Any, port);
        }

        private string GetResponse(string request)
        {
            if (_publisher != null)
            {
                object responseObject = _publisher.Publish(request);
                string responseJson = JsonConvert.SerializeObject(responseObject);


                return responseJson;
            }


            return request;
        }

        private void HandleClient(TcpClient client)
        {
            StreamWriter streamWriter = new StreamWriter(client.GetStream());
            StreamReader streamReader = new StreamReader(client.GetStream());

            streamWriter.Flush();

            try
            {
                while (client.Connected)
                {
                    string request = streamReader.ReadLine();

                    if (request == null) continue;

                    string response = GetResponse(request);

                    streamWriter.WriteLine(response);
                    streamWriter.Flush();
                }
            }
            catch (Exception)
            {
                client.Dispose();
                streamWriter.Dispose();
                streamReader.Dispose();
            }
        }



        public void Start()
        {
            _listener.Start();
        }

        public void Stop()
        {
            _listener.Stop();
        }

        public void AcceptClients()
        {
            while (true)
            {
                TcpClient client = _listener.AcceptTcpClient();
                Thread thread = new Thread(() => HandleClient(client));
                thread.IsBackground = true;
                thread.Start();
            }
        }

        public void AcceptClientsAsync()
        {
            Thread thread = new Thread(AcceptClients);
            thread.IsBackground = true;
            thread.Start();
        }


    }
}
