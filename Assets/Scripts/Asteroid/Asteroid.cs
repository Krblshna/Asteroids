using System;
using Asteroids.Effect;
using Asteroids.Utility;
using Asteroids.Weapon;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids.Asteroid
{
    public class Asteroid : MonoBehaviour, IAsteroid, IDestructible
    {
        [SerializeField] private float _minStartForce,
            _maxStartForce,
            _minRotation,
            _maxRotation;

        [SerializeField] private EffectType _destroyEffect;
        [SerializeField] private bool _poolable;
        private Rigidbody2D _body;
        private float _bodySize = 1f;
        private bool _destroyed;
        private Action<IAsteroid> _onDestroyAction;
        private IDestroyAction _destroyAction;
        private GroupType _groupType = GroupType.Enemy;
        void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
            _destroyAction = GetComponent<IDestroyAction>();
        }
        public void Update()
        {
            transform.position = ScreenPortal.ValidatePos(transform.position, _bodySize);
        }
        void Start()
        {
            if (!_poolable)
            {
                OnGet();
            }
        }

        int RandSign()
        {
            return (int)Mathf.Sign(Random.Range(-1, 1));
        }

        public bool Hit(GroupType hitType)
        {
            if (_groupType == hitType || _destroyed) return false;
            _destroyed = true;
            EffectsManager.Instance.CreateEffect(_destroyEffect, transform.position);
            _destroyAction?.Execute();
            if (_poolable)
            {
                _onDestroyAction?.Invoke(this);
            }
            else
            {
                Destroy(this.gameObject);
            }

            return true;
        }

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }

        public void Init(Action<IAsteroid> onDestroyAction)
        {
            _onDestroyAction = onDestroyAction;
        }

        public GameObject GetObj => gameObject;
        public void OnGet()
        {
            var randomForce = new Vector2(RandSign() * Random.Range(_minStartForce, _maxStartForce), RandSign() * Random.Range(_minStartForce, _maxStartForce));
            var randomRotation = RandSign() * Random.Range(_minRotation, _maxRotation);
            _body.AddForce(randomForce);
            _body.AddTorque(randomRotation);
            _destroyed = false;
        }
    }
}