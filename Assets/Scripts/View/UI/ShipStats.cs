using System.Text;
using Asteroids.GameLogic;
using Asteroids.GameLogic.Player;
using UnityEngine;
using TMPro;

namespace Asteroids.View.UI
{
    public class ShipStats : MonoBehaviour
    {
        [SerializeField] private int maxUpdateTimesPerSecond = 10;

        private TextMeshProUGUI _textMesh;
        private float _updateDelta = 0;
        private float _lastUpdateTime = 0;
        private IPlayerStat _playerStat;

        private void Start()
        {
            _playerStat = Logic.PlayerStat;
            _updateDelta = 1.0f / maxUpdateTimesPerSecond;
            _textMesh = GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            if (Time.time - _lastUpdateTime > _updateDelta)
            {
                _lastUpdateTime = Time.time;
                UpdateStat();
            }
        }

        private void UpdateStat()
        {
            var moveData = _playerStat.MoveData;
            var laserData = _playerStat.LaserData;
            var pos = moveData.Position;
            var velocity = moveData.Velocity;
            var angle = Mathf.Abs(moveData.Rotation % 360);
            StringBuilder sb = new StringBuilder(100);
            sb.Append($"Coordinate: ({pos.x:0.0}, {pos.y:0.0})\n");
            sb.Append($"Rotation angle: {angle}\n");
            sb.Append($"Velocity: ({velocity.x:0.0}, {velocity.y:0.0})\n");
            sb.Append($"Lazer charges: {laserData.Ammo} \n");
            sb.Append($"Lazer cooldown: {laserData.LaserCooldown:0.0} \n");
            _textMesh.text = sb.ToString();
        }
    }
}