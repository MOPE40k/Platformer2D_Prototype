using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.CheckpointsFeatures
{
    public class CheckpointsHandler
    {
        public CheckpointsHandler(Vector2 firstCheckpointPosition)
            => SetCheckpointPosition(firstCheckpointPosition);

        public Vector2 LastCheckpoinPosition { get; private set; } = default;

        public void SetCheckpointPosition(Vector2 newCheckpointPosition)
            => LastCheckpoinPosition = newCheckpointPosition;
    }
}