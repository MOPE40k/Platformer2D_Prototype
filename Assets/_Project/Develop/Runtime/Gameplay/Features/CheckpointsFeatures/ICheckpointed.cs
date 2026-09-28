using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.CheckpointsFeatures
{
    public interface ICheckpointed
    {
        void SetCheckpointPosition(Vector2 position);
    }
}