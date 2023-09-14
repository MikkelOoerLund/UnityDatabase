using DatabaseDomain;
using Domain.Network;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.PackageManager;
using UnityEngine;

public class TCPDatabaseClient : MonoBehaviour
{
    private Thread _thread;
    private TCPClient _client;
    private DatabaseRequestFactory _databaseRequestFactory;


    private void Awake()
    {
        _client = new TCPClient(12000);
        _databaseRequestFactory = new DatabaseRequestFactory();
    }

    private void Start()
    {
        _thread = new Thread(() =>
        {
            Debug.Log("Connecting...");
            //_client.WaitUntilConnected();
            Debug.Log("Connected");

            _client.SendRequest("Hello");
            Debug.Log(_client.RecieveResponse());

            //Area[] areas = GetEntities<Area>();


            //foreach (var item in areas)
            //{
            //    Console.WriteLine(item);
            //}


            //var areas = GetEntities<Area>();

            //foreach (var area in areas)
            //{
            //    Debug.Log(area);
            //}

        });

        _thread.Start();
        
    }

    private void OnApplicationQuit()
    {
        _thread.Abort();
    }


    public T GetEntityWithId<T>(int id)
    {
        var entityType = typeof(T);
        var queryTask = QueryTask.GetWithId;
        var request = _databaseRequestFactory.GetDatabaseRequest(entityType, queryTask);

        request.Data = id.ToString();

        _client.SendRequest(request);
        return _client.RecieveResponse<T>();
    }

    public T[] GetEntities<T>()
    {
        var entityType = typeof(T);
        var queryTask = QueryTask.GetAll;
        var request = _databaseRequestFactory.GetDatabaseRequest(entityType, queryTask);

        _client.SendRequest(request);
        return _client.RecieveResponse<T[]>();
    }



}
