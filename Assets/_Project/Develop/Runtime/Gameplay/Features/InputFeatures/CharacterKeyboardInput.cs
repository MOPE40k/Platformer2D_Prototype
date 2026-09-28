using _Project.Develop.Runtime.Gameplay.Characters;
using _Project.Develop.Runtime.Gameplay.Controllers;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.InputFeatures
{
    public class CharacterKeyboardInput : MonoBehaviour
    {
        [Header("References:")]
        [SerializeField] private Character _character = null;

        // [Space]
        // [Header("Settings:")]
        // [SerializeField] private bool _horizontalInputRawAxis = false;

        // Runtime
        private InputSystemActions _inputActions = default;
        private CompositeController _keyboardController = null;

        private void Awake()
        {
            _inputActions = new();

            _keyboardController = new CompositeController(new Controller[]
            {
                // new KeyboardInputManagerCharacterMovableController(_character, _horizontalInputRawAxis),
                new KeyboardInputSystemCharacterMovableController(_inputActions, _character),
                new KeyboardInputSystemCharacterJumpableController(_inputActions, _character),
            // new KeyboardInputManagerCharacterJumpableController(_character),
            new AlongVelocityRotatableController(_character, _character)
            });
        }

        private void OnEnable()
            => _keyboardController.Enable();

        private void OnDisable()
            => _keyboardController.Disable();

        private void Update()
            => _keyboardController.UpdateTick(Time.deltaTime);

        private void OnDestroy()
            => _inputActions.Dispose();
    }
}