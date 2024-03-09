using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Flower;
using UnityEngine.SceneManagement;

public class DayOneDialog : MonoBehaviour
{
    FlowerSystem flowerSys;
    GameMasterScript gameMaster;
    private string UserName;
    private string NPCName;
    private bool isDayOne = false;
    private static bool DialogOn = false;

    void Start()
    {
        flowerSys = FlowerManager.Instance.CreateFlowerSystem("DayOneDialog", false);
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMasterScript>();
    }

    public void DialogContinue()
    {
        flowerSys.Next();
    }

    public void setDialog()
    {
        flowerSys.SetupDialog();
        DialogOn = true;
    }
    public void GetRoomItem(string item)
    {
        if (!DialogOn && gameMaster.SelectedRoom == SelectedRoom.GuysRoom)
        {
            setDialog();
            string resourcePath = $"Dialogues/GuysRoom/{item}";
            flowerSys.ReadTextFromResource(resourcePath);
        }
    }
}