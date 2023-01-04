using Movements;

namespace Enemies
{
    public interface IEntity
    {
        int Health { get; }

        bool IsAlive { get; }
        IMovable Movement { get;}

        void ApplyDamage(IEntity sender, float amount);
        
        
    }
}