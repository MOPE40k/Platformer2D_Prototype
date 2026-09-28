using _Project.Develop.Runtime.Gameplay.Controllers;

namespace _Project.Develop.Runtime.Gameplay.Features.MovementFeatures.CharactersMovement
{
    public interface IJumpable
    {
        void SetJumpState(ButtonStates state);
    }
}