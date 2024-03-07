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
            GameMaster.GetComponent<GameMasterScript>().GuysRoomitem = (GuysRoomItem)Enum.Parse(typeof(GuysRoomItem), buttonName);
            GameMaster.GetComponent<GameMasterScript>().Selection();
        }
        
    }
}
