using DatabaseDomain;
using DatabaseDomain.Players;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerProfileCollection : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ConnectionStringContainer _connectionStringContainer;

    private PlayerProfileRepository _playerProfileRepository;


    private void Start()
    {
        InitializeRepository();

    }

    private void InitializeRepository()
    {
    }


    public PlayerProfile[] GetPlayers()
    {


        PlayerProfile[] playerProfiles = null;
        
        using (_playerProfileRepository)
        {
            playerProfiles = _playerProfileRepository.GetAll().ToArray();
        }

        return playerProfiles;
    }

    public void CreatePlayerProfiles(int amount)
    {
        using (_playerProfileRepository)
        {
            PlayerProfile[] playerProfiles = new PlayerProfile[amount];

            for (int index = 0; index < amount; index++)
            {
                playerProfiles[index] = new PlayerProfile();
            }

            _playerProfileRepository.AddRange(playerProfiles);
        }
    }

    public void CreatePlayerProfile()
    {
        using (_playerProfileRepository)
        {
            PlayerProfile playerProfile = new PlayerProfile();
            _playerProfileRepository.Add(playerProfile);
        }
    }

}
