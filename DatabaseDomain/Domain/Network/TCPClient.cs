using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Domain.Network
{
    public class TCPClient
    {
        private int _port;
        private TcpClient _client;
        private IPAddress _ipAddress;


        public TCPClient(int port)
        {
            _port = port;
            _client = new TcpClient();
            _ipAddress = IPAddress.Loopback;
        }

        public TCPClient(string ipAddress, int port)
        {
            _port = port;
            _ipAddress = IPAddress.Parse(ipAddress);
            _client = new TcpClient();
        }

        public void WaitUntilConnected()
        {
            try
            {
                _client = new TcpClient();
                _client.Connect(_ipAddress, _port);
            }
            catch (SocketException)
            {
                WaitUntilConnected();
            }
        }

        public void Connect()
        {
            try
            {
                _client = new TcpClient();
                _client.Connect(_ipAddress, _port);
            }
            catch (SocketException)
            {
                throw new SocketException();
            }
        }

        private string RecieveResponse()
        {
            StreamReader streamReader = new StreamReader(_client.GetStream());
            string response = streamReader.ReadLine();
            if (response == null) throw new Exception();
            return response;
        }

        public T RecieveResponse<T>()
        {
            string response = RecieveResponse();

            T responseObject = JsonConvert.DeserializeObject<T>(response);
            if (responseObject == null)
            {
                throw new Exception($"Cannot convert {response} to type {typeof(T)}");
            }
            return responseObject;
        }

        public void SendRequest(object request)
        {
            if (IsConnected == false) Connect();
            string requestJson = JsonConvert.SerializeObject(request);
            if (requestJson == null) throw new Exception();


            StreamWriter streamWriter = new StreamWriter(_client.GetStream());
            streamWriter.WriteLine(requestJson);
            streamWriter.Flush();
        }


        public bool IsConnected => _client.Connected;

    }
}
