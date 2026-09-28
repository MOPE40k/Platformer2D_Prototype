using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.MovementFeatures.CharactersMovement
{
    public interface IMovable
    {
        // Runtime
        Vector2 CurrentVelocity { get; }

        void SetMoveDirection(float direction);
    }
}