using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.MovementFeatures.CharactersMovement
{
    public class TransformFlipRotator
    {
        // Consts
        private const float MagnitudeTreshold = 0.05f;

        // References
        private readonly Transform _transform = default;

        // Runtime
        private Vector2 _velocity = default;
        private bool _isFacingRight = true;

        public TransformFlipRotator(Transform transform)
            => _transform = transform;

        // Runtime
        public Quaternion CurrentRotation => _transform.localRotation;

        private Quaternion TurnRight => Quaternion.identity;
        private Quaternion TurnLeft => Quaternion.Euler(0f, 180f, 0f);

        public void SetVelocity(Vector2 velocity)
            => _velocity = velocity;

        public void UpdateTick()
        {
            if (_velocity.sqrMagnitude <= Mathf.Pow(MagnitudeTreshold, 2))
                return;

            _transform.localRotation = GetRotationFrom(_velocity);
        }

        private Quaternion GetRotationFrom(Vector2 velocity)
        {
            var resultRotation = CurrentRotation;

            if (velocity.x > 0 && !_isFacingRight)
            {
                _isFacingRight = !_isFacingRight;
                resultRotation = TurnRight;
            }
            else if (velocity.x < 0 && _isFacingRight)
            {
                _isFacingRight = !_isFacingRight;
                resultRotation = TurnLeft;
            }

            return resultRotation;
        }
    }
}