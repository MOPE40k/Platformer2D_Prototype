using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.CollisionDetections
{
    public sealed class BoxColliderCollisionChecker : ColliderCollisionChecker
    {
        // References
        private readonly BoxCollider2D _collider = null;

        public BoxColliderCollisionChecker(
            BoxCollider2D collider,
            Vector2 direction,
            float distance,
            LayerMask mask) : base(direction, distance, mask)
        {
            _collider = collider;
        }

        protected override bool CollisionCheck()
            => Physics2D.BoxCast(
                _collider.bounds.center,
                _collider.size,
                0f,
                _direction,
                _distance,
                _mask).collider != null;
    }
}