using UnityEngine;
using UnityEngine.UI;
using Flower;
using System.Collections.Generic;
using Com.LuisPedroFonseca.ProCamera2D;
using System.Collections;

public class Dialog : MonoBehaviour
{
    FlowerSystem flowerSys;
    GameMasterScript gameMaster;
    private ProCamera2DTransitionsFX transitionsFX;
    public bool FirstDialogOn = false;
    private string UserName;
    public static bool DialogOn = false;
    public static bool DialogSkipOn = false;
    private Button DialogButton;
    private Button DialogSkip;
    private GameObject DialogPanel;
    private GameObject DialogBackground;
    public GameObject Background;
    public GameObject DialogCharacter;
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
    public void DialogSkips()
    {
        DialogSkipOn = true;
        flowerSys.textSpeed = 0.01f;
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
                DialogCharacter.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/Story/Guys");
            }
            
        }
        else 
        {
            DialogBackground.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/UI/DialogItem/Guys");
            DialogCharacter.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/Story/Guys");
        }
        

    }
    public void GetDialog(string ID, string eventID)
    {
        if (!DialogOn)
        {
            setDialog();
            string resourcePath = $"Dialogues/Dialogues/{ID}/{eventID}";
            flowerSys.ReadTextFromResource(resourcePath);
            if (FirstDialogOn == false)
            {
                FirstDialog();
                FirstDialogOn = true;
            }
        }
    }

    void Update()
    {
        if(flowerSys.isCompleted && FirstDialogOn)
        {
            removeDialog();
            DialogSkipOn = false;
            flowerSys.textSpeed = 0.1f;
        }
        if (DialogSkipOn)
        {
            flowerSys.Next();
        }
        Background = GameObject.Find("BG");
    }
    public void FirstDialog()
    {
        DialogButton = GameObject.Find("DialogNext").GetComponent<Button>();
        DialogSkip = GameObject.Find("DialogSkip").GetComponent<Button>();
        DialogPanel = GameObject.Find("DialogPanel");
        DialogBackground = GameObject.Find("DialogBackground");
        DialogCharacter = GameObject.Find("DialogCharacter");
        DialogButton.onClick.AddListener(DialogContinue);
        DialogSkip.onClick.AddListener(DialogSkips);
    }
    private void ChangeNPC(List<string> _params)
    {
        Debug.Log($"ChangeNPC: {string.Join(", ", _params)}");
        DialogBackground.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/UI/DialogItem/{_params[0]}");
        DialogCharacter.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/Story/{_params[0]}");
    }

    public void ChangeBackground(List<string> _params)
    {
        transitionsFX.DurationExit = 1.0f;
        transitionsFX.DurationEnter = 1.0f;
        transitionsFX.TransitionExit();
        Debug.Log($"ChangeBG: {string.Join(", ", _params[0])}");
        Background.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/Story/{_params[0]}");
        transitionsFX.TransitionEnter();
        ResetTransition();
    }
    public IEnumerator ChangeBackgroundForScripts(string Background, float DurationExit, float DurationEnter)
    {
        transitionsFX.DurationExit = DurationExit;
        transitionsFX.DurationEnter = DurationEnter;

        transitionsFX.TransitionExit();
        yield return new WaitForSeconds(DurationExit);

        Debug.Log($"ChangeBG: {string.Join(", ", Background)}");
        this.Background.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/Story/{Background}");
        
        transitionsFX.TransitionEnter();
        yield return new WaitForSeconds(DurationEnter);
        
        ResetTransition();
    }
    public void ResetTransition()
    {
        transitionsFX.DurationExit = 0.3f;
        transitionsFX.DurationEnter = 0.5f;
    }
    public bool DialogIsCompleted()
    {
        return flowerSys.isCompleted;
    }
}