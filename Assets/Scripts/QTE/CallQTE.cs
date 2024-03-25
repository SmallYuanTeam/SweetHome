using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallQTE : MonoBehaviour
{
    public QTESequenceController QTESequenceController;
    private SceneManagerHelper sceneManagerHelper;
    private Dialog dialog;
    private GameMasterScript gameMasterScript;
    private int progress = 0;
    private bool isInsideQTE = false;
    private bool isCoroutineRunning = false;

    void Awake()
    {
        dialog = GameObject.Find("Dialog").GetComponent<Dialog>();
        sceneManagerHelper = FindObjectOfType<SceneManagerHelper>();
        gameMasterScript = FindObjectOfType<GameMasterScript>();
    }
    void Update()
    {
        if (!Dialog.DialogOn && dialog.DialogIsCompleted() && !isCoroutineRunning && QTESequenceController.isSequenceCompleted && isInsideQTE)
        {
            StartCoroutine(ProcessStoryProgress());
        }
    }
    IEnumerator ProcessStoryProgress()
    {
        isCoroutineRunning = true;
        switch(progress)
        {
            case 0:
                yield return null;
                dialog.GetDialog("FirstStory","FirstStory08");
                dialog.setDialog();
                QTESequenceController.SetUpQTESetting(4,99);
                QTESequenceController.StartNewSequence();
                progress = 1;
                Dialog.DialogSkipOn = false;
                break;
            case 1:
                yield return null;
                dialog.GetDialog("FirstStory","FirstStory08");
                dialog.setDialog();
                QTESequenceController.SetUpQTESetting(5,99);
                QTESequenceController.StartNewSequence();
                progress = 2;
                Dialog.DialogSkipOn = false;
                break;
            case 2:
                yield return null;
                dialog.GetDialog("FirstStory","FirstStory08");
                dialog.setDialog();
                QTESequenceController.SetUpQTESetting(6,99);
                QTESequenceController.StartNewSequence();
                progress = 1;
                Dialog.DialogSkipOn = false;
                break;
        }
        isCoroutineRunning = false;
    }
    public void SetIsInsideQTE()
    {
        isInsideQTE = true;
    }
}