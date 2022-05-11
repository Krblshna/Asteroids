using System;
using System.Collections.Generic;
using System.Linq;
using Asteroids.Common;
using Asteroids.Enemies;
using Asteroids.Player;
using Asteroids.Statistics;
using Asteroids.UI;
using Asteroids.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Asteroids.GameManagement
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject _gameoverPanel;
        [SerializeField] private TextMeshProUGUI _textMesh;

        private List<Vector2> usedPoses = new List<Vector2>();
        private bool _restart;
        private int _maxRandTries = 30;
        public GameObject Player { get; private set; }
        private IGamePoints _gamePoints;

        private void Awake()
        {
            base.Awake();
            _gamePoints = GameLogic.GameLogic.GamePoints;
        }

        private void Start()
        {
            StartNewGame();
        }

        private void StartNewGame()
        {
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            Player = Instantiate(_playerPrefab, Vector3.zero, Quaternion.identity);
            var playerView = Player.GetComponent<PlayerView>();
            playerView.Init(Finish);
            usedPoses.Add(Player.transform.position);
        }

        public Vector2 GetPosFromPlayer()
        {
            var playerPos = Player.transform.position;
            bool intersect;
            Vector2 randPos;
            int counter = 0;
            do
            {
                randPos = ScreenData.GetRandPos();
                intersect = Vector2.Distance(playerPos, randPos) < 3f;
                counter++;
                if (counter > _maxRandTries) throw new Exception("can't find rand space");
            } while (intersect);

            return randPos;
        }

        private Vector2 GetRandPos()
        {
            bool intersect;
            Vector2 randPos;
            int counter = 0;
            do
            {
                randPos = ScreenData.GetRandPos();
                intersect = usedPoses.Any(usedPosition => Vector2.Distance(usedPosition, randPos) < 1f);
                counter++;
                if (counter > _maxRandTries) throw new Exception("can't find rand space");
            } while (intersect);

            return randPos;
        }

        private void RestartGame()
        {
            _restart = false;
            _gamePoints.Clear();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }

        public void Finish()
        {
            _gameoverPanel.SetActive(true);
            _textMesh.text = $"Your Points: {_gamePoints.Amount}";
            Utils.Instance.setTimeOut(RestartGame, 3f);
        }
    }
}