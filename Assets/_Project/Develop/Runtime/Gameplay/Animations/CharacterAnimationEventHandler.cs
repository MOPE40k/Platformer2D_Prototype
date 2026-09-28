using _Project.Develop.Runtime.Gameplay.Characters;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Animations
{
    public class CharacterAnimationEventHandler : MonoBehaviour
    {
        [Header("References:")]
        [SerializeField] private Character _character = null;

        private void DieAnimationComplete()
            => _character.TakeDamage();
    }
}