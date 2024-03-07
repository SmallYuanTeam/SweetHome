using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SelectedRoom
{
    WorkRoom, // 工作室
    GuysRoom, // 弟弟房間
    BrothersRoom, // 兄長房間
    ParentsRoom,// 父母房間
    SecendFloor,// 二樓
    FirstFloor, // 一樓
    LivingRoom, // 客廳
    GuestRoom,  // 客房
    BookRoom,   // 書房
    Balcony,    // 陽台
    Kitchen,    // 廚房
    Bathroom,   // 浴室
    Gurden,     // 花園
    UtilityRoom // 雜物間
}
public enum GuysRoomItem
{
    none,
    Table,
    Drawer,
    Bed,
    Door,
    Carpet,
    Chair
}

public class GameMasterScript : MonoBehaviour
{
    public SelectedRoom SelectedRoom;
    public GuysRoomItem GuysRoomitem;
    public void Selection()
    {
        switch (GuysRoomitem)
        {
            case GuysRoomItem.Table:
                Debug.Log("You selected the table");
                break;
            case GuysRoomItem.Drawer:
                Debug.Log("You selected the drawer");
                break;
            case GuysRoomItem.Bed:
                Debug.Log("You selected the bed");
                break;
            case GuysRoomItem.Door:
                Debug.Log("You selected the door");
                break;
            case GuysRoomItem.Carpet:
                Debug.Log("You selected the carpet");
                break;
            case GuysRoomItem.Chair:
                Debug.Log("You selected the chair");
                break;
            default:
                Debug.Log("You selected nothing");
                break;
        }
    }
}