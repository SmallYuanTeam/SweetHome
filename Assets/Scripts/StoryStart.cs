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
    private bool isCoroutineRunning = false;
    void Awake()
    {
        dialog = GameObject.Find("Dialog").GetComponent<Dialog>();
        sceneManagerHelper = FindObjectOfType<SceneManagerHelper>();
        gameMasterScript = FindObjectOfType<GameMasterScript>();
    }

    void Update()
    {
        if (!Dialog.DialogOn && dialog.DialogIsCompleted() && !hasDone && !isCoroutineRunning)
        {
            StartCoroutine(ProcessStoryProgress());
        }
    }

    IEnumerator ProcessStoryProgress()
    {
        isCoroutineRunning = true;

        switch (progress)
            {
                case 0:
                    dialog.GetDialog("FirstStory", "FirstStory_00");
                    dialog.setDialog();
                    progress = 1;
                    Dialog.DialogSkipOn = false;
                    break;
                case 1:
                    yield return null;
                    StartCoroutine(dialog.ChangeBackgroundForScripts("Mail", 0.3f, 0.3f));
                    dialog.GetDialog("FirstStory", "FirstStory_01");
                    dialog.setDialog();
                    progress = 2;
                    Dialog.DialogSkipOn = false;
                    break;
                case 2:
                    yield return StartCoroutine(dialog.ChangeBackgroundForScripts("firstfloot_light", 2.0f, 2.0f));
                    yield return StartCoroutine(dialog.ChangeBackgroundForScripts("secondfloot_light", 2.0f, 2.0f));
                    yield return StartCoroutine(dialog.ChangeBackgroundForScripts("BookRoom_light", 2.0f, 2.0f));
                    dialog.GetDialog("FirstStory", "FirstStory_02");
                    dialog.setDialog();
                    progress = 3;
                    Dialog.DialogSkipOn = false;
                    break;
                case 3:
                    yield return StartCoroutine(dialog.ChangeBackgroundForScripts("GuysRoom", 2.0f, 2.0f));
                    dialog.GetDialog("FirstStory", "FirstStory_03");
                    dialog.setDialog();
                    progress = 4;
                    Dialog.DialogSkipOn = false;
                    break;
                case 4:
                    dialog.GetDialog("FirstStory", "FirstStory_04");
                    dialog.setDialog();
                    progress = 5;
                    Dialog.DialogSkipOn = false;
                    break;
                case 5:
                    yield return StartCoroutine(dialog.ChangeBackgroundForScripts("GuysRoom", 2.0f, 2.0f));
                    dialog.GetDialog("FirstStory", "FirstStory_05");
                    dialog.setDialog();
                    progress = 6;
                    Dialog.DialogSkipOn = false;
                    break;
                case 6:
                    dialog.GetDialog("FirstStory", "FirstStory_06");
                    dialog.setDialog();
                    progress = 7;
                    Dialog.DialogSkipOn = false;
                    break;
                case 7:                   
                    dialog.GetDialog("FirstStory", "FirstStory_07");
                    dialog.setDialog();
                    progress = 8;
                    Dialog.DialogSkipOn = false;
                    break;
                case 8:
                    yield return StartCoroutine(dialog.ChangeBackgroundForScripts("GuysRoom2", 2.0f, 2.0f));
                    dialog.GetDialog("FirstStory", "FirstStory_08");
                    dialog.setDialog();
                    progress = 9;
                    Dialog.DialogSkipOn = false;
                    break;
                case 9:
                    dialog.GetDialog("FirstStory", "FirstStory_09");
                    dialog.setDialog();
                    progress = 10;
                    Dialog.DialogSkipOn = false;
                    break;
                case 10:
                    List<string> scenesToLoad = new List<string> {"GuysRoom"};
                    gameMasterScript.InventoryPanelActive();
                    sceneManagerHelper.LoadSceneWithTransition(scenesToLoad);
                    hasDone = true;
                    break;
            }


        isCoroutineRunning = false;
    }
}
