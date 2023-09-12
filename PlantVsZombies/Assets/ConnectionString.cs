using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewConnectionString", menuName = "ScriptableObject/ConnectionString", order = 1)]
public class ConnectionString : ScriptableObject
{
    [SerializeField] private string _dataSource;
    [SerializeField] private string _databaseCatalog;

    public string DataSource { get => _dataSource; }
    public string DatabaseCatalog { get => _databaseCatalog; }
}
