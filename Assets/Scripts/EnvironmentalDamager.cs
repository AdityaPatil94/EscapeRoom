using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeRoom
{
    public class EnvironmentalDamager : MonoBehaviour
    {
        //public bool startDamage;
        public PlayerHealthHandler[] healthHandlerList;
        public PlayerHealthHandler handler;
        public float DamageAmount;
        public float StartTime, CurrentTime, IntervalTime = 5;
        public bool ShouldStartDamage;

        private void Start()
        {
            Invoke("GetPLayerHealth",5);
            CurrentTime = StartTime;
        }

        private void Update()
        {
            DoDamage();
        }
        public void DoDamage()
        {
            if(ShouldStartDamage)
            {
                CurrentTime += Time.deltaTime;
                CheckTimeInterval();
            }
        }

        public void CheckTimeInterval()
        {
            float timeDifference = CurrentTime - StartTime;
            if(timeDifference >= IntervalTime)
            {
                CurrentTime = StartTime;
                handler.TakeDamage(DamageAmount);
            }
        }
        public void GetPLayerHealth()
        {
            healthHandlerList = FindObjectsOfType<PlayerHealthHandler>();

            foreach(PlayerHealthHandler pHandler in healthHandlerList )
            {
                if(pHandler.IsLocalPlayerHealth)
                {
                    handler = pHandler;
                    return;
                }
            }
        }

        public void ShouldDamageStatus(bool Val)
        {
            ShouldStartDamage = Val;
        }
    }

}

