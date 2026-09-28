using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.CollisionDetections
{
    public class CollisionHandler
    {
        private readonly BoxCollider2D _collider = default;
        private readonly float _distance = default;
        private readonly LayerMask _groundMask = default;
        private readonly LayerMask _platformMask = default;

        // References
        private ColliderCollisionChecker _ceilChecker = default;
        private ColliderCollisionChecker _groundChecker = default;
        private ColliderCollisionChecker _leftSideChecker = default;
        private ColliderCollisionChecker _rightSideChecker = default;

        public CollisionHandler(
            BoxCollider2D collider,
            float distance,
            LayerMask groundMask,
            LayerMask platformMask)
        {
            _collider = collider;
            _distance = distance;
            _groundMask = groundMask;
            _platformMask = platformMask;

            CreateCollisionCheckers();
        }

        public bool IsCeilCollision => _ceilChecker.IsCollision;
        public bool IsGrounded => _groundChecker.IsCollision;
        public bool IsLeftSideCollision => _leftSideChecker.IsCollision;
        public bool IsRightSideCollision => _rightSideChecker.IsCollision;
        public bool IsSideCollision => IsLeftSideCollision || IsRightSideCollision;
        public int CollisionSide => GetCollisionSide();

        private void CreateCollisionCheckers()
        {
            _ceilChecker = CreateCollisionChecker(Vector2.up, _groundMask);
            _groundChecker = CreateCollisionChecker(Vector2.down, _platformMask);
            _leftSideChecker = CreateCollisionChecker(Vector2.left, _groundMask);
            _rightSideChecker = CreateCollisionChecker(Vector2.right, _groundMask);
        }

        private BoxColliderCollisionChecker CreateCollisionChecker(Vector2 checkDirection, LayerMask layerMask)
            => new BoxColliderCollisionChecker(
                _collider,
                checkDirection,
                _distance,
                layerMask);

        private int GetCollisionSide()
        {
            if (IsLeftSideCollision)
                return -1;
            else if (IsRightSideCollision)
                return 1;
            else
                return 0;
        }
    }
}