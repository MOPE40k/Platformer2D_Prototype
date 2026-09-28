using _Project.Develop.Runtime.Gameplay.Features.CollectablesFatures;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.TriggeredFeatures.Collectables
{
    public abstract class Collectable : Trigger2DHandler
    {
        [SerializeField] private CollectablesType _type = CollectablesType.Coin;
        [SerializeField, Min(0)] private int _rare = 1;

        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out ICollecting collecting))
            {
                collecting.Collect(_type, _rare);

                Destroy(gameObject);
            }
        }
    }
}