using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInteractable : MonoBehaviour
{
    public GameObject GameMaster;

    void Start()
    {
        GameMaster = GameObject.Find("GameMaster");
        Button[] buttons = GetComponentsInChildren<Button>();

        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClicked(button.name));
        }
    }
    void OnButtonClicked(string buttonName)
    {
        //如果現在是在弟弟房間
        if (GameMaster.GetComponent<GameMasterScript>().SelectedRoom == SelectedRoom.GuysRoom)
        {
            GameMaster.GetComponent<GameMasterScript>().GuysRoomItem = (GuysRoomItem)Enum.Parse(typeof(GuysRoomItem), buttonName);
            GameMaster.GetComponent<GameMasterScript>().Selection();
        }
        //如果現在是在弟弟的桌子
        else if (GameMaster.GetComponent<GameMasterScript>().SelectedRoom == SelectedRoom.GuysTable)
        {
            GameMaster.GetComponent<GameMasterScript>().GuysTableItem = (GuysTableItem)Enum.Parse(typeof(GuysTableItem), buttonName);
            GameMaster.GetComponent<GameMasterScript>().Selection();
        }
        else if (GameMaster.GetComponent<GameMasterScript>().SelectedRoom == SelectedRoom.GuysGarderobe)
        {
            GameMaster.GetComponent<GameMasterScript>().GuysGarderobeItem = (GuysGarderobeItem)Enum.Parse(typeof(GuysGarderobeItem), buttonName);
            GameMaster.GetComponent<GameMasterScript>().Selection();
        }
        else if (GameMaster.GetComponent<GameMasterScript>().SelectedRoom == SelectedRoom.GuysCarpet)
        {
            GameMaster.GetComponent<GameMasterScript>().GuysCarpetItem = (GuysCarpetItem)Enum.Parse(typeof(GuysCarpetItem), buttonName);
            GameMaster.GetComponent<GameMasterScript>().Selection();
        }
        else if (GameMaster.GetComponent<GameMasterScript>().SelectedRoom == SelectedRoom.GuysBed)
        {
            GameMaster.GetComponent<GameMasterScript>().GuysBedItem = (GuysBedItem)Enum.Parse(typeof(GuysBedItem), buttonName);
            GameMaster.GetComponent<GameMasterScript>().Selection();
        }
        else if (GameMaster.GetComponent<GameMasterScript>().SelectedRoom == SelectedRoom.SecondFloor)
        {
            GameMaster.GetComponent<GameMasterScript>().SecondFloorItem = (SecondFloorItem)Enum.Parse(typeof(SecondFloorItem), buttonName);
            GameMaster.GetComponent<GameMasterScript>().Selection();
        }
        else if (GameMaster.GetComponent<GameMasterScript>().SelectedRoom == SelectedRoom.FirstFloor)
        {
            GameMaster.GetComponent<GameMasterScript>().FirstFloorItem = (FirstFloorItem)Enum.Parse(typeof(FirstFloorItem), buttonName);
            GameMaster.GetComponent<GameMasterScript>().Selection();
        }
        else if (GameMaster.GetComponent<GameMasterScript>().SelectedRoom == SelectedRoom.LivingRoom)
        {
            GameMaster.GetComponent<GameMasterScript>().LivingRoomItem = (LivingRoomItem)Enum.Parse(typeof(LivingRoomItem), buttonName);
            GameMaster.GetComponent<GameMasterScript>().Selection();
        }
        else if (GameMaster.GetComponent<GameMasterScript>().SelectedRoom == SelectedRoom.LivingRoom_Safe)
        {
            GameMaster.GetComponent<GameMasterScript>().LivingRoom_SafeItem = (LivingRoom_SafeItem)Enum.Parse(typeof(LivingRoom_SafeItem), buttonName);
            GameMaster.GetComponent<GameMasterScript>().Selection();
        }
        else if (GameMaster.GetComponent<GameMasterScript>().SelectedRoom == SelectedRoom.LivingRoom_Sofa)
        {
            GameMaster.GetComponent<GameMasterScript>().LivingRoom_SofaItem = (LivingRoom_SofaItem)Enum.Parse(typeof(LivingRoom_SofaItem), buttonName);
            GameMaster.GetComponent<GameMasterScript>().Selection();
        }
        else if (GameMaster.GetComponent<GameMasterScript>().SelectedRoom == SelectedRoom.LivingRoom_Table)
        {
            GameMaster.GetComponent<GameMasterScript>().LivingRoom_TableItem = (LivingRoom_TableItem)Enum.Parse(typeof(LivingRoom_TableItem), buttonName);
            GameMaster.GetComponent<GameMasterScript>().Selection();
        }
        else if (GameMaster.GetComponent<GameMasterScript>().SelectedRoom == SelectedRoom.LivingRoom_TVCabinet)
        {
            GameMaster.GetComponent<GameMasterScript>().LivingRoom_TVCabinetItem = (LivingRoom_TVCabinetItem)Enum.Parse(typeof(LivingRoom_TVCabinetItem), buttonName);
            GameMaster.GetComponent<GameMasterScript>().Selection();
        }
        else if (GameMaster.GetComponent<GameMasterScript>().SelectedRoom == SelectedRoom.LivingRoom_TVDrawer)
        {
            GameMaster.GetComponent<GameMasterScript>().LivingRoom_TVDrawerItem = (LivingRoom_TVDrawerItem)Enum.Parse(typeof(LivingRoom_TVDrawerItem), buttonName);
            GameMaster.GetComponent<GameMasterScript>().Selection();
        }
        // UtilityRoom
        else if (GameMaster.GetComponent<GameMasterScript>().SelectedRoom == SelectedRoom.UtilityRoom)
        {
            GameMaster.GetComponent<GameMasterScript>().UtilityRoomItem = (UtilityRoomItem)Enum.Parse(typeof(UtilityRoomItem), buttonName);
            GameMaster.GetComponent<GameMasterScript>().Selection();
        }
        else if (GameMaster.GetComponent<GameMasterScript>().SelectedRoom == SelectedRoom.UtilityRoom_Broom)
        {
            GameMaster.GetComponent<GameMasterScript>().UtilityRoom_BroomItem = (UtilityRoom_BroomItem)Enum.Parse(typeof(UtilityRoom_BroomItem), buttonName);
            GameMaster.GetComponent<GameMasterScript>().Selection();
    }
}
}