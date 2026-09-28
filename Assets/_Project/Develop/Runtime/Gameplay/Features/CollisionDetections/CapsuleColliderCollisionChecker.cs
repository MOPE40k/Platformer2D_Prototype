using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.CollisionDetections
{
    public class CapsuleColliderCollisionChecker : ColliderCollisionChecker
    {
        // References
        private readonly CapsuleCollider2D _collider = null;

        public CapsuleColliderCollisionChecker(
            CapsuleCollider2D collider,
            Vector2 direction,
            float distance,
            LayerMask mask) : base(direction, distance, mask)
        {
            _collider = collider;
        }

        protected override bool CollisionCheck()
            => Physics2D.CapsuleCast(
                _collider.bounds.center,
                _collider.size,
                _collider.direction,
                0f,
                _direction,
                _distance,
                _mask).collider != null;
    }
}