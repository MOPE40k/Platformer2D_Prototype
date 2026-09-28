using _Project.Develop.Runtime.Gameplay.Features.MovementFeatures.CharactersMovement;

namespace _Project.Develop.Runtime.Gameplay.Controllers
{
    public sealed class AlongVelocityRotatableController : Controller
    {
        // References
        private readonly IMovable _movable = null;
        private readonly IRotatable _rotatable = null;

        public AlongVelocityRotatableController(IMovable movable, IRotatable rotatable)
        {
            _movable = movable;
            _rotatable = rotatable;
        }

        protected override void UpdateLogic(float _)
            => _rotatable.SetRotateDirection(_movable.CurrentVelocity);
    }
}