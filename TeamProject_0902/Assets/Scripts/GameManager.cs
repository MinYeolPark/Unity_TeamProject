using System.Collections;
<<<<<<< HEAD

using UnityEngine;
using UnityEngine.UI;

using Photon.Realtime;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class GameManager : MonoBehaviourPunCallbacks
{
	public static GameManager Instance = null;

	public GameObject PlayerPrefabs;            //set random champion

    #region UNITY

    public void Awake()
    {
        Instance = this;
    }

    #endregion

    #region PUN CALLBACKS

    public override void OnDisconnected(DisconnectCause cause)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("DemoAsteroids-LobbyScene");
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.Disconnect();
    }
    #endregion
=======
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Photon.Realtime;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    // 싱글톤 패턴을 사용하기 위한 인스턴스 변수
    private static GameManager _instance;
    // 인스턴스에 접근하기 위한 프로퍼티
    public static GameManager Instance
    {
        get
        {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당해준다.
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        // 인스턴스가 존재하는 경우 새로생기는 인스턴스를 삭제한다.
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        // 아래의 함수를 사용하여 씬이 전환되더라도 선언되었던 인스턴스가 파괴되지 않는다.
        DontDestroyOnLoad(gameObject);
    }

    public GameObject[] redSpawns;
    public GameObject[] blueSpawns;

    public int state = 0;

    void Connect()
    {
        PhotonNetwork.ConnectToBestCloudServer();
    }

    private void OnConnectedToServer()
    {
        state = 1;
    }


    private void OnGUI()
    {
        switch(state)
        {
            case 0:
                {
                    Debug.Log("버튼생성");
                    if (GUI.Button(new Rect(10, 10, 100, 30), "Connect"))
                    {
                        Connect();
                    }
                    break;
                }
            case 1:
                {
                    GUI.Label(new Rect(10,10,100,30),"Connected");
                    break;
                }
        }
    }
>>>>>>> 78e8db30eaf0cddb9bd88a0879750ab762656bb6
}
