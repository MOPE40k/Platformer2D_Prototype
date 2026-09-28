using _Project.Develop.Runtime.Gameplay.Features.MovementFeatures.CharactersMovement;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Controllers
{
    public sealed class KeyboardInputSystemCharacterMovableController : Controller
    {
        // References
        private readonly InputSystemActions _inputActions = default;
        private readonly IMovable _movable = null;
        // private readonly bool _rawAxis = false;

        public KeyboardInputSystemCharacterMovableController(InputSystemActions inputActions, IMovable movable)
        {
            _inputActions = inputActions;
            _movable = movable;
            // _rawAxis = rawAxis;
        }

        protected override void UpdateLogic(float deltaTime)
        {
            var horizontalInput = GetInput();

            _movable.SetMoveDirection(horizontalInput);
        }

        private float GetInput()
            => _inputActions.Player.Move.ReadValue<float>();
    }
}