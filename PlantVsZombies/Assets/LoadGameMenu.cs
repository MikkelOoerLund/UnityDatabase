using DatabaseDomain.Players;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Build;
using UnityEngine;

public class LoadGameMenu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GridSpawner _gridSpawner;
    [SerializeField] private PlayerProfileCollection _playerProfileCollection;

    private PlayerProfile[] _playerProfiles;
    private LoadGameButton[] _loadGameButtons;

    private void Start()
    {
        InstantiateLoadGameButtons();
        //LoadPlayerProfiles();
    }

    private void InstantiateLoadGameButtons()
    {
        GameObject[,] grid = _gridSpawner.Grid;

        int rowCount = grid.GetLength(0);

        _loadGameButtons = new LoadGameButton[rowCount];

        for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
        {
            GameObject loadGameButton = grid[rowIndex, 0];
            _loadGameButtons[rowIndex] = loadGameButton.GetComponent<LoadGameButton>();
        }
    }


    private void LoadPlayerProfiles()
    {
        _playerProfiles = _playerProfileCollection.GetPlayers();

        int loadGameButtonsLength = _loadGameButtons.Length;
        int playerProfilesLength = _playerProfiles.Length;

        int difference = loadGameButtonsLength - playerProfilesLength;

        if (difference == 0) return;
        if (difference < 0) return;

        Debug.Break();

        _playerProfileCollection.CreatePlayerProfiles(difference);
    }

}
