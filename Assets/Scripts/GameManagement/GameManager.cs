using System;
using System.Collections.Generic;
using System.Linq;
using Asteroids.Asteroid;
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

        private void Start()
        {
            StartNewGame();
        }

        public void RegisterEnemy(GameObject enemyObj)
        {
            enemies.Add(enemyObj.GetInstanceID());
            Debug.Log($"enemies Add - {enemies.Count} {Time.time}");
        }

        public void UnregisterEnemy(GameObject enemyObj)
        {
            enemies.Remove(enemyObj.GetInstanceID());
            Debug.Log($"enemies Remove - {enemies.Count} {Time.time}");
            if (enemies.Count < 1 && !_restart)
            {
                _restart = true;
                Utils.Instance.setTimeOut(RestartGame, 1f);
            }
        }

        private void StartNewGame()
        {
            SpawnPlayer();
            var asteroidsAmount = Random.Range(_minAsteroids, _maxAsteroids + 1);
            for (var i = 0; i < asteroidsAmount; i++)
            {
                AsteroidsManager.Instance.CreateAsteroid(AsteroidType.big, GetRandPos());
            }
        }

        private void SpawnPlayer()
        {
            var player = Instantiate(_playerPrefab, Vector3.zero, Quaternion.identity);
            usedPoses.Add(player.transform.position);
        }

        private Vector2 GetRandPos()
        {
            bool intersect;
            Vector2 randPos;
            int counter = 0;
            do
            {
                randPos = ScreenPortal.GetRandPos();
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
            Stats.Instance.Clear();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }

        public void Finish()
        {
            _gameoverPanel.SetActive(true);
            _textMesh.text = $"Your Points: {Stats.Instance.StatAmount}";
            Utils.Instance.setTimeOut(RestartGame, 3f);
        }
    }
}