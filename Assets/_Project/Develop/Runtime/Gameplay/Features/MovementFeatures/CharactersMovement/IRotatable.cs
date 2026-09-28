using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.MovementFeatures.CharactersMovement
{
    public interface IRotatable
    {
        // Runtime
        Quaternion CurrentRotation { get; }

        void SetRotateDirection(Vector2 velocity);
    }
}