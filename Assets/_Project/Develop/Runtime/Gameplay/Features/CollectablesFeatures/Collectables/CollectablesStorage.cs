using System.Collections.Generic;
using _Project.Develop.Runtime.Gameplay.Features.CollectablesFatures;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.TriggeredFeatures.Collectables
{
    public class CollectablesStorage
    {
        // Consts
        private const int CoinsDefaultCount = 0;
        private const int HeartsDefaultCount = 3;

        // References
        private readonly Dictionary<CollectablesType, int> _collectables = null;

        public CollectablesStorage()
            => _collectables = new Dictionary<CollectablesType, int>()
            {
                {CollectablesType.Coin, CoinsDefaultCount},
                {CollectablesType.Heart, HeartsDefaultCount}
            };

        public void Add(CollectablesType collectable, int count)
        {
            if (count < 0)
            {
                Debug.LogError($"{collectable}, {count}. Count cannot be less than zero!");

                return;
            }

            if (_collectables.ContainsKey(collectable))
                _collectables[collectable] += count;
            else
                _collectables.Add(collectable, count);
        }

        public void Subtract(CollectablesType collectable, int count)
        {
            if (count <= 0)
            {
                Debug.LogError($"{collectable}, {count}. Count cannot be less than or equal to zero!");

                return;
            }


            if (_collectables.ContainsKey(collectable))
            {
                _collectables[collectable] -= count;

                if (_collectables[collectable] < 0)
                    _collectables[collectable] = 0;
            }
        }

        public int GetCount(CollectablesType collectable)
            => _collectables[collectable];
    }
}