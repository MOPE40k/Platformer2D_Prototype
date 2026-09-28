using _Project.Develop.Runtime.Gameplay.Features.MovementFeatures.CharactersMovement;
using UnityEngine.InputSystem;
using System.Collections.Generic;

namespace _Project.Develop.Runtime.Gameplay.Controllers
{
    public sealed class KeyboardInputSystemCharacterJumpableController : Controller
    {
        // References
        private readonly InputSystemActions _inputActions = default;
        private readonly IJumpable _jumpable = default;
        // private InputAction _jumpAction = default;
        private Queue<ButtonStates> _jumpEdgeEvents = new();

        public KeyboardInputSystemCharacterJumpableController(
            InputSystemActions inputActions,
            IJumpable jumpable)
        {
            _inputActions = inputActions;
            _jumpable = jumpable;
        }

        public override void Enable()
        {
            base.Enable();

            // _jumpAction = _inputActions.Player.Jump;

            _inputActions.Player.Jump.started += OnJumpStarted;
            _inputActions.Player.Jump.canceled += OnJumpCanceled;

            _inputActions.Player.Enable();
        }

        public override void Disable()
        {
            base.Disable();

            _inputActions.Player.Jump.started -= OnJumpStarted;
            _inputActions.Player.Jump.canceled -= OnJumpCanceled;

            _inputActions.Player.Disable();
        }

        protected override void UpdateLogic(float _)
        {
            _jumpable.SetJumpState(ConsumeJumpState());

            // ButtonStates jumpButtonState;

            // if (_jumpAction.WasPressedThisFrame())
            //     jumpButtonState = ButtonStates.Down;
            // else if (_jumpAction.IsPressed())
            //     jumpButtonState = ButtonStates.Held;
            // else if (_jumpAction.WasReleasedThisFrame())
            //     jumpButtonState = ButtonStates.Up;
            // else
            //     jumpButtonState = ButtonStates.NotPressed;

            // _jumpable.SetJumpState(jumpButtonState);
        }

        private void OnJumpStarted(InputAction.CallbackContext _)
            => _jumpEdgeEvents.Enqueue(ButtonStates.Down);

        private void OnJumpCanceled(InputAction.CallbackContext _)
            => _jumpEdgeEvents.Enqueue(ButtonStates.Up);

        private ButtonStates ConsumeJumpState()
        {
            if (_jumpEdgeEvents.Count > 0)
                return _jumpEdgeEvents.Dequeue();

            return _inputActions.Player.Jump.IsPressed()
                ? ButtonStates.Held
                : ButtonStates.NotPressed;
        }
    }
}