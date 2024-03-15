using UnityEngine;
using UnityEngine.UI;
using Flower;
using System.Collections.Generic;
using Com.LuisPedroFonseca.ProCamera2D;

public class Dialog : MonoBehaviour
{
    FlowerSystem flowerSys;
    GameMasterScript gameMaster;
    private ProCamera2DTransitionsFX transitionsFX;
    public bool FirstDialogOn = false;
    private string UserName;
    public static bool DialogOn = false;
    private Button DialogButton;
    private GameObject DialogPanel;
    private GameObject DialogBackground;
    public GameObject Background;
    public SceneManagerHelper sceneManagerHelper;

    void Start()
    {
        flowerSys = FlowerManager.Instance.CreateFlowerSystem("Dialog", false);
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMasterScript>();
        sceneManagerHelper = FindObjectOfType<SceneManagerHelper>();
        flowerSys.RegisterCommand("ChangeNPC", ChangeNPC);
        flowerSys.RegisterCommand("ChangeBackground", ChangeBackground);
    }
    void Awake()
    {
        transitionsFX = ProCamera2DTransitionsFX.Instance;
    }
    void _TransitionEnter()
    {
        transitionsFX.TransitionEnter();
    }
    void _TransitionExit()
    {
        transitionsFX.TransitionExit();
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
        Background = GameObject.Find("BG");
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

    public void ChangeBackground(List<string> _params)
    {
        transitionsFX.DurationExit = 1.0f;
        transitionsFX.DurationEnter = 1.0f;
        transitionsFX.TransitionExit();
        Debug.Log($"ChangeBG: {string.Join(", ", _params[0])}");
        Background.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/Story/{_params[0]}");
        transitionsFX.TransitionEnter();
        transitionsFX.DurationExit = 0.3f;
        transitionsFX.DurationEnter = 0.5f;
    }

    public bool DialogIsCompleted()
    {
        return flowerSys.isCompleted;
    }
}