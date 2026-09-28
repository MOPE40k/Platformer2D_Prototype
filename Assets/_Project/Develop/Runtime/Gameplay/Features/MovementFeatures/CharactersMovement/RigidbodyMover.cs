using UnityEngine;
using _Project.Develop.Runtime.Gameplay.Controllers;
using _Project.Develop.Runtime.Gameplay.Features.CollisionDetections;
using PlatformerDemo.Assets._Project.Develop.Runtime.Utils;

namespace _Project.Develop.Runtime.Gameplay.Features.MovementFeatures.CharactersMovement
{
    public class RigidbodyMover
    {
        // Consts
        private const float MinGravityValue = -2f;

        // References
        private readonly Rigidbody2D _rigidbody = default;
        private readonly CollisionHandler _collisionHandler = default;

        // Settings
        private readonly float _coyoteTime = default;
        private readonly float _jumpBufferTime = default;
        private readonly float _moveSpeed = default;
        private readonly float _upJumpHeight = default;
        private readonly float _sideJumpLength = default;
        private readonly float _gravity = default;

        // Runtime
        private float _coyoteTimeCounter = default;
        private float _jumpBufferCounter = default;
        // private bool _jumpConsumed = default;
        private Vector2 _velocity = default;
        private ButtonStates _jumpState = default;
        private float _currentMoveDirection = default;

        public RigidbodyMover(
            Rigidbody2D rigidbody,
            CollisionHandler collisionHandler,
            float coyoteTime,
            float jumpBufferTime,
            float moveSpeed,
            float upJumpHeight,
            float sideJumpLength,
            float gravity)
        {
            _rigidbody = rigidbody;
            _collisionHandler = collisionHandler;
            _coyoteTime = coyoteTime;
            _jumpBufferTime = jumpBufferTime;
            _moveSpeed = moveSpeed;
            _upJumpHeight = upJumpHeight;
            _sideJumpLength = sideJumpLength;
            _gravity = gravity;
        }

        public Vector2 CurrentVelocity => _rigidbody.velocity;

        public void UpdateTick(float deltaTime)
        {
            CoyoteTimeHandler(deltaTime);
            JumpBufferHandle(deltaTime);
            GravityHandle(deltaTime);
            MoveDirectionHandle();
            CeilHandle();
            JumpHandle();
            SetVelocity();
            VariableJumpHeightHandle();
        }

        public void SetMoveDirection(float direction)
            => _currentMoveDirection = direction;

        public void SetJumpState(ButtonStates jumpState)
        {
            _jumpState = jumpState;
        }

        public void SetPosition(Vector2 position)
        {
            _velocity = Vector2.zero;

            _rigidbody.position = position;
        }

        private void CoyoteTimeHandler(float deltaTime)
        {
            _coyoteTimeCounter = _collisionHandler.IsGrounded || _collisionHandler.IsSideCollision
                ? _coyoteTime
                : _coyoteTimeCounter - deltaTime;
        }

        private void JumpBufferHandle(float deltaTime)
        {
            if (_jumpState == ButtonStates.Down)
                _jumpBufferCounter = _jumpBufferTime;
            else
                _jumpBufferCounter -= deltaTime;
        }

        private void MoveDirectionHandle()
        {
            if (_collisionHandler.IsGrounded)
                _velocity.x = _currentMoveDirection * _moveSpeed;
        }

        private void CeilHandle()
        {
            if (_collisionHandler.IsCeilCollision)
                _velocity.y = Mathf.Min(0f, _velocity.y);
        }

        private void GravityHandle(float deltaTime)
        {
            if (_collisionHandler.IsGrounded && _velocity.y <= 0f)
                _velocity.y = MinGravityValue;
            else
                _velocity.y -= _gravity * deltaTime;
        }

        private void JumpHandle()
        {
            if (_jumpBufferCounter > 0f && _coyoteTimeCounter > 0f)
            {
                if (_collisionHandler.IsGrounded)
                {
                    UpJump();
                }
                else if (!_collisionHandler.IsGrounded
                    && _collisionHandler.IsSideCollision
                    && _currentMoveDirection != 0f
                    && HelpedUtils.StrictSign(_currentMoveDirection) == _collisionHandler.CollisionSide)
                {
                    UpJump();
                    SideJump();
                }

                _jumpBufferCounter = 0f;
                _coyoteTimeCounter = 0f;
            }
        }

        private void UpJump()
            => _velocity.y = _upJumpHeight;

        private void SideJump()
            => _velocity.x = (_currentMoveDirection * -1) * _sideJumpLength;

        private void SetVelocity()
        {
            _rigidbody.velocity = _velocity;
        }

        private void VariableJumpHeightHandle()
        {
            if (_jumpState == ButtonStates.Up
                && _rigidbody.velocity.y > 0f
                && !_collisionHandler.IsGrounded)
            {
                _velocity.y *= 0.5f;
                _coyoteTimeCounter = 0f;
            }
        }
    }
}