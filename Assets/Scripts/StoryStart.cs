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
        isCoroutineRunning = true; // 标记协程正在运行

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
                    //yield return StartCoroutine(dialog.ChangeBackgroundForScripts("firstfloot_light", 2.0f, 2.0f));
                    //yield return StartCoroutine(dialog.ChangeBackgroundForScripts("secondfloot_light", 3.0f, 4.0f));
                    //yield return StartCoroutine(dialog.ChangeBackgroundForScripts("BookRoom_light", 5.0f, 6.0f));
                    yield return null; 
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


        isCoroutineRunning = false;
    }
}
