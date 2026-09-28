namespace _Project.Develop.Runtime.Gameplay.Controllers
{
    public abstract class Controller
    {
        // Runtime
        private bool _isEnabled = default;

        public virtual void Enable()
            => _isEnabled = true;

        public virtual void Disable()
            => _isEnabled = false;

        public void UpdateTick(float deltaTime)
        {
            if (!_isEnabled)
                return;

            UpdateLogic(deltaTime);
        }

        protected abstract void UpdateLogic(float deltaTime);
    }
}