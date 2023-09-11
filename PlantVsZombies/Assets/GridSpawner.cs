using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _spawnPrefab;

    [Header("Settings")]
    [SerializeField] private float _rowGap;
    [SerializeField] private float _collumGap;

    [SerializeField] private int _rowCount = 1;
    [SerializeField] private int _collumCount = 1;

    [SerializeField] private int _spawnCount;

    [SerializeField] private Vector2 _spawnOffset;


    private void Awake()
    {
        SpawnGameObjects();
    }

    private void SpawnGameObjects()
    {
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



        //Gizmos.DrawWireSphere((Vector2)transform.position + _spawnOffset, _radius);
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
}
