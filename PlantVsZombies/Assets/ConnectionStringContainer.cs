using DatabaseDomain;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionStringContainer : MonoBehaviour
{
    [SerializeField] private ConnectionString _connectionStringObject;

    private string _connectionString;


    public string ConnectionString
    {
        get
        {
            if (_connectionString == null)
            {
                string dataSource = _connectionStringObject.DataSource;
                string dataCatalog = _connectionStringObject.DatabaseCatalog;


                _connectionString = ConnectionStringFactory.CreateConnectionStringToDatabase(dataSource, dataCatalog);
            }

            return _connectionString;
        }
    }
}
