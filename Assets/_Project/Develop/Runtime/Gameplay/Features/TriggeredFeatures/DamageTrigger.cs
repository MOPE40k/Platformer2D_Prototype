using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.TriggeredFeatures
{
    public class DamageTrigger : Trigger2DHandler
    {
        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IDamageable damageable))
            {
                Debug.Log("TRIGGERED");

                damageable.TakeDamage();
            }
        }
    }
}