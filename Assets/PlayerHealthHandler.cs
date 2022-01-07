using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace EscapeRoom
{
    public class PlayerHealthHandler : MonoBehaviourPunCallbacks
    {
        public HealthSystem HealthSystem;
        public int TotalHealth;
        public int[] randomHealthList;
        public bool IsLocalPlayerHealth;
        public string DeathTrigger;
        //public GameObject HealthUIParent;

        private UIHealthHandler uIHealthHandler;
        private UIHealthHandler[] UIHealthHandlerList;
        float healthPercentage;
        private PhotonView pv;
        private Animator anim;
        private void Awake()
        {
            pv = GetComponent<PhotonView>();
        }
        void Start()
        {
            int random = Random.Range(0,3);
            Debug.Log(random);
            TotalHealth = randomHealthList[random];
            HealthSystem = new HealthSystem(TotalHealth);
            HealthSystem.OnPlayerDeath += PlayDeathAnimation;
            uIHealthHandler = GetHealthUI();
            if(pv.IsMine)
            {
                IsLocalPlayerHealth = true;
            }
            //Invoke("TestDamage",5);
        }

        private void PlayDeathAnimation()
        {
            if (pv.IsMine)
            {
                GetComponentInChildren<CharacterController>().enabled = false;
                anim = GetComponentInChildren<Animator>();
                anim.SetTrigger(DeathTrigger);
            }
        }

        //[PunRPC]
        //public void RPC_TakeDamage(int damage)
        //{
        //    Debug.Log("Took Damage");
        //    if (!pv.IsMine)
        //        return;
        //    HealthSystem.TakeDamage(damage);
        //    healthPercentage = HealthSystem.GetHealthPercentage();
        //    if (uIHealthHandler != null)
        //        uIHealthHandler.RefreshHealthBar(healthPercentage);
        //}
        public void TakeDamage(float damage)
        {
            Debug.Log("Took Damage");
            HealthSystem.TakeDamage(damage);
            //pv.RPC("RPC_TakeDamage", RpcTarget.All, damage);
            healthPercentage = HealthSystem.GetHealthPercentage();
            if (uIHealthHandler != null)
                uIHealthHandler.RefreshHealthBar(healthPercentage);
        }

        //[PunRPC]
        //public void RPC_Heal(int heal)
        //{
        //    HealthSystem.Heal(heal);
        //    healthPercentage = HealthSystem.GetHealthPercentage();
        //    if (uIHealthHandler != null)
        //        uIHealthHandler.RefreshHealthBar(healthPercentage);
        //} 
        public void Heal(int heal)
        {
            HealthSystem.Heal(heal);
            healthPercentage = HealthSystem.GetHealthPercentage();
            if (uIHealthHandler != null)
                uIHealthHandler.RefreshHealthBar(healthPercentage);
        }

        public UIHealthHandler GetHealthUI()
        {
            UIHealthHandlerList = FindObjectsOfType<UIHealthHandler>();
            foreach(UIHealthHandler handler in UIHealthHandlerList)
            {
                //handler.transform.SetParent(HealthUIParent.transform);
                if (handler.IsLocalHealthUI)
                    return handler;
            }
            return null;
        }

        private void OnDisable()
        {
            HealthSystem.OnPlayerDeath -= PlayDeathAnimation;
        }
    }

}
