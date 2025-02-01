using System;

namespace Systems
{
    public interface IHealthSystem
    {
        event Action OnDeath; 
        event Action<int> OnDamageTaken;
        event Action<int> OnHealed;
        
        int MaxHealth { get; set; }
        int CurrentHealth { get; set; }
        bool IsAlive { get; set; }

        void TakeDamage(int amount);
        void Heal(int amount);

        void Death();
    }
}