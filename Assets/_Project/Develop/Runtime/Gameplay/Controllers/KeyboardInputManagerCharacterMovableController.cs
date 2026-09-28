using _Project.Develop.Runtime.Gameplay.Features.MovementFeatures.CharactersMovement;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Controllers
{
    public sealed class KeyboardInputManagerCharacterMovableController : Controller
    {
        // Consts
        private const string HorizontalAxisName = "Horizontal";

        // References
        private readonly IMovable _movable = null;
        private readonly bool _rawAxis = false;

        public KeyboardInputManagerCharacterMovableController(IMovable movable, bool rawAxis = true)
        {
            _movable = movable;
            _rawAxis = rawAxis;
        }

        protected override void UpdateLogic(float deltaTime)
        {
            float horizontalInput = GetInput();

            _movable.SetMoveDirection(horizontalInput);
        }

        private float GetInput()
            => _rawAxis
                ? Input.GetAxisRaw(HorizontalAxisName)
                : Input.GetAxis(HorizontalAxisName);
    }
}