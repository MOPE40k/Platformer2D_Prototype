using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Collided
{
    public class BreakablePlatformView : MonoBehaviour
    {
        [Header("References:")]
        [SerializeField] private SpriteRenderer[] _spriteRenderers = null;
        [SerializeField] private BreakablePlatform _breakable = null;

        // Runtime
        private Color[] _spriteColors = null;

        private void Awake()
        {
            _spriteColors = new Color[_spriteRenderers.Length];

            for (var i = 0; i < _spriteRenderers.Length; i++)
                _spriteColors[i] = _spriteRenderers[i].color;
        }

        private void Update()
        {
            for (var i = 0; i < _spriteColors.Length; i++)
            {
                _spriteColors[i].a = _breakable.Progress;
                _spriteRenderers[i].color = _spriteColors[i];
            }
        }
    }
}