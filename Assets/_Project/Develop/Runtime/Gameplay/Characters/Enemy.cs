using _Project.Develop.Runtime.Gameplay.Controllers;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Characters
{
    public class Enemy : MonoBehaviour
    {
        [Header("References:")]
        [SerializeField] private Character _character = null;

        // References
        private CompositeController _moveController = null;

        private void Awake()
        {
            _moveController = new CompositeController(new Controller[]
            {
                new AiCharacterMovableController(_character),
                new AiCharacterJumpableController(_character),
                new AlongVelocityRotatableController(_character, _character)
            });
        }

        private void OnEnable()
            => _moveController.Enable();

        private void OnDisable()
            => _moveController.Disable();

        private void Update()
            => _moveController.UpdateTick(Time.deltaTime);
    }
}