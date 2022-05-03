using System.Collections;
using System.Text;
using Asteroids.Weapon;
using UnityEngine;
using TMPro;
using Asteroids.Statistics;
using Asteroids.Player;

namespace Asteroids.UI
{
    public class ShipStats : MonoBehaviour
    {
        private Player.Player _player;
        private Laser _laser;
        [SerializeField] private int maxUpdateTimesPerSecond = 10;
        private TextMeshProUGUI _textMesh;
        private Rigidbody2D _body;
        private float _updateDelta = 0;
        private float _lastUpdateTime = 0;

        private IEnumerator Start()
        {
            yield return null;
            _updateDelta = 1.0f / maxUpdateTimesPerSecond;
            _textMesh = GetComponent<TextMeshProUGUI>();
            _player = FindObjectOfType<Player.Player>();
            _laser = _player.GetComponentInChildren<Laser>();
            _body = _player.GetBody();
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
            if (_body == null) return;
            var pos = _body.position;
            var velocity = _body.velocity;
            var angle = (int)Mathf.Abs(_body.rotation % 360);
            StringBuilder sb = new StringBuilder(100);
            sb.Append($"Points: {Stats.Instance.StatAmount} \n");
            sb.Append($"Coordinate: ({pos.x:0.0}, {pos.y:0.0})\n");
            sb.Append($"Rotation angle: {angle}\n");
            sb.Append($"Velocity: ({velocity.x:0.0}, {velocity.y:0.0})\n");
            sb.Append($"Lazer charges: {_laser.Ammo} \n");
            sb.Append($"Lazer cooldown: {_laser.LaserCooldown:0.0} \n");
            _textMesh.text = sb.ToString();
        }
    }
}