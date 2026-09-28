using _Project.Develop.Runtime.Gameplay.Features.CollectablesFatures;

namespace _Project.Develop.Runtime.Gameplay.Features.TriggeredFeatures
{
    public interface ICollecting
    {
        void Collect(CollectablesType type, int value);
    }
}