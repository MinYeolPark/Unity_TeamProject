using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Photon.Realtime;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    // �̱��� ������ ����ϱ� ���� �ν��Ͻ� ����
    private static GameManager _instance;
    // �ν��Ͻ��� �����ϱ� ���� ������Ƽ
    public static GameManager Instance
    {
        get
        {
            // �ν��Ͻ��� ���� ��쿡 �����Ϸ� �ϸ� �ν��Ͻ��� �Ҵ����ش�.
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
        // �ν��Ͻ��� �����ϴ� ��� ���λ���� �ν��Ͻ��� �����Ѵ�.
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        // �Ʒ��� �Լ��� ����Ͽ� ���� ��ȯ�Ǵ��� ����Ǿ��� �ν��Ͻ��� �ı����� �ʴ´�.
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
                    Debug.Log("��ư����");
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
}
