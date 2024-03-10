using System.Collections.Generic;
using UnityEngine;

public enum SelectedRoom
{
    WorkRoom, // 工作室
    GuysRoom, // 弟弟房間
    GuysTable, // 弟弟桌子
    GuysGarderobe, // 弟弟衣櫃
    GuysCarpet, // 弟弟地毯
    GuysBed, // 弟弟床
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
public enum GuysTableItem // 完成
{
    none,
    Light,
    Return
}
public enum GuysGarderobeItem
{
    none,
    Garderobe,
    Pant,
    Return
}
public enum GuysCarpetItem // 完成
{
    none,
    Carpet,
    Clothes,
    Return
}
public enum GuysBedItem
{
    none,
    Bed,
    Puppet,
    Glass,
    Return
}
public class GameMasterScript : MonoBehaviour
{
    public SceneManagerHelper sceneManagerHelper;
    public SelectedRoom SelectedRoom;
    public GuysRoomItem GuysRoomItem;
    public GuysTableItem GuysTableItem;
    public GuysGarderobeItem GuysGarderobeItem;
    public GuysCarpetItem GuysCarpetItem;
    public GuysBedItem GuysBedItem;

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
                    List<string> GuysBedScene = new List<string> {"GuysBed"};
                    sceneManagerHelper.LoadSceneWithTransition(GuysBedScene);
                    SelectedRoom = SelectedRoom.GuysBed;
                    break;
                case GuysRoomItem.Door:
                    Debug.Log("You selected the door");
                    //dayOneDialog.GetRoomItem("Door");
                    break;
                case GuysRoomItem.Carpet:
                    Debug.Log("You selected the carpet");
                    List<string> GuysCarpetScene = new List<string> {"GuysCarpet"};
                    sceneManagerHelper.LoadSceneWithTransition(GuysCarpetScene);
                    SelectedRoom = SelectedRoom.GuysCarpet;
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
        else if (SelectedRoom == SelectedRoom.GuysCarpet)
        {
            switch (GuysCarpetItem)
            {
                case GuysCarpetItem.Carpet:
                    Debug.Log("You selected the carpet");
                    SelectedObject = GameObject.Find("Carpet");
                    if (SelectedObject != null)
                    {
                        interactScript = SelectedObject.GetComponent<CanInteractAgain>();
                    }
                    break;
                case GuysCarpetItem.Return:
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
        else if (SelectedRoom == SelectedRoom.GuysBed)
        {
            switch (GuysBedItem)
            {
                case GuysBedItem.Bed:
                    Debug.Log("You selected the bed");
                    SelectedObject = GameObject.Find("Bed");
                    if (SelectedObject != null)
                    {
                        interactScript = SelectedObject.GetComponent<CanInteractAgain>();
                    }
                    break;
                case GuysBedItem.Puppet:
                    Debug.Log("You selected the puppet");
                    dayOneDialog.GetRoomItem("Puppet");
                    break;
                case GuysBedItem.Glass:
                    Debug.Log("You selected the glass");
                    dayOneDialog.GetRoomItem("Glass");
                    break;
                case GuysBedItem.Return:
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