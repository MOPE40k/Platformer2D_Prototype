using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.CollisionDetections
{
    public abstract class ColliderCollisionChecker
    {
        // Settings
        protected readonly Vector2 _direction = default;
        protected readonly float _distance = default;
        protected readonly LayerMask _mask = default;

        protected ColliderCollisionChecker(Vector2 direction, float distance, LayerMask mask)
        {
            _direction = direction;
            _distance = distance;
            _mask = mask;
        }

        public bool IsCollision => CollisionCheck();

        protected abstract bool CollisionCheck();
    }
}