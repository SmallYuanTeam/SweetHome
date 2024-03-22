using UnityEngine;
using UnityEngine.UI;
using Flower;
using System.Collections.Generic;
using Com.LuisPedroFonseca.ProCamera2D;
using System.Collections;
using System;

public class Dialog : MonoBehaviour
{
    FlowerSystem flowerSys;
    GameMasterScript gameMaster;
    private ProCamera2DTransitionsFX transitionsFX;
    public bool FirstDialogOn = false;
    public static bool DialogOn = false;
    public static bool DialogSkipOn = false;
    private Button DialogButton;
    private Button DialogSkip;
    private GameObject DialogPanel;
    private GameObject DialogBackground;
    public GameObject Background;
    public GameObject DialogCharacter;
    public GameObject DialogItem;
    public SceneManagerHelper sceneManagerHelper;

    void Start()
    {
        flowerSys = FlowerManager.Instance.CreateFlowerSystem("Dialog", false);
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMasterScript>();
        sceneManagerHelper = FindObjectOfType<SceneManagerHelper>();
        flowerSys.RegisterCommand("ChangeNPC", ChangeNPC);
        flowerSys.RegisterCommand("ChangeBackground", ChangeBackground);
        flowerSys.RegisterCommand("ChangeItem", ChangeItemWrapper);
        flowerSys.RegisterCommand("ChangeNPCFace", ChangeNPCFace);
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

    public void setDialog(Action callback = null)
    {
        if (!FirstDialogOn)
        {
            flowerSys.SetupDialog();
            
        }
        else DialogPanel.SetActive(true);
        callback?.Invoke();
    }
    public void removeDialog()
    {
        DialogPanel.SetActive(false);
        DialogOn = false;
    }
    public void DialogSkips()
    {
        DialogSkipOn = true;
        flowerSys.textSpeed = 0.0f;
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
            else 
            {
                Debug.Log("Dialog is already on");
                DialogBackground.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/UI/DialogItem/Guys");
                DialogCharacter.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/Story/Guys");
            }
            
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
            flowerSys.textSpeed = 0.01f;
        }
        if (DialogSkipOn)
        {
            flowerSys.Next();
        }
        Background = GameObject.Find("BG");
        DialogItem = GameObject.Find("DialogItem");
    }
    public void FirstDialog()
    {
        DialogButton = GameObject.Find("DialogNext").GetComponent<Button>();
        DialogSkip = GameObject.Find("DialogSkip").GetComponent<Button>();
        DialogPanel = GameObject.Find("DialogPanel");
        DialogBackground = GameObject.Find("DialogBackground");
        DialogCharacter = GameObject.Find("DialogCharacter");
        DialogItem = GameObject.Find("DialogItem");
        DialogButton.onClick.AddListener(DialogContinue);
        DialogSkip.onClick.AddListener(DialogSkips);
    }
    private void ChangeNPC(List<string> _params)
    {
        Debug.Log($"ChangeNPC: {string.Join(", ", _params)}");
        DialogBackground.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/UI/DialogItem/{_params[0]}");
        DialogCharacter.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/Story/{_params[0]}");
    }
    private void ChangeNPCFace(List<string> _params)
    {
        Debug.Log($"ChangeNPCFace: {string.Join(", ", _params)}");
        DialogCharacter.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/Story/{_params[0]}/{_params[1]}");
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
        //flowerSys
    }
    public void ChangeItemWrapper(List<string> _params)
    {
        StartCoroutine(ChangeItem(_params));
    }

    public IEnumerator ChangeItem(List<string> _params)
    {
        // 檢查 _params 是否有足夠的元素
        if (_params.Count < 4)
        {
            Debug.LogError("Not enough parameters provided to ChangeItem.");
            yield break;
        }

        // 嘗試從 _params 解析所有需要的值
        string item = _params[0];
        if (!float.TryParse(_params[1], out float fadeInDuration) ||
            !float.TryParse(_params[2], out float displayDuration) ||
            !float.TryParse(_params[3], out float fadeOutDuration))
        {
            Debug.LogError("Failed to parse durations from parameters.");
            yield break;
        }

        // 確保 DialogItem 已經被賦予了一個圖片
        var itemImage = DialogItem.GetComponent<Image>();
        var sprite = Resources.Load<Sprite>($"Sprites/Story/{item}");
        if (sprite == null)
        {
            Debug.LogError($"Item sprite not found for {item}.");
            yield break;
        }

        itemImage.sprite = sprite;
        itemImage.color = new Color(itemImage.color.r, itemImage.color.g, itemImage.color.b, 0);

        // 淡入
        float elapsedTime = 0;
        while (elapsedTime < fadeInDuration)
        {
            itemImage.color = new Color(itemImage.color.r, itemImage.color.g, itemImage.color.b, elapsedTime / fadeInDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        itemImage.color = new Color(itemImage.color.r, itemImage.color.g, itemImage.color.b, 1);
        yield return new WaitForSeconds(displayDuration);

        // 淡出
        elapsedTime = 0;
        while (elapsedTime < fadeOutDuration)
        {
            itemImage.color = new Color(itemImage.color.r, itemImage.color.g, itemImage.color.b, 1 - (elapsedTime / fadeOutDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        itemImage.color = new Color(itemImage.color.r, itemImage.color.g, itemImage.color.b, 0);
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