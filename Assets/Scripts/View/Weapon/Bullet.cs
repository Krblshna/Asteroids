using System;
using System.Collections;
using Asteroids.GameLogic.Common;
using Asteroids.GameLogic.Movers;
using Asteroids.GameLogic.PositionValidators;
using UnityEngine;

namespace Asteroids.View.Weapon
{
    
    public class Bullet : MonoBehaviour, IBullet
    {
        private float _speed;
        private float _bodySize = 0.07f;
        private GroupType _groupType;
        private IMover _mover;
        private Action<IBullet> _onDestroyAction;
        private WaitForSeconds _lifeTimeWait;
        private IEnumerator _destroyEn;
        private Damager _damager;

        void Awake()
        {
            _mover = new SimpleMover(transform, new BorderValidator(_bodySize));
            _damager = GetComponentInChildren<Damager>();
        }

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }

        public void Update()
        {
            _mover.Update();
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
            _damager.Init(_groupType, DoDestroy);
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