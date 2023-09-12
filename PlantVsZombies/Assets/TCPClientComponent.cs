using DatabaseDomain.Network;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TCPClientComponent : MonoBehaviour
{

    private Thread thread;

    private void Start()
    {
        TCPClient client = new TCPClient(12000);

        client.Connect();

        thread = new Thread(() =>
        {
            while (true)
            {
                client.SendRequest("Request");
                string repsonse = client.RecieveResponse<string>();

                Debug.Log(repsonse);

                Thread.Sleep(1000);
            }
        });

        thread.IsBackground = true;
        thread.Start();
          

    }


    void OnApplicationQuit()
    {

        thread.Abort();

    }


}
