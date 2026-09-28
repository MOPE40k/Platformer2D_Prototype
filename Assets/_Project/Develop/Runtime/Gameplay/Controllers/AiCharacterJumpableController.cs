using _Project.Develop.Runtime.Gameplay.Features.MovementFeatures.CharactersMovement;

namespace _Project.Develop.Runtime.Gameplay.Controllers
{
    public class AiCharacterJumpableController : Controller
    {
        // References
        private readonly IJumpable _jumpable = null;

        public AiCharacterJumpableController(IJumpable jumpable)
            => _jumpable = jumpable;

        protected override void UpdateLogic(float deltaTime)
            => _jumpable.SetJumpState(ButtonStates.Held);
    }
}