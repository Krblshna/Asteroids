using Asteroids.GameManagement;
using UnityEngine;

namespace Asteroids.Movers
{
    public class FollowMoveController : MonoBehaviour, IMoveController
    {
        [SerializeField] private float _velocity;
        private IFollowMover _mover;

        public void Move()
        {
            _mover = GetComponent<IFollowMover>();
            var player = GameManager.Instance.Player;
            _mover.StartFollow(player.transform, _velocity);
        }

        public void DoOnDestroy()
        {
        }
    }
}