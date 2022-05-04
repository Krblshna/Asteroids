using System;
using System.Collections.Generic;
using System.Linq;
using Asteroids.Common;
using Asteroids.Enemies;
using Asteroids.Statistics;
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
        private int _minAsteroids = 3, _maxAsteroids = 5;
        private int _maxRandTries = 30;
        private List<Vector2> usedPoses = new List<Vector2>();
        private HashSet<int> enemies = new HashSet<int>();
        private bool _restart;
        public GameObject Player { get; private set; }

        private void Start()
        {
            StartNewGame();
        }

        public void RegisterEnemy(GameObject enemyObj)
        {
            //enemies.Add(enemyObj.GetInstanceID());
        }

        public void UnregisterEnemy(GameObject enemyObj)
        {
            //enemies.Remove(enemyObj.GetInstanceID());
            //if (enemies.Count < 1 && !_restart)
            //{
            //    _restart = true;
            //    Utils.Instance.setTimeOut(RestartGame, 1f);
            //}
        }

        private void StartNewGame()
        {
            SpawnPlayer();
            var asteroidsAmount = Random.Range(_minAsteroids, _maxAsteroids + 1);
            for (var i = 0; i < asteroidsAmount; i++)
            {
                EnemiesManager.Instance.CreateEnemy(EnemyType.asteroid, GetRandPos());
            }
        }

        private void SpawnPlayer()
        {
            Player = Instantiate(_playerPrefab, Vector3.zero, Quaternion.identity);
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
            enemies.Clear();
            _restart = false;
            GamePoints.Clear();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }

        public void Finish()
        {
            _gameoverPanel.SetActive(true);
            _textMesh.text = $"Your Points: {GamePoints.StatAmount}";
            Utils.Instance.setTimeOut(RestartGame, 3f);
        }
    }
}