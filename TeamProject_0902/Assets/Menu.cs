using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private AoW_Launcher launcher;

    public string nickName;
    public string menuName;
    public bool open;
    private void Awake()
    {
        nickName = launcher.nameInput.text.ToString();
    }
    public void Open()
    {
        open = true;
        gameObject.SetActive(true);//Ư�� �޴� ������
    }

    public void Close()
    {
        open = false;
        gameObject.SetActive(false);
    }

    public void OnClickCreateRoomButton()
    {
        Debug.Log("Create Room!!");
        if(nickName!="")
        {
            Debug.Log("User Name : " + nickName);
        }
        Debug.Log(nickName);
    }
}
