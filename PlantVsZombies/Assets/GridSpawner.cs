using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _spawnPrefab;

    [Header("InBetweenSpace")]
    [SerializeField] [Range(1, 500)] private float _rowGap;
    [SerializeField] [Range(1, 500)] private float _collumGap;

    [Header("Size")]
    [SerializeField] [Range(1, 10)] private int _rowCount;
    [SerializeField] [Range(1, 10)] private int _collumCount;

    [Header("Offset")]
    [SerializeField] private Vector2 _spawnOffset;

    private GameObject[,] _grid;






    private void SpawnGameObjects()
    {
        _grid = new GameObject[_rowCount, _collumCount];

        float height = _rowGap * (_rowCount - 1);
        float halfHeight = height / 2;

        float width = _collumGap * (_collumCount - 1);
        float halfWidth = width / 2;

        float verticalSpawnPosition = Position.y + _spawnOffset.y + halfHeight;

        for (int rowIndex = 0; rowIndex < _rowCount; rowIndex++)
        {
            float horizontalSpawnPosition = Position.x + _spawnOffset.x - halfWidth;

            for (int collumIndex = 0; collumIndex < _collumCount; collumIndex++)
            {
                Vector2 spawnPosition = new Vector2(horizontalSpawnPosition, verticalSpawnPosition);

                GameObject instance = Instantiate(_spawnPrefab, transform);
                instance.transform.position = spawnPosition;

                horizontalSpawnPosition += _collumGap;

                _grid[rowIndex, collumIndex] = instance;
            }

            verticalSpawnPosition -= _rowGap;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        float height = _rowGap * (_rowCount - 1);
        float halfHeight = height / 2;

        float width = _collumGap * (_collumCount - 1);
        float halfWidth = width / 2;

        float verticalSpawnPosition = Position.y + _spawnOffset.y + halfHeight;

        for (int rowIndex = 0; rowIndex < _rowCount; rowIndex++)
        {
            float horizontalSpawnPosition = Position.x + _spawnOffset.x - halfWidth;

            for (int collumIndex = 0; collumIndex < _collumCount; collumIndex++)
            {
                Vector2 size = GetGameObjectSize();
                Gizmos.DrawWireCube(new Vector2(horizontalSpawnPosition, verticalSpawnPosition), size);
                horizontalSpawnPosition += _collumGap;
            }

            verticalSpawnPosition -= _rowGap;
        }
    }


    private Vector2 GetGameObjectSize()
    {
        if (_spawnPrefab == null) return Vector2.one;

        RectTransform rectTransform = _spawnPrefab.GetComponent<RectTransform>();

        if (rectTransform != null)
        {
            Rect rect = rectTransform.rect;
            Vector2 localScale = rectTransform.localScale;


            float width = rect.width;
            float height = rect.height;

            float horizontalScale = localScale.x;
            float verticalScale = localScale.y;

            return new Vector2(width * horizontalScale - width / 2, height * verticalScale -  height/2);
        }

        return _spawnPrefab.transform.localScale;
    }


    private Vector2 Position => (Vector2)transform.position;


    public GameObject[,] Grid
    {
        get
        {
            if (_grid == null)
            {
                SpawnGameObjects();
            }

            return _grid;
        }
    }
}
