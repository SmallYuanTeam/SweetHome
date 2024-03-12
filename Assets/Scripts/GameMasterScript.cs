using System.Collections.Generic;
using UnityEngine;

public enum SelectedRoom
{
    WorkRoom,       // 工作室
    GuysRoom,       // 弟弟房間
    GuysTable,      // 弟弟桌子
    GuysGarderobe,  // 弟弟衣櫃
    GuysCarpet,     // 弟弟地毯
    GuysBed,        // 弟弟床
    SecondFloor,    // 二樓
    BrothersRoom,   // 兄長房間
    ParentsRoom,    // 父母房間
    FirstFloor,     // 一樓
    LivingRoom,     // 客廳
    UtilityRoom,    // 雜物間
    GuestRoom,      // 客房
    BookRoom,       // 書房
    Balcony,        // 陽台
    Kitchen,        // 廚房
    Bathroom,       // 浴室
    Gurden          // 花園
    
}
public enum GuysRoomItem // 完成
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
public enum GuysGarderobeItem // 完成
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
public enum GuysBedItem // 完成
{
    none,
    Bed,
    Puppet,
    Glass,
    Return
}
public enum SecondFloorItem // 完成
{
    none,
    BrothersRoomDoor,
    ParentsRoomDoor,
    GuestRoomDoor,
    StudyRoomDoor,
    GuysRoomDoor,
    FirstFloorDoor
}
public enum FirstFloorItem
{
    none,
    SecondFloorDoor,
    UtilityRoomDoor,
    ShoeBox,
    RestRoomDoor,
    GateExit,
    Carpet,
    LivingRoomDoor
}
public enum LivingRoomItem
{
    none,
    TV,
    Cabinet,
    ToyBox,
    TVCabinet,
    Table,
    Sofa,
    FirstFloorDoor
}
public enum UtilityRoom
{
    none,
    FirstFloorDoor
}

public enum BrothersRoomItem
{
    none
}
public enum ParentsRoomItem
{
    none
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
    public SecondFloorItem SecondFloorItem;
    public FirstFloorItem FirstFloorItem;
    public LivingRoomItem LivingRoomItem;
    public UtilityRoom UtilityRoom;

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
                    List<string> SecondFloorScenes = new List<string> {"SecondFloor"};
                    sceneManagerHelper.LoadSceneWithTransition(SecondFloorScenes);
                    SelectedRoom = SelectedRoom.SecondFloor;
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
        else if (SelectedRoom == SelectedRoom.SecondFloor)
        {
            switch (SecondFloorItem)
            {
                case SecondFloorItem.BrothersRoomDoor:
                    Debug.Log("You selected the brothers room door");
                    List<string> BrothersRoomScenes = new List<string> {"BrothersRoom"};
                    sceneManagerHelper.LoadSceneWithTransition(BrothersRoomScenes);
                    SelectedRoom = SelectedRoom.BrothersRoom;
                    break;
                case SecondFloorItem.ParentsRoomDoor:
                    Debug.Log("You selected the parents room door");
                    List<string> ParentsRoomScenes = new List<string> {"ParentsRoom"};
                    sceneManagerHelper.LoadSceneWithTransition(ParentsRoomScenes);
                    SelectedRoom = SelectedRoom.ParentsRoom;
                    break;
                case SecondFloorItem.GuestRoomDoor:
                    Debug.Log("You selected the guest room door");
                    List<string> GuestRoomScenes = new List<string> {"GuestRoom"};
                    sceneManagerHelper.LoadSceneWithTransition(GuestRoomScenes);
                    SelectedRoom = SelectedRoom.GuestRoom;
                    break;
                case SecondFloorItem.StudyRoomDoor:
                    Debug.Log("You selected the study room door");
                    List<string> StudyRoomScenes = new List<string> {"StudyRoom"};
                    sceneManagerHelper.LoadSceneWithTransition(StudyRoomScenes);
                    SelectedRoom = SelectedRoom.BookRoom;
                    break;
                case SecondFloorItem.GuysRoomDoor:
                    Debug.Log("You selected the guys room door");
                    List<string> GuysRoomScenes = new List<string> {"GuysRoom"};
                    sceneManagerHelper.LoadSceneWithTransition(GuysRoomScenes);
                    SelectedRoom = SelectedRoom.GuysRoom;
                    break;
                case SecondFloorItem.FirstFloorDoor:
                    Debug.Log("You selected the first floor door");
                    List<string> FirstFloorScenes = new List<string> {"FirstFloor"};
                    sceneManagerHelper.LoadSceneWithTransition(FirstFloorScenes);
                    SelectedRoom = SelectedRoom.FirstFloor;
                    break;
                default:
                    Debug.Log("You selected nothing");
                    break;
            }
        }
        else if (SelectedRoom == SelectedRoom.FirstFloor)
        {
            switch (FirstFloorItem)
            {
                case FirstFloorItem.SecondFloorDoor:
                    Debug.Log("You selected the second floor door");
                    List<string> SecondFloorScenes = new List<string> {"SecondFloor"};
                    sceneManagerHelper.LoadSceneWithTransition(SecondFloorScenes);
                    SelectedRoom = SelectedRoom.SecondFloor;
                    break;
                case FirstFloorItem.UtilityRoomDoor:
                    Debug.Log("You selected the utility room door");
                    List<string> UtilityRoomScenes = new List<string> {"UtilityRoom"};
                    sceneManagerHelper.LoadSceneWithTransition(UtilityRoomScenes);
                    SelectedRoom = SelectedRoom.UtilityRoom;
                    break;
                case FirstFloorItem.ShoeBox:
                    Debug.Log("You selected the shoe box");
                    dayOneDialog.GetRoomItem("ShoeBox");
                    break;
                case FirstFloorItem.RestRoomDoor:
                    Debug.Log("You selected the rest room door");
                    dayOneDialog.GetRoomItem("RestRoomDoor");
                    break;
                case FirstFloorItem.GateExit:
                    Debug.Log("You selected the gate exit");
                    dayOneDialog.GetRoomItem("GateExit");
                    break;
                case FirstFloorItem.Carpet:
                    Debug.Log("You selected the carpet");
                    dayOneDialog.GetRoomItem("Carpet");
                    break;
                case FirstFloorItem.LivingRoomDoor:
                    Debug.Log("You selected the living room door");
                    List<string> LivingRoomScenes = new List<string> {"LivingRoom"};
                    sceneManagerHelper.LoadSceneWithTransition(LivingRoomScenes);
                    SelectedRoom = SelectedRoom.LivingRoom;
                    break;
                default:
                    Debug.Log("You selected nothing");
                    break;
            }
        }
        else if (SelectedRoom == SelectedRoom.LivingRoom)
        {
            switch (LivingRoomItem)
            {
                case LivingRoomItem.TV:
                    Debug.Log("You selected the TV");
                    dayOneDialog.GetRoomItem("TV");
                    break;
                case LivingRoomItem.Cabinet:
                    Debug.Log("You selected the cabinet");
                    dayOneDialog.GetRoomItem("Cabinet");
                    break;
                case LivingRoomItem.ToyBox:
                    Debug.Log("You selected the toy box");
                    dayOneDialog.GetRoomItem("ToyBox");
                    break;
                case LivingRoomItem.TVCabinet:
                    Debug.Log("You selected the TV cabinet");
                    dayOneDialog.GetRoomItem("TVCabinet");
                    break;
                case LivingRoomItem.Table:
                    Debug.Log("You selected the table");
                    dayOneDialog.GetRoomItem("Table");
                    break;
                case LivingRoomItem.Sofa:
                    Debug.Log("You selected the sofa");
                    dayOneDialog.GetRoomItem("Sofa");
                    break;
                case LivingRoomItem.FirstFloorDoor:
                    Debug.Log("You selected the first floor door");
                    List<string> FirstFloorScenes = new List<string> {"FirstFloor"};
                    sceneManagerHelper.LoadSceneWithTransition(FirstFloorScenes);
                    SelectedRoom = SelectedRoom.FirstFloor;
                    break;
                default:
                    Debug.Log("You selected nothing");
                    break;
            }
        }
        else if (SelectedRoom == SelectedRoom.UtilityRoom)
        {
            switch (UtilityRoom)
            {
                case UtilityRoom.FirstFloorDoor:
                    Debug.Log("You selected the first floor door");
                    List<string> FirstFloorScenes = new List<string> {"FirstFloor"};
                    sceneManagerHelper.LoadSceneWithTransition(FirstFloorScenes);
                    SelectedRoom = SelectedRoom.FirstFloor;
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