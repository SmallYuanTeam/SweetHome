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
    private bool isCoroutineRunning = false;

    void Awake()
    {
        dialog = GameObject.Find("Dialog").GetComponent<Dialog>();
        sceneManagerHelper = FindObjectOfType<SceneManagerHelper>();
        gameMasterScript = FindObjectOfType<GameMasterScript>();
    }
    void Update()
    {
        if (!Dialog.DialogOn && dialog.DialogIsCompleted() && !isCoroutineRunning && QTESequenceController.isSequenceCompleted)
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
                QTESequenceController.StartNewSequence();
                break;
        }
        isCoroutineRunning = false;
    }
}