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
    public bool FirstDialogOn = false;
    private string UserName;
    //private string NPCName;
    private bool isDayOne = false;
    private static bool DialogOn = false;
    private Button DialogButton;
    private GameObject DialogPanel;
    private GameObject DialogBackground;

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
        if (!FirstDialogOn)
        {
            flowerSys.SetupDialog();
        }
        else DialogPanel.SetActive(true);
    }
    public void removeDialog()
    {
        DialogPanel.SetActive(false);
        DialogOn = false;
    }
    public void GetRoomItem(string Room, string item)
    {
        if (!DialogOn)
        {
            setDialog();
            string resourcePath = $"Dialogues/{Room}/{item}";
            flowerSys.ReadTextFromResource(resourcePath);
            if (FirstDialogOn == false)
            {
                FirstDialog();
                FirstDialogOn = true;
                DialogBackground.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/UI/DialogItem/Guys");
            }
            
        }
        else DialogBackground.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/UI/DialogItem/Guys");
    }
    public void GetNPCDialog(string NPC, string eventID)
    {
        if (!DialogOn)
        {
            setDialog();
            string resourcePath = $"Dialogues/{NPC}/{eventID}";
            flowerSys.ReadTextFromResource(resourcePath);
            if (FirstDialogOn == false)
            {
                FirstDialog();
                FirstDialogOn = true;
            }
        }
        DialogBackground.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/UI/DialogItem/{NPC}");
    }
    void Update()
    {
        if(flowerSys.isCompleted && FirstDialogOn)
        {
            removeDialog();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            flowerSys.Next();
        }
    }
    public void FirstDialog()
    {
        DialogButton = GameObject.Find("DialogNext").GetComponent<Button>();
        DialogPanel = GameObject.Find("DialogPanel");
        DialogBackground = GameObject.Find("DialogBackground");
        DialogButton.onClick.AddListener(DialogContinue);
    }
}