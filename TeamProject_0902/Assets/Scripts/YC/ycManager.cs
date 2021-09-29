using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ycManager : MonoBehaviour
{
    /////��Ŭ���� �÷��̾� �̵� ��ǥ/////
    public Vector3 PlayerClickedPos; //player right clicked location
    public Vector3 PlayerClickedPosMiniMap; //player right clicked location by minimap
    public bool ClickedOnMinimap = false;
    /////////////////////////////////////
    /// �÷��̾� ������ǥ
    public float PlayerDirection;
    public Vector3 PlayerTargetPos; //�÷��̾� Ÿ����ǥ
    /// �÷��̾� ��������
    public bool isFree;




    private static ycManager sInstance;
    public static ycManager Instance
    {
        get
        {
            if (sInstance == null)
            {
                GameObject newGameObj = new GameObject("ycManager");
                sInstance = newGameObj.AddComponent<ycManager>();
            }
            return sInstance;
        }
    }
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }


    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}