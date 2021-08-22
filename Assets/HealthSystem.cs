 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeRoom
{
    public class HealthSystem
    {
        public float CurrentHealth;
        public float TotalHealth = 100;
        public HealthSystem(int health)
        {
            TotalHealth = health;
            ResetHealth();
        }

        public float GetHealth()
        {
            return CurrentHealth;
        }

        public float GetHealthPercentage()
        {
            return CurrentHealth / TotalHealth;
        }
        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth < 0)
                CurrentHealth = 0;
        }

        public void Heal(int healAmount)
        {
            CurrentHealth += healAmount;
            if (CurrentHealth > 100)
                ResetHealth();
        }

        public void ResetHealth()
        {
            CurrentHealth = TotalHealth;
        }

    }

}
