using System;
using System.Collections;
using Asteroids.Common;
using Asteroids.HitDetectors;
using Asteroids.Movers;
using Asteroids.PositionValidators;
using Asteroids.Utility;
using UnityEngine;

namespace Asteroids.Weapon
{
    
    public class Bullet : MonoBehaviour, IBullet
    {
        private float _speed;
        private GroupType _groupType;
        private IMover _mover;
        private Action<IBullet> _onDestroyAction;
        private float _bodySize = 0.07f;
        private WaitForSeconds _lifeTimeWait;
        private IEnumerator _destroyEn;

        void Awake()
        {
            _mover = new SimpleMover(transform, new BorderValidator(_bodySize));
        }
        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }

        public void Update()
        {
            _mover.Update();
        }

        private void OnTriggerEnter2D(Collider2D coll)
        {
            var hitDetector = coll.GetComponent<IHitDetector>();
            if (hitDetector != null)
            {
                var hit = hitDetector.Hit(_groupType);
                if (!hit) return;
                DoDestroy();
            }
        }

        private void DoDestroy()
        {
            if (!gameObject.activeSelf) return;
            if (_destroyEn != null)
            {
                StopCoroutine(_destroyEn);
                _destroyEn = null;
            }

            _mover.DoOnDestroy();
            _onDestroyAction?.Invoke(this);
        }

        public void Init(GroupType groupType, float speed, float lifeTime, Action<IBullet> onDestroyAction)
        {
            _groupType = groupType;
            _onDestroyAction = onDestroyAction;
            _speed = speed;
            _lifeTimeWait = new WaitForSeconds(lifeTime);
        }

        public void OnActivate(Vector2 initPos, Vector2 direction)
        {
            transform.position = initPos;
            _mover.Move(direction, _speed);
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