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
    LivingRoom_Safe, // 客廳保險箱
    LivingRoom_Sofa, // 客廳沙發
    LivingRoom_Table, // 客廳桌子
    LivingRoom_TVCabinet, // 客廳電視櫃
    LivingRoom_TVDrawer, // 客廳電視櫃抽屜
    UtilityRoom,    // 雜物間
    UtilityRoom_Broom, // 雜物間掃把
    GuestRoom,      // 客房
    BookRoom,       // 書房
    Balcony,        // 陽台
    Kitchen,        // 廚房
    Bathroom,       // 浴室
    Gurden,          // 花園
    
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
    Window1,
    Window2,
    GuestRoomDoor,
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
    PuppetClothed,
    PuppetNotCloth,
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
public enum FirstFloorItem // 完成
{
    none,
    SecondFloorDoor,
    UtilityRoomDoor,
    ShoeBox,
    Shoe,
    RestRoomDoor,
    GateExit,
    Carpet,
    LivingRoomDoor
}
public enum LivingRoomItem // 完成
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
public enum LivingRoom_SafeItem // 完成
{
    none,
    Safe,
    P0,
    P1,
    P2,
    P3,
    P4,
    P5,
    P6,
    P7,
    P8,
    P9,
    Check,
    Backspace,
    Return
}
public enum LivingRoom_SofaItem // 完成
{
    none,
    Sofa,
    Pillow,
    Key,
    Return
}
public enum LivingRoom_TableItem // 完成
{
    none,
    PenHolder,
    Battory,
    Return
}
public enum LivingRoom_TVCabinetItem // 完成
{
    none,
    Safe,
    TVDrawer,
    Return
}
public enum LivingRoom_TVDrawerItem // 完成
{
    none,
    Scissors,
    Return
}
public enum UtilityRoomItem // 完成
{
    none,
    Broom,
    TowelRack,
    VacuumCleaner,
    FirstFloorDoor
}
public enum UtilityRoom_BroomItem 
{
    none,
    Broom,
    Car,
    Return
}
public enum BrothersRoomItem // 完成
{
    none
}
public enum ParentsRoomItem // 完成
{
    none
}
public enum GuestRoomItem // 完成
{
    none,
    Select,
    block,
    Report,
    Memory,
    Return
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
    public LivingRoom_SafeItem LivingRoom_SafeItem;
    public LivingRoom_SofaItem LivingRoom_SofaItem;
    public LivingRoom_TableItem LivingRoom_TableItem;
    public LivingRoom_TVCabinetItem LivingRoom_TVCabinetItem;
    public LivingRoom_TVDrawerItem LivingRoom_TVDrawerItem;
    public UtilityRoomItem UtilityRoomItem;
    public UtilityRoom_BroomItem UtilityRoom_BroomItem;
    public GuestRoomItem GuestRoomItem;

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
            InventoryPanel.SetActive(true);
    }
    public void InventoryPanelDeactive()
    {
        InventoryPanel.SetActive(false);
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
                case GuysRoomItem.GuestRoomDoor:
                    Debug.Log("You selected the GuestRoom Door");
                    List<string> GuestRoomScene = new List<string> {"GuestRoom"};
                    sceneManagerHelper.LoadSceneWithTransition(GuestRoomScene);
                    SelectedRoom = SelectedRoom.GuestRoom;
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
                case GuysRoomItem.Window1:
                    Debug.Log("You selected the Window1");
                    Dialog.GetRoomItem("GuysRoom","Window1");
                    break;
                case GuysRoomItem.Window2:
                    Debug.Log("You selected the Window2");
                    Dialog.GetRoomItem("GuysRoom","Window2");
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
                    Dialog.GetRoomItem("GuysTable","FlashLight");
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
                case GuysGarderobeItem.Pant:
                    Debug.Log("You selected the pant");
                    Dialog.GetRoomItem("GuysGarderobe","Pant");
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
                case GuysCarpetItem.Clothes:
                    Debug.Log("You selected the clothes");
                    Dialog.GetRoomItem("GuysCarpet","Clothes");
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
                case GuysBedItem.PuppetClothed:
                    Debug.Log("You selected the puppet cloth");
                    Dialog.GetRoomItem("GuysBed","PuppetCloth");
                    break;
                case GuysBedItem.PuppetNotCloth:
                    Debug.Log("You selected the puppet not cloth");
                    Dialog.GetRoomItem("GuysBed","PuppetNotCloth");
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
                    Debug.Log("You selected brothers room door");
                    Dialog.GetRoomItem("SecondFloor","BrothersRoomDoor");
                    break;
                case SecondFloorItem.GuestRoomDoor:
                    Debug.Log("You selected Guest room door");
                    Dialog.GetRoomItem("SecondFloor","GuestRoomDoor");
                    break;
                case SecondFloorItem.StudyRoomDoor:
                    Debug.Log("You selected Study room door");
                    Dialog.GetRoomItem("SecondFloor","StudyRoomDoor");
                    break;
                case SecondFloorItem.ParentsRoomDoor:
                    Debug.Log("You selected Parents room door");
                    Dialog.GetRoomItem("SecondFloor","ParentsRoomDoor");
                    break;
                // case SecondFloorItem.BrothersRoomDoor:
                //     Debug.Log("You selected the brothers room door");
                //     List<string> BrothersRoomScenes = new List<string> {"BrothersRoom"};
                //     sceneManagerHelper.LoadSceneWithTransition(BrothersRoomScenes);
                //     SelectedRoom = SelectedRoom.BrothersRoom;
                //     break;
                // case SecondFloorItem.ParentsRoomDoor:
                //     Debug.Log("You selected the parents room door");
                //     List<string> ParentsRoomScenes = new List<string> {"ParentsRoom"};
                //     sceneManagerHelper.LoadSceneWithTransition(ParentsRoomScenes);
                //     SelectedRoom = SelectedRoom.ParentsRoom;
                //     break;
                // case SecondFloorItem.GuestRoomDoor:
                //     Debug.Log("You selected the guest room door");
                //     List<string> GuestRoomScenes = new List<string> {"GuestRoom"};
                //     sceneManagerHelper.LoadSceneWithTransition(GuestRoomScenes);
                //     SelectedRoom = SelectedRoom.GuestRoom;
                //     break;
                // case SecondFloorItem.StudyRoomDoor:
                //     Debug.Log("You selected the study room door");
                //     List<string> StudyRoomScenes = new List<string> {"StudyRoom"};
                //     sceneManagerHelper.LoadSceneWithTransition(StudyRoomScenes);
                //     SelectedRoom = SelectedRoom.BookRoom;
                //     break;
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
                case FirstFloorItem.Shoe:
                    Debug.Log("You selected the shoe");
                    Dialog.GetRoomItem("FirstFloor","Shoe");
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
                    List<string> LivingRoom_TVCabinetScenes = new List<string> {"LivingRoom_TVCabinet"};
                    sceneManagerHelper.LoadSceneWithTransition(LivingRoom_TVCabinetScenes);
                    SelectedRoom = SelectedRoom.LivingRoom_TVCabinet;
                    break;
                case LivingRoomItem.Table:
                    Debug.Log("You selected the table");
                    List<string> LivingRoomTableScenes = new List<string> {"LivingRoom_Table"};
                    sceneManagerHelper.LoadSceneWithTransition(LivingRoomTableScenes);
                    SelectedRoom = SelectedRoom.LivingRoom_Table;
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
        else if (SelectedRoom == SelectedRoom.LivingRoom_Safe)
        {
            switch (LivingRoom_SafeItem)
            {
                case LivingRoom_SafeItem.Safe:
                    Debug.Log("You selected the safe");
                    Dialog.GetRoomItem("LivingRoom_Safe","Safe");
                    break;
                case LivingRoom_SafeItem.Return:
                    Debug.Log("You selected the return");
                    List<string> LivingRoom_TVCabinetScenes = new List<string> {"LivingRoom_TVCabinet"};
                    sceneManagerHelper.LoadSceneWithTransition(LivingRoom_TVCabinetScenes);
                    SelectedRoom = SelectedRoom.LivingRoom_TVCabinet;
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
        else if (SelectedRoom == SelectedRoom.LivingRoom_Table)
        {
            switch (LivingRoom_TableItem)
            {
                case LivingRoom_TableItem.PenHolder:
                    Debug.Log("You selected the pen holder");
                    break;
                case LivingRoom_TableItem.Battory:
                    Debug.Log("You selected the battory");
                    Dialog.GetRoomItem("LivingRoom","Battory");
                    break;
                case LivingRoom_TableItem.Return:
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
        else if (SelectedRoom == SelectedRoom.LivingRoom_TVCabinet)
        {
            switch (LivingRoom_TVCabinetItem)
            {
                case LivingRoom_TVCabinetItem.Return:
                    Debug.Log("You selected the return");
                    List<string> LivingRoomScenes = new List<string> {"LivingRoom"};
                    sceneManagerHelper.LoadSceneWithTransition(LivingRoomScenes);
                    SelectedRoom = SelectedRoom.LivingRoom;
                    break;
                case LivingRoom_TVCabinetItem.Safe:
                    Debug.Log("You selected the safe");
                    List<string> LivingRoomSafeScenes = new List<string> {"LivingRoom_Safe"};
                    sceneManagerHelper.LoadSceneWithTransition(LivingRoomSafeScenes);
                    SelectedRoom = SelectedRoom.LivingRoom_Safe;
                    break;
                case LivingRoom_TVCabinetItem.TVDrawer:
                    Debug.Log("You selected the TV drawer");
                    //如果玩家身上有鑰匙
                    if (Player.Instance.HasObtainedItem("Key"))
                    {
                        List<string> LivingRoomTVDrawerScenes = new List<string> {"LivingRoom_TVDrawer"};
                        sceneManagerHelper.LoadSceneWithTransition(LivingRoomTVDrawerScenes);
                        SelectedRoom = SelectedRoom.LivingRoom_TVDrawer;
                    }
                    else
                    {
                        Dialog.GetRoomItem("LivingRoom_TVCabinet","TVDrawer");
                    }
                    break;
                default:
                    Debug.Log("You selected nothing");
                    break;
            }
        }
        else if (SelectedRoom == SelectedRoom.LivingRoom_TVDrawer)
        {
            switch (LivingRoom_TVDrawerItem)
            {
                case LivingRoom_TVDrawerItem.Return:
                    Debug.Log("You selected the return");
                    List<string> LivingRoomScenes = new List<string> {"LivingRoom"};
                    sceneManagerHelper.LoadSceneWithTransition(LivingRoomScenes);
                    SelectedRoom = SelectedRoom.LivingRoom;
                    break;
                case LivingRoom_TVDrawerItem.Scissors:
                    Debug.Log("You selected the scissors");
                    Dialog.GetRoomItem("LivingRoom_TVDrawer","Scissors");
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
                    List<string> UtilityRoom_BroomScenes = new List<string> {"UtilityRoom_Broom"};
                    sceneManagerHelper.LoadSceneWithTransition(UtilityRoom_BroomScenes);
                    SelectedRoom = SelectedRoom.UtilityRoom_Broom;
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
        else if (SelectedRoom == SelectedRoom.UtilityRoom_Broom)
        {
            switch (UtilityRoom_BroomItem)
            {
                case UtilityRoom_BroomItem.Broom:
                    Debug.Log("You selected the broom");
                    break;
                case UtilityRoom_BroomItem.Car:
                    Debug.Log("You selected the car");
                    Dialog.GetRoomItem("UtilityRoom_Broom","Car");
                    break;
                case UtilityRoom_BroomItem.Return:
                    Debug.Log("You selected the return");
                    List<string> UtilityRoomScenes = new List<string> {"UtilityRoom"};
                    sceneManagerHelper.LoadSceneWithTransition(UtilityRoomScenes);
                    SelectedRoom = SelectedRoom.UtilityRoom;
                    break;
                default:
                    Debug.Log("You selected nothing");
                    break;
            }
        }
        else if (SelectedRoom == SelectedRoom.GuestRoom)
        {
            switch (GuestRoomItem)
            {
                case GuestRoomItem.Report:
                    Debug.Log("You selected the report");
                    SelectedObject = GameObject.Find("Report");
                    if (SelectedObject != null)
                    {
                        interactScript = SelectedObject.GetComponent<CanInteractAgain>();
                    }
                    break;
                case GuestRoomItem.Select:
                    Debug.Log("You selected the textA");
                    SelectedObject = GameObject.Find("Select");
                    if (SelectedObject != null)
                    {
                        interactScript = SelectedObject.GetComponent<CanInteractAgain>();
                    }
                    break;
                case GuestRoomItem.block:
                    Debug.Log("You selected the textB");
                    SelectedObject = GameObject.Find("block");
                    if (SelectedObject != null)
                    {
                        interactScript = SelectedObject.GetComponent<CanInteractAgain>();
                    }
                    break;
                case GuestRoomItem.Memory:
                    Debug.Log("You selected the memory");
                    List<string> UtilityRoomScenes = new List<string> {"memory"};
                    sceneManagerHelper.LoadSceneWithTransition(UtilityRoomScenes);
                    SelectedRoom = SelectedRoom.UtilityRoom;
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