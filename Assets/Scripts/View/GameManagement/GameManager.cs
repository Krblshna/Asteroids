using System.Collections.Generic;
using Asteroids.GameLogic;
using Asteroids.GameLogic.Statistics;
using Asteroids.GameLogic.Utility;
using Asteroids.View.Player;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Asteroids.View.GameManagement
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject _gameoverPanel;
        [SerializeField] private TextMeshProUGUI _textMesh;

        private readonly List<Vector2> usedPoses = new List<Vector2>();
        private bool _restart;
        private int _maxRandTries = 30;
        public GameObject Player { get; private set; }
        private IGamePoints _gamePoints;

        private void Awake()
        {
            _gamePoints = Logic.GamePoints;
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
            var playerView = Player.GetComponent<IPlayerView>();
            playerView.Init(Finish);
            usedPoses.Add(Player.transform.position);
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