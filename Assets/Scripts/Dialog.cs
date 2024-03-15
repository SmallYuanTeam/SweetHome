
using UnityEngine;
using UnityEngine.UI;
using Flower;
using System.Collections.Generic;
using JetBrains.Annotations;

public class Dialog : MonoBehaviour
{
    FlowerSystem flowerSys;
    GameMasterScript gameMaster;
    public bool FirstDialogOn = false;
    private string UserName;
    public static bool DialogOn = false;
    private Button DialogButton;
    private GameObject DialogPanel;
    private GameObject DialogBackground;
    public GameObject Background;

    void Start()
    {
        flowerSys = FlowerManager.Instance.CreateFlowerSystem("Dialog", false);
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMasterScript>();
        flowerSys.RegisterCommand("ChangeNPC", ChangeNPC);
        flowerSys.RegisterCommand("ChangeBackground", ChangeBackground);
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
            string resourcePath = $"Dialogues/Dialogues/{NPC}/{eventID}";
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
    private void ChangeNPC(List<string> _params)
    {
        Debug.Log($"ChangeNPC: {string.Join(", ", _params)}");
        DialogBackground.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/UI/DialogItem/{_params[0]}");
    }

    private void ChangeBackground(List<string> _params)
    {
        Background = GameObject.Find("BG");
        TransitionHelper transitionHelper = new TransitionHelper();
        transitionHelper.BackgroundTransitionCoroutine(_params[0], Background);
    }

    public bool DialogIsCompleted()
    {
        return flowerSys.isCompleted;
    }
}