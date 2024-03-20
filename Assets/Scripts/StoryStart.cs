using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;

public class StoryStart : MonoBehaviour
{
    private int progress = 0;
    private SceneManagerHelper sceneManagerHelper;
    private Dialog dialog;
    private GameMasterScript gameMasterScript;
    private bool hasDone = false;
    void Awake()
    {
        dialog = GameObject.Find("Dialog").GetComponent<Dialog>();
        sceneManagerHelper = FindObjectOfType<SceneManagerHelper>();
        gameMasterScript = FindObjectOfType<GameMasterScript>();
    }
    void Update()
    {
        if (!Dialog.DialogOn && dialog.DialogIsCompleted() == true && !hasDone)
        {
            switch (progress)
            {
                case 0:
                    dialog.GetDialog("FirstStory", "FirstStory_01");
                    dialog.setDialog();
                    progress = 1;
                    Dialog.DialogSkipOn = false;
                    break;
                case 1:
                    dialog.GetDialog("FirstStory", "FirstStory_00");
                    dialog.setDialog();
                    progress = 2;
                    Dialog.DialogSkipOn = false;
                    break;
                case 2:
                    dialog.ChangeBackgroundForScripts("GuysRoom", 0.3f, 0.3f);
                    dialog.GetDialog("FirstStory", "FirstStory_02");
                    dialog.setDialog();
                    progress = 3;
                    Dialog.DialogSkipOn = false;
                    break;
                case 3:
                    List<string> scenesToLoad = new List<string> {"GuysRoom"};
                    gameMasterScript.InventoryPanelActive();
                    sceneManagerHelper.LoadSceneWithTransition(scenesToLoad);
                    hasDone = true;
                    break;
            }
        }
    }
}
