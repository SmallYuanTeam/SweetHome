using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialCallQTE : MonoBehaviour
{
    public QTESequenceController QTESequenceController;
    public string scene;
    private SceneManagerHelper sceneManagerHelper;
    private Dialog dialog;
    private GameMasterScript gameMasterScript;
    private int progress = 0;
    private bool isInsideQTE = false;
    private bool isCoroutineRunning = false;
    private bool isQTEDone = false;

    void Awake()
    {
        dialog = GameObject.Find("Dialog").GetComponent<Dialog>();
        sceneManagerHelper = FindObjectOfType<SceneManagerHelper>();
        gameMasterScript = FindObjectOfType<GameMasterScript>();
    }
    void Update()
    {
        if (QTESequenceController != null)
        {
            if (!Dialog.DialogOn && dialog.DialogIsCompleted() && !isCoroutineRunning && QTESequenceController.isSequenceCompleted && isInsideQTE)
            {
                Debug.Log("IsReady");
                StartCoroutine(ProcessStoryProgress());
            }
        }
    }
    IEnumerator ProcessStoryProgress()
    {
        isCoroutineRunning = true;
        switch(progress)
        {
            case 0:
                var asyncLoad = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
                yield return new WaitUntil(() => asyncLoad.isDone);
                QTESequenceController = GameObject.Find("QTE").GetComponent<QTESequenceController>();
                QTESequenceController.isTutorialMode = true;
                QTESequenceController.isSequenceCompleted = true;
                progress = 1;
                break;
            case 1:
                dialog.GetDialog("FirstStory","FirstStory_08");
                dialog.setDialog();
                QTESequenceController.SetUpQTESetting(4,5);
                yield return new WaitUntil(() => dialog.DialogIsCompleted());
                {
                    QTESequenceController.StartNewSequence();
                }
                progress = 2;
                Dialog.DialogSkipOn = false;
                break;
            case 2:
                dialog.GetDialog("FirstStory","FirstStory_08");
                dialog.setDialog();
                QTESequenceController.SetUpQTESetting(5,7);
                yield return new WaitUntil(() => dialog.DialogIsCompleted());
                {
                    QTESequenceController.StartNewSequence();
                }
                progress = 3;
                Dialog.DialogSkipOn = false;
                break;
            case 3:
                dialog.GetDialog("FirstStory","FirstStory_08");
                dialog.setDialog();
                QTESequenceController.SetUpQTESetting(6,9);
                yield return new WaitUntil(() => dialog.DialogIsCompleted());
                {
                    QTESequenceController.StartNewSequence();
                }
                progress = 4;
                Dialog.DialogSkipOn = false;
                break;
            case 4:
                dialog.GetDialog("FirstStory","FirstStory_08");
                dialog.setDialog();
                yield return new WaitUntil(() => dialog.DialogIsCompleted());
                {
                    var asyncUnload = SceneManager.UnloadSceneAsync(scene);
                    yield return new WaitUntil(() => asyncUnload.isDone);
                }
                Dialog.DialogSkipOn = false;
                isQTEDone = true;
                break;
        }
        isCoroutineRunning = false;
    }
    public void SetIsInsideQTE()
    {
        isInsideQTE = true;
    }
    public void OnButtonClick()
    {
        StartCoroutine(OnButtonClick_());
    }
    public IEnumerator OnButtonClick_()
    {
        if (!isCoroutineRunning && !isQTEDone)
        {
            dialog.GetDialog("FirstMonster", "BatteryPickUp");
            dialog.setDialog();
            yield return new WaitUntil(() => dialog.DialogIsCompleted());
            isInsideQTE = true;
            Dialog.DialogSkipOn = false;
            StartCoroutine(ProcessStoryProgress());
            progress = 0;
        }
    }
}