 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeRoom
{
    public delegate void PlayerDeath();
    public class HealthSystem
    {
        public float CurrentHealth;
        public float TotalHealth = 100;
        public static event PlayerDeath OnPlayerDeath;
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

            return 1 - (CurrentHealth / TotalHealth);
        }
        public void TakeDamage(float damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth < 0)
            {
                CurrentHealth = 0;
                if( OnPlayerDeath !=null)
                {
                    OnPlayerDeath.Invoke();
                }
            }
                
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
