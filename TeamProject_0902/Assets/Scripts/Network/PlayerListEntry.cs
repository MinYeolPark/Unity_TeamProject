using UnityEngine;
using UnityEngine.UI;

using ExitGames.Client.Photon;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;
using Photon.Pun;


public class PlayerListEntry : MonoBehaviour
{
<<<<<<< HEAD
    public PhotonView PV;
    public int playerTeam;
=======
>>>>>>> 78e8db30eaf0cddb9bd88a0879750ab762656bb6
    [Header("UI References")]
    public Text PlayerNameText;

    public Image PlayerChampImage;
    public Button PlayerReadyButton;
    public Image PlayerReadyImage;

    private int ownerId;
    private bool isPlayerReady;

    #region UNITY

    public void OnEnable()
    {
<<<<<<< HEAD
        PV = GetComponent<PhotonView>();
=======
>>>>>>> 78e8db30eaf0cddb9bd88a0879750ab762656bb6
        PlayerNumbering.OnPlayerNumberingChanged += OnPlayerNumberingChanged;
    }

    public void Start()
    {
        if (PhotonNetwork.LocalPlayer.ActorNumber != ownerId)
        {
            PlayerReadyButton.gameObject.SetActive(false);
        }
        else
        {
            Hashtable initialProps = new Hashtable() { { GameConsts.PLAYER_READY, isPlayerReady }};
            PhotonNetwork.LocalPlayer.SetCustomProperties(initialProps);
<<<<<<< HEAD
=======
            PhotonNetwork.LocalPlayer.SetScore(0);
>>>>>>> 78e8db30eaf0cddb9bd88a0879750ab762656bb6

            PlayerReadyButton.onClick.AddListener(() =>
            {
                isPlayerReady = !isPlayerReady;
                SetPlayerReady(isPlayerReady);

                Hashtable props = new Hashtable() { { GameConsts.PLAYER_READY, isPlayerReady } };
                PhotonNetwork.LocalPlayer.SetCustomProperties(props);

                if (PhotonNetwork.IsMasterClient)
                {
                    FindObjectOfType<LobbyManager>().LocalPlayerPropertiesUpdated();
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
        foreach (Photon.Realtime.Player p in PhotonNetwork.PlayerList)
        {
            if (p.ActorNumber == ownerId)
            {
                //Champion Select with On player Number.
            }
        }
    }

    public void SetPlayerReady(bool playerReady)
    {
        PlayerReadyButton.GetComponentInChildren<Text>().text = playerReady ? "Ready!" : "Ready?";
        PlayerReadyImage.enabled = playerReady;
    }
}
