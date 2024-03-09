using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;
public enum SelectedRoom
{
    WorkRoom, // 工作室
    GuysRoom, // 弟弟房間
    GuysTable, // 弟弟桌子
    GuysGarderobe, // 弟弟衣櫃
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
    Garderobe,
    Bed,
    Door,
    Carpet,
    Chair,
    GarbageCan
}
public enum GuysTableItem
{
    none,
    Light,
    Return
}
public enum GuysGarderobeItem
{
    none,
    Garderobe,
    Return
}

public class GameMasterScript : MonoBehaviour
{
    public SceneManagerHelper sceneManagerHelper;
    public SelectedRoom SelectedRoom;
    public GuysRoomItem GuysRoomItem;
    public GuysTableItem GuysTableItem;
    public GuysGarderobeItem GuysGarderobeItem;
    DayOneDialog dayOneDialog;


    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        dayOneDialog = GameObject.Find("DayOneDialog").GetComponent<DayOneDialog>();
        sceneManagerHelper = FindObjectOfType<SceneManagerHelper>();

        
        List<string> scenesToLoad = new List<string> {"GuysRoom"};
        sceneManagerHelper.LoadSceneWithTransition(scenesToLoad);
    }
    
    public void Selection()
    {
        GameObject SelectedObject = null;
        CanInteractAgain interactScript = null;
        if (SelectedRoom == SelectedRoom.GuysRoom)
        {
            switch (GuysRoomItem)
            {
                case GuysRoomItem.Table:
                    Debug.Log("You selected the table");
                    List<string> GuysTableScene = new List<string> {"GuysTable"};
                    sceneManagerHelper.LoadSceneWithTransition(GuysTableScene);
                    SelectedRoom = SelectedRoom.GuysTable;
                    break;
                case GuysRoomItem.Garderobe:
                    Debug.Log("You selected the Garderobe");
                    List<string> GuysGarderobeScene = new List<string> {"GuysGarderobe"};
                    sceneManagerHelper.LoadSceneWithTransition(GuysGarderobeScene);
                    SelectedRoom = SelectedRoom.GuysGarderobe;
                    break;
                case GuysRoomItem.Bed:
                    Debug.Log("You selected the bed");
                    dayOneDialog.GetRoomItem("Bed");
                    break;
                case GuysRoomItem.Door:
                    Debug.Log("You selected the door");
                    //dayOneDialog.GetRoomItem("Door");
                    break;
                case GuysRoomItem.Carpet:
                    Debug.Log("You selected the carpet");
                    //dayOneDialog.GetRoomItem("Carpet");
                    break;
                case GuysRoomItem.Chair:
                    Debug.Log("You selected the chair");
                    dayOneDialog.GetRoomItem("Chair");
                    break;
                case GuysRoomItem.GarbageCan:
                    Debug.Log("You selected the garbage can");
                    dayOneDialog.GetRoomItem("GarbageCan");
                    break;
                default:
                    Debug.Log("You selected nothing");
                    break;
            }
        }
        else if (SelectedRoom == SelectedRoom.GuysTable)
        {
            switch (GuysTableItem)
            {
                case GuysTableItem.Light:
                    Debug.Log("You selected the light");
                    break;
                case GuysTableItem.Return:
                    Debug.Log("You selected the return");
                    List<string> GuyRoomScenes = new List<string> {"GuysRoom"};
                    sceneManagerHelper.LoadSceneWithTransition(GuyRoomScenes);
                    SelectedRoom = SelectedRoom.GuysRoom;
                    break;
                default:
                    Debug.Log("You selected nothing");
                    break;
            }
        }
        else if (SelectedRoom == SelectedRoom.GuysGarderobe)
        {
            switch (GuysGarderobeItem)
            {
                case GuysGarderobeItem.Garderobe:
                    Debug.Log("You selected the Garderobe");
                    SelectedObject = GameObject.Find("Garderobe");
                    if (SelectedObject != null)
                    {
                        interactScript = SelectedObject.GetComponent<CanInteractAgain>();
                    }
                    break;
                case GuysGarderobeItem.Return:
                    Debug.Log("You selected the return");
                    List<string> GuyRoomScenes = new List<string> {"GuysRoom"};
                    sceneManagerHelper.LoadSceneWithTransition(GuyRoomScenes);
                    SelectedRoom = SelectedRoom.GuysRoom;
                    break;
                default:
                    Debug.Log("You selected nothing");
                    break;
            }
        }
        if (interactScript != null)
        {
            interactScript.Interact();
        }
    }
}