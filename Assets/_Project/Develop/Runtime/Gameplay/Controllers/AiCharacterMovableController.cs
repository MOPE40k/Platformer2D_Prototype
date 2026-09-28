using _Project.Develop.Runtime.Gameplay.Characters;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Controllers
{
    public class AiCharacterMovableController : Controller
    {
        // Consts
        private const float LeftDirection = -1f;
        private const float RightDirection = 1f;

        // References
        private readonly Character _character = null;

        // Runtime
        private float _currentMoveDirection = 0f;

        public AiCharacterMovableController(Character character)
        {
            _character = character;

            _currentMoveDirection = GetRandomDirection();
        }

        protected override void UpdateLogic(float deltaTime)
        {
            if (_character.IsLeftSideCollision)
                _currentMoveDirection = RightDirection;
            else if (_character.IsRightSideCollision)
                _currentMoveDirection = LeftDirection;

            if (_character.IsGrounded)
                _character.SetMoveDirection(_currentMoveDirection);
        }

        private float GetRandomDirection()
            => (Random.value < 0.5f) ? LeftDirection : RightDirection;
    }
}