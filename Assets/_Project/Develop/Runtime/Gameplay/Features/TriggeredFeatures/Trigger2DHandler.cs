using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.TriggeredFeatures
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class Trigger2DHandler : MonoBehaviour
    {
        private void Awake()
        {
            if (TryGetComponent(out Collider2D collider))
                collider.isTrigger = true;
            else
                Debug.LogWarning("Collider2D component not found!");
        }

        protected abstract void OnTriggerEnter2D(Collider2D collision);
    }
}