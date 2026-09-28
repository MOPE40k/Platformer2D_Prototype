using _Project.Develop.Runtime.Gameplay.Characters;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Animations
{
    public class CharacterAnimationHandler
    {
        // Consts
        private readonly int VelocityXKey = Animator.StringToHash("VelocityX");
        private readonly int VelocityYKey = Animator.StringToHash("VelocityY");
        private readonly int IsGroundedKey = Animator.StringToHash("IsGrounded");

        // References
        private readonly Character _character = null;
        private readonly Animator _animator = null;

        public CharacterAnimationHandler(Character character, Animator animator)
        {
            _character = character;
            _animator = animator;
        }

        public void UpdateTick()
        {
            _animator.SetFloat(VelocityXKey, Mathf.Abs(_character.CurrentVelocity.x));
            _animator.SetFloat(VelocityYKey, _character.CurrentVelocity.y);
            _animator.SetBool(IsGroundedKey, _character.IsGrounded);
        }
    }
}