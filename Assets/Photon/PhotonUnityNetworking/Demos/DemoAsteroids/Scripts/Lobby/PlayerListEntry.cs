// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayerListEntry.cs" company="Exit Games GmbH">
//   Part of: Asteroid Demo,
// </copyright>
// <summary>
//  Player List Entry
// </summary>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;

using ExitGames.Client.Photon;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;

namespace Photon.Pun.Demo.Asteroids
{
    public class PlayerListEntry : MonoBehaviour
    {
        [Header("UI References")]
        public Text PlayerNameText;

        public Image PlayerColorImage;
        public GameObject[] PlayerReadyButtonList;
        public Button PlayerReadyButton;
        public Image PlayerReadyImage;
        public Sprite ReadyImage;
        public Sprite WaitingImage;
        public Image TickMark;

        public string Ready = "PlayerReady";
        private int ownerId;
        private bool isPlayerReady;
        private bool playerReadyStatus = false;
        #region UNITY

        public void OnEnable()
        {
            PlayerNumbering.OnPlayerNumberingChanged += OnPlayerNumberingChanged;
            //PlayerReadyButtonList = GameObject.FindGameObjectsWithTag(Ready);
            //foreach(GameObject btn in PlayerReadyButtonList)
            //{
            //    PhotonView pv = btn.GetComponent<PhotonView>();
            //    if(pv.IsMine)
            //    {
            //        PlayerReadyButton = btn.GetComponent<Button>();
            //    }
            //    else
            //    {
            //        Destroy(btn);
            //    }
            //}
           //PlayerReadyButton = GameObject.FindGameObjectWithTag(Ready).GetComponent<Button>();
        }

        public void Start()
        {
            if (PhotonNetwork.LocalPlayer.ActorNumber != ownerId)
            {
                PlayerReadyButton.gameObject.SetActive(false);
            }
            else
            {
                Hashtable initialProps = new Hashtable() {{AsteroidsGame.PLAYER_READY, isPlayerReady}, {AsteroidsGame.PLAYER_LIVES, AsteroidsGame.PLAYER_MAX_LIVES}};
                PhotonNetwork.LocalPlayer.SetCustomProperties(initialProps);
                PhotonNetwork.LocalPlayer.SetScore(0);

                PlayerReadyButton.onClick.AddListener(() =>
                {
                    isPlayerReady = !isPlayerReady;
                    SetPlayerReady(isPlayerReady);
                    PlayerReadyStatus();
                    Hashtable props = new Hashtable() {{AsteroidsGame.PLAYER_READY, isPlayerReady}};
                    PhotonNetwork.LocalPlayer.SetCustomProperties(props);

                    if (PhotonNetwork.IsMasterClient)
                    {
                        FindObjectOfType<LobbyMainPanel>().LocalPlayerPropertiesUpdated();
                    }
                });
            }
        }

        public void OnDisable()
        {
            PlayerNumbering.OnPlayerNumberingChanged -= OnPlayerNumberingChanged;
        }

        #endregion

        public void Initialize(int playerId, string playerName)
        {
            ownerId = playerId;
            PlayerNameText.text = playerName;
        }

        private void OnPlayerNumberingChanged()
        {
            foreach (Player p in PhotonNetwork.PlayerList)
            {
                if (p.ActorNumber == ownerId)
                {
                    PlayerColorImage.color = AsteroidsGame.GetColor(p.GetPlayerNumber());
                }
            }
        }

        public void SetPlayerReady(bool playerReady)
        {
            PlayerReadyButton.GetComponentInChildren<Text>().text = playerReady ? "Ready!" : "Ready?";
            PlayerReadyImage.sprite = playerReady ? ReadyImage : WaitingImage;
        }

        public void PlayerReadyStatus()
        {
            playerReadyStatus = !playerReadyStatus;
            TickMark.enabled = playerReadyStatus;
        }
    }
}