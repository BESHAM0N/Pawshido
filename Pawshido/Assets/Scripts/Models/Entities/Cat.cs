using System;
using Enums;
using Systems;
using UnityEngine;

namespace Models
{
    public sealed class Cat : IEntity, IHealthSystem, IAttackSystem
    {
        public event Action OnDeath;
        public event Action<int> OnDamageTaken;
        public event Action<int> OnHealed;

        public int Id { get; set; }
        public string Name { get; set; }
        public GameRoles GameRole { get; set; }
        public Vector3 Position { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public bool IsAlive { get; set; }
        
        public void TakeDamage(int amount)
        {
            if (CurrentHealth > 0)
            {
                CurrentHealth -= amount;
            }
        }

        public void Heal(int amount)
        {
            CurrentHealth += amount;
        }

        public void Death()
        {
            throw new NotImplementedException();
        }

        public int Damage { get; set; }

        public Cat()
        {
            Id = 0;
            Name = "Pawshido";
            GameRole = GameRoles.Cat;
            Position = new Vector3(0, 0, 0);
            MaxHealth = 100;
            CurrentHealth = MaxHealth;
            IsAlive = true;
            Damage = 50;
        }
        
        public void OnAttack(IEntity enemy)
        {
            
        }
        
    }
}