using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{
    public Button join;
    public Text title, num, status;

    public RoomListPanel roomListPanel;

    void Start()
    {
        join.onClick.AddListener(OnJoinClick);
    }
    public void OnJoinClick()
    {
        roomListPanel.JoinRoom(title.text);
    }
    public void SetRoomInfo(string title, int curnum,int maxnum, int status)
    {
        this.title.text = title;
        this.num.text = curnum +"/"+ maxnum;
        switch(status)
        {
            case 0:
                this.status.text = "Waiting...";
                break;
            case 1:
                this.status.text = "Full";
                break;
            case 2:
                this.status.text = "Gaming";
                break;
            default:
                this.status.text = "???";
                break;
        }
    }
}
