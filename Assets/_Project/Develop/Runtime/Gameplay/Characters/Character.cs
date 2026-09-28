using UnityEngine;
using _Project.Develop.Runtime.Gameplay.Controllers;
using _Project.Develop.Runtime.Gameplay.Features.MovementFeatures.CharactersMovement;
using _Project.Develop.Runtime.Gameplay.Features.TriggeredFeatures;
using _Project.Develop.Runtime.Gameplay.Features.CollisionDetections;
using _Project.Develop.Runtime.Gameplay.Features.TriggeredFeatures.Collectables;
using _Project.Develop.Runtime.Gameplay.Features.CheckpointsFeatures;
using _Project.Develop.Runtime.Gameplay.Features.CollectablesFatures;

namespace _Project.Develop.Runtime.Gameplay.Characters
{
    public class Character : MonoBehaviour, IMovable, IRotatable, IJumpable, ICheckpointed, ICollecting, IDamageable
    {
        [Header("References:")]
        [SerializeField] private Rigidbody2D _rigidbody = default;
        [SerializeField] private BoxCollider2D _collider = default;

        [Space]
        [Header("Movement Settings:")]
        [SerializeField] private float _coyoteTime = 0.15f;
        [SerializeField] private float _jumpBufferTime = 0.15f;
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _upJumpHeight = 25f;
        [SerializeField] private float _sideJumpLength = 10f;

        [Space]
        [Header("Collision Check Settings:")]
        [SerializeField] private float _distanceCheck = 0.1f;
        [SerializeField] private LayerMask _groundMask = default;
        [SerializeField] private LayerMask _platformMask = default;

        [Space]
        [Header("Gravity Settings:")]
        [SerializeField] private float _gravity = 80f;

        // Movement References
        private RigidbodyMover _mover = default;
        private TransformFlipRotator _rotator = default;

        // Collision Check References
        private CollisionHandler _collisionHandler = default;

        // Collectable Handler Reference
        private CollectablesStorage _collectablesStorage = default;

        // Checkpoint References
        private CheckpointsHandler _checkpointsHandler = default;

        // Runtime
        public Rigidbody2D Rigidbody => _rigidbody;

        public Vector2 CurrentVelocity => _mover.CurrentVelocity;
        public Quaternion CurrentRotation => _rotator.CurrentRotation;

        public bool IsCeilCollision => _collisionHandler.IsCeilCollision;
        public bool IsGrounded => _collisionHandler.IsGrounded;
        public bool IsLeftSideCollision => _collisionHandler.IsLeftSideCollision;
        public bool IsRightSideCollision => _collisionHandler.IsRightSideCollision;
        public bool IsSideCollision => _collisionHandler.IsSideCollision;

        public int CoinsCount => _collectablesStorage.GetCount(CollectablesType.Coin);
        public int HeartsCount => _collectablesStorage.GetCount(CollectablesType.Heart);

        private void Awake()
        {
            _collisionHandler = new CollisionHandler(
                _collider,
                _distanceCheck,
                _groundMask,
                _platformMask);

            _collectablesStorage = new CollectablesStorage();

            _checkpointsHandler = new CheckpointsHandler(transform.position);

            _mover = new RigidbodyMover(
                _rigidbody,
                _collisionHandler,
                _coyoteTime,
                _jumpBufferTime,
                _moveSpeed,
                _upJumpHeight,
                _sideJumpLength,
                _gravity);

            _rotator = new TransformFlipRotator(this.transform);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
                Debug.Log(_checkpointsHandler.LastCheckpoinPosition);

            _mover.UpdateTick(Time.deltaTime);
            _rotator.UpdateTick();
        }

        public void SetMoveDirection(float direction)
            => _mover.SetMoveDirection(direction);

        public void SetJumpState(ButtonStates state)
            => _mover.SetJumpState(state);

        public void SetRotateDirection(Vector2 velocity)
            => _rotator.SetVelocity(velocity);

        public void TakeDamage()
            => _mover.SetPosition(_checkpointsHandler.LastCheckpoinPosition);

        public void SetCheckpointPosition(Vector2 position)
            => _checkpointsHandler.SetCheckpointPosition(position);

        public void Collect(CollectablesType collectable, int count)
            => _collectablesStorage.Add(collectable, count);
    }
}