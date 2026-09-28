using UnityEngine;
using _Project.Develop.Runtime.Gameplay.Features.MovementFeatures.CharactersMovement;

namespace _Project.Develop.Runtime.Gameplay.Controllers
{
    public sealed class KeyboardInputManagerCharacterJumpableController : Controller
    {
        // Consts
        private const KeyCode JumpKeyCode = KeyCode.Space;

        // References
        private readonly IJumpable _jumpable = default;

        public KeyboardInputManagerCharacterJumpableController(IJumpable jumpable)
            => _jumpable = jumpable;

        protected override void UpdateLogic(float _)
        {
            ButtonStates jumpButtonState;

            if (Input.GetKeyDown(JumpKeyCode))
                jumpButtonState = ButtonStates.Down;
            else if (Input.GetKey(JumpKeyCode))
                jumpButtonState = ButtonStates.Held;
            else if (Input.GetKeyUp(JumpKeyCode))
                jumpButtonState = ButtonStates.Up;
            else
                jumpButtonState = ButtonStates.NotPressed;

            _jumpable.SetJumpState(jumpButtonState);
        }
    }
}