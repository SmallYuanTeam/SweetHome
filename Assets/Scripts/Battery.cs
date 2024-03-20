using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battery : MonoBehaviour
{
    private SceneManagerHelper sceneManagerHelper;
    private Dialog dialog;
    private GameMasterScript gameMasterScript;
    private int progress = 0;
    private bool isWaitingForDialog = false;

    void Awake()
    {
        sceneManagerHelper = FindObjectOfType<SceneManagerHelper>();
        dialog = GameObject.Find("Dialog").GetComponent<Dialog>();
        gameMasterScript = FindObjectOfType<GameMasterScript>();
    }
    

    void Update()
    {
        if (!Dialog.DialogOn && !isWaitingForDialog)
        {
            switch (progress)
            {
                case 0:
                    BatteryPickUp();
                    break;
                case 1:
                    BatteryPickUp();
                    break;
            }
        }
    }

    public void BatteryPickUp()
    {
        isWaitingForDialog = true;

        if (progress == 0)
        {
            dialog.GetDialog("FirstMonster", "BatteryPickUp");
            dialog.setDialog(() =>
            {
                progress = 1;
                gameMasterScript.InventoryPanelDeactive();
                isWaitingForDialog = false;
            });
        }
        else if (progress == 1)
        {
            SceneManager.LoadScene("QTE", LoadSceneMode.Additive);
        }
    }

}
