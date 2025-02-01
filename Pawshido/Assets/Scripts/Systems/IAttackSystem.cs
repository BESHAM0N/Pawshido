using Models;

namespace System
{
    public interface IAttackSystem
    {
        int Damage { get; set; }
        
        void OnAttack(IEntity enemy);
    }
}