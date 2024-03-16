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
    LivingRoom_Sofa, // 客廳沙發
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
    Bottle,
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
public enum LivingRoom_SofaItem
{
    none,
    Sofa,
    Pillow,
    Key,
    Return
}
public enum UtilityRoomItem
{
    none,
    Broom,
    TowelRack,
    VacuumCleaner,
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
    public GameObject InventoryPanel;
    public SelectedRoom SelectedRoom;
    public GuysRoomItem GuysRoomItem;
    public GuysTableItem GuysTableItem;
    public GuysGarderobeItem GuysGarderobeItem;
    public GuysCarpetItem GuysCarpetItem;
    public GuysBedItem GuysBedItem;
    public SecondFloorItem SecondFloorItem;
    public FirstFloorItem FirstFloorItem;
    public LivingRoomItem LivingRoomItem;
    public LivingRoom_SofaItem LivingRoom_SofaItem;
    public Pillow Pillow;
    public UtilityRoomItem UtilityRoomItem;

    Dialog Dialog;


    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        Dialog = GameObject.Find("Dialog").GetComponent<Dialog>();
        sceneManagerHelper = FindObjectOfType<SceneManagerHelper>();

        
        List<string> scenesToLoad = new List<string> {"MainMenu"};
        sceneManagerHelper.LoadSceneWithTransition(scenesToLoad);
    }
    public void InventoryPanelActive()
    {
        if (InventoryPanel.activeSelf)
        {
            InventoryPanel.SetActive(false);
        }
        else
        {
            InventoryPanel.SetActive(true);
        }
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
                    List<string> GuysTableScene = new List<string> {"GuysRoom_Table"};
                    sceneManagerHelper.LoadSceneWithTransition(GuysTableScene);
                    SelectedRoom = SelectedRoom.GuysTable;
                    break;
                case GuysRoomItem.Garderobe:
                    Debug.Log("You selected the Garderobe");
                    List<string> GuysGarderobeScene = new List<string> {"GuysRoom_Garderobe"};
                    sceneManagerHelper.LoadSceneWithTransition(GuysGarderobeScene);
                    SelectedRoom = SelectedRoom.GuysGarderobe;
                    break;
                case GuysRoomItem.Bed:
                    Debug.Log("You selected the bed");
                    List<string> GuysBedScene = new List<string> {"GuysRoom_Bed"};
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
                    List<string> GuysCarpetScene = new List<string> {"GuysRoom_Carpet"};
                    sceneManagerHelper.LoadSceneWithTransition(GuysCarpetScene);
                    SelectedRoom = SelectedRoom.GuysCarpet;
                    break;
                case GuysRoomItem.Chair:
                    Debug.Log("You selected the chair");
                    Dialog.GetRoomItem("GuysRoom","Chair");
                    break;
                case GuysRoomItem.GarbageCan:
                    Debug.Log("You selected the garbage can");
                    Dialog.GetRoomItem("GuysRoom","GarbageCan");
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
                    Debug.Log("You selected the FlashLight");
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
                    Dialog.GetRoomItem("GuysBed","Puppet");
                    break;
                case GuysBedItem.Bottle:
                    Debug.Log("You selected the Bottle");
                    Dialog.GetRoomItem("GuysBed","Bottle");
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
                    break;
                case FirstFloorItem.RestRoomDoor:
                    Debug.Log("You selected the rest room door");
                    Dialog.GetRoomItem("FirstFloor","RestRoomDoor");
                    break;
                case FirstFloorItem.GateExit:
                    Debug.Log("You selected the gate exit");
                    Dialog.GetRoomItem("FirstFloor","GateExit");
                    break;
                case FirstFloorItem.Carpet:
                    Debug.Log("You selected the carpet");
                    Dialog.GetRoomItem("FirstFloor","Carpet");
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
                    Dialog.GetRoomItem("LivingRoom","TV");
                    break;
                case LivingRoomItem.Cabinet:
                    Debug.Log("You selected the cabinet");
                    Dialog.GetRoomItem("LivingRoom","Cabinet");
                    break;
                case LivingRoomItem.ToyBox:
                    Debug.Log("You selected the toy box");
                    Dialog.GetRoomItem("LivingRoom","ToyBox");
                    break;
                case LivingRoomItem.TVCabinet:
                    Debug.Log("You selected the TV cabinet");
                    Dialog.GetRoomItem("LivingRoom","TVCabinet");
                    break;
                case LivingRoomItem.Table:
                    Debug.Log("You selected the table");
                    Dialog.GetRoomItem("LivingRoom","Table");
                    break;
                case LivingRoomItem.Sofa:
                    Debug.Log("You selected the sofa");
                    List<string> LivingRoom_SofaScenes = new List<string> {"LivingRoom_Sofa"};
                    sceneManagerHelper.LoadSceneWithTransition(LivingRoom_SofaScenes);
                    SelectedRoom = SelectedRoom.LivingRoom_Sofa;
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
        else if (SelectedRoom == SelectedRoom.LivingRoom_Sofa)
        {
            switch (LivingRoom_SofaItem)
            {
                case LivingRoom_SofaItem.Sofa:
                    Debug.Log("You selected the sofa");
                    Dialog.GetRoomItem("LivingRoom_Sofa","Sofa");
                    break;
                case LivingRoom_SofaItem.Pillow:
                    Debug.Log("You selected the pillow");
                    Pillow.OnPillowClick();
                    break;
                case LivingRoom_SofaItem.Key:
                    Debug.Log("You selected the key");
                    Dialog.GetRoomItem("LivingRoom_Sofa","Key");
                    break;
                case LivingRoom_SofaItem.Return:
                    Debug.Log("You selected the return");
                    List<string> LivingRoomScenes = new List<string> {"LivingRoom"};
                    sceneManagerHelper.LoadSceneWithTransition(LivingRoomScenes);
                    SelectedRoom = SelectedRoom.LivingRoom;
                    break;
                default:
                    Debug.Log("You selected nothing");
                    break;
            }
        }
        else if (SelectedRoom == SelectedRoom.UtilityRoom)
        {
            switch (UtilityRoomItem)
            {
                case UtilityRoomItem.FirstFloorDoor:
                    Debug.Log("You selected the first floor door");
                    List<string> FirstFloorScenes = new List<string> {"FirstFloor"};
                    sceneManagerHelper.LoadSceneWithTransition(FirstFloorScenes);
                    SelectedRoom = SelectedRoom.FirstFloor;
                    break;
                case UtilityRoomItem.Broom:
                    Debug.Log("You selected the broom");
                    Dialog.GetRoomItem("UtilityRoom","Broom");
                    break;
                case UtilityRoomItem.TowelRack:
                    Debug.Log("You selected the towel rack");
                    break;
                case UtilityRoomItem.VacuumCleaner:
                    Debug.Log("You selected the vacuum cleaner");
                    Dialog.GetRoomItem("UtilityRoom","VacuumCleaner");
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