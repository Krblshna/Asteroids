using System;
using System.Collections;
using Asteroids.Utils;
using UnityEngine;

namespace Asteroids.Weapon
{
    public class Bullet : MonoBehaviour, IBullet
    {
        private float _speed;
        private Rigidbody2D _body;
        private Action<IBullet> _onDestroyAction;
        private float _bodySize = 0.07f;
        private WaitForSeconds _lifeTimeWait;
        private IEnumerator _destroyEn;

        void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
        }
        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }

        public void Update()
        {
            transform.position = ScreenPortal.ValidatePos(transform.position, _bodySize);
        }

        private void OnTriggerEnter2D(Collider2D coll)
        {
            var destructible = coll.GetComponent<IDestructible>();
            if (destructible != null)
            {
                destructible.Hit();
                DoDestroy();
            }
        }

        private void DoDestroy()
        {
            if (_destroyEn != null)
            {
                StopCoroutine(_destroyEn);
                _destroyEn = null;
            }
            _onDestroyAction?.Invoke(this);
        }

        public void Init(float speed, float lifeTime, Action<IBullet> onDestroyAction)
        {
            _onDestroyAction = onDestroyAction;
            _speed = speed;
            _lifeTimeWait = new WaitForSeconds(lifeTime);
        }

        public void OnActivate(Vector2 initPos, Vector2 direction)
        {
            transform.position = initPos;
            _body.velocity = Vector2.zero;
            _body.AddForce(direction * _speed, ForceMode2D.Impulse);
            _destroyEn = DestroyInTime();
            StartCoroutine(_destroyEn);
        }

        private IEnumerator DestroyInTime()
        {
            yield return _lifeTimeWait;
            DoDestroy();
        }
    }
}