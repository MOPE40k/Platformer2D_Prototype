using _Project.Develop.Runtime.Gameplay.Features.TriggeredFeatures;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.CheckpointsFeatures
{
    public class Checkpoint : Trigger2DHandler
    {
        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out ICheckpointed checkpointed))
                checkpointed.SetCheckpointPosition(transform.position);
        }
    }
}