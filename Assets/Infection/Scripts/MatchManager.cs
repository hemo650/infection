﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Infection
{
    [DisallowMultipleComponent]
    public class MatchManager : MonoBehaviour
    {
        public static MatchManager singleton;

        private const string PLAYER_ID_PREFIX = "Player ";
        private static Dictionary<string, Player> players = new Dictionary<string, Player>();

        private void Awake()
        {
            if (singleton == null) singleton = this;
        }

        private void Start()
        {
            StartMatch();
        }

        private void StartMatch()
        {
            StartCoroutine(Think());
        }

        private IEnumerator Think()
        {
            yield return new WaitForSeconds(4f);
        }

        public static void RegisterPlayer(string _netID, Player _player)
        {
            string _playerID = PLAYER_ID_PREFIX + _netID;
            players.Add(_playerID, _player);
            _player.transform.name = _playerID;

            Debug.Log("Registered player: " + _netID);
        }

        public static void UnRegisterPlayer(string _playerID)
        {
            players.Remove(_playerID);

            Debug.Log("Unregistered player: " + _playerID);
        }

        public static Player GetPlayer(string _playerID)
        {
            return players[_playerID];
        }

        public static Player[] GetAllPlayers()
        {
            return players.Values.ToArray();
        }
    }
}