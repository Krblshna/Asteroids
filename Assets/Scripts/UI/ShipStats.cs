using System.Text;
using UnityEngine;
using TMPro;

namespace Asteroids.UI
{


    public class ShipStats : MonoBehaviour
    {
        [SerializeField] private Player.Player _player;
        [SerializeField] private int maxUpdateTimesPerSecond = 10;
        private TextMeshProUGUI _textMesh;
        private Rigidbody2D _body;
        private float _updateDelta = 0;
        private float _lastUpdateTime = 0;

        private void Awake()
        {
            _updateDelta = 1.0f / maxUpdateTimesPerSecond;
            _textMesh = GetComponent<TextMeshProUGUI>();
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
            var pos = _body.position;
            var posX = pos.x.ToString("0.0");
            var posY = pos.y.ToString("0.0");
            var velocity = _body.velocity;
            var velocityX = velocity.x.ToString("0.0");
            var velocityY = velocity.y.ToString("0.0");
            var angle = (int)Mathf.Abs(_body.rotation % 360);
            StringBuilder sb = new StringBuilder(100);
            sb.Append($"Coordinate: ({posX}, {posY})\n");
            sb.Append($"Rotation angle: {angle}\n");
            sb.Append($"Velocity: ({velocityX}, {velocityY})\n");
            sb.Append("Lazer charges: \n");
            sb.Append("Lazer cooldown: \n");
            _textMesh.text = sb.ToString();
        }
    }
}