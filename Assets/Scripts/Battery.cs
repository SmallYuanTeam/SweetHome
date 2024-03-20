using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    private SceneManagerHelper sceneManagerHelper;
    private Dialog dialog;
    private GameMasterScript gameMasterScript;
    private int progress = 0;

    void Awake()
    {
        sceneManagerHelper = FindObjectOfType<SceneManagerHelper>();
        dialog = GameObject.Find("Dialog").GetComponent<Dialog>();
        gameMasterScript = FindObjectOfType<GameMasterScript>();
    }
    public void BatteryPickUp()
    {
        if (progress == 0)
        {
            dialog.GetDialog("FirstMonster", "BatteryPickUp");
            dialog.setDialog(() =>
            {
                progress = 1;
                gameMasterScript.InventoryPanelDeactive();
            });
        }
        

    }
}
