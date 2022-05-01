using Asteroids.Effect;
using Asteroids.Utils;
using Asteroids.Weapon;
using UnityEngine;

namespace Asteroids
{
    public class Asteroid : MonoBehaviour, IDestructible
    {
        [SerializeField] private float _minStartForce,
            _maxStartForce,
            _minRotation,
            _maxRotation;

        [SerializeField] private GameObject _destroyEffectObj;
        private Rigidbody2D _body;
        private float _bodySize = 1f;
        private IEffect _destroyEffect;
        void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
            _destroyEffect = _destroyEffectObj.GetComponent<IEffect>();
        }
        public void Update()
        {
            transform.position = ScreenPortal.ValidatePos(transform.position, _bodySize);
        }
        void Start()
        {
            var randomForce = new Vector2(RandSign() * Random.Range(_minStartForce, _maxStartForce), RandSign() * Random.Range(_minStartForce, _maxStartForce));
            var randomRotation = RandSign() * Random.Range(_minRotation, _maxRotation);
            _body.AddForce(randomForce);
            _body.AddTorque(randomRotation);
        }

        int RandSign()
        {
            return (int)Mathf.Sign(Random.Range(-1, 1));
        }

        public void Hit()
        {
            Destroy(this.gameObject);
        }
    }
}