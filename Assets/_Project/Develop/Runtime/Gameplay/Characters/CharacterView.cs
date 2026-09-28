using _Project.Develop.Runtime.Gameplay.Animations;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Characters
{
    public class CharacterView : MonoBehaviour
    {
        [Header("References:")]
        [SerializeField] private Character _character = null;
        [SerializeField] private Animator _animator = null;

        // References
        private CharacterAnimationHandler _characterAnimationHandler = null;

        private void Awake()
            => _characterAnimationHandler = new CharacterAnimationHandler(_character, _animator);

        private void Update()
            => _characterAnimationHandler.UpdateTick();
    }
}