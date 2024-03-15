using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;

public class StoryStart : MonoBehaviour
{
    public int progress = 0;
    public Dialog dialog;
    void Awake()
    {
        dialog = GameObject.Find("Dialog").GetComponent<Dialog>();
    }
    void Update()
    {
        if (!Dialog.DialogOn && dialog.DialogIsCompleted() == true)
        {
            switch (progress)
            {
                case 0:
                    dialog.GetNPCDialog("Doctor", "FirstStory_01");
                    dialog.setDialog();
                    progress = 1;
                    break;
                case 1:
                    dialog.GetNPCDialog("Doctor", "FirstStory_00");
                    dialog.setDialog();
                    progress = 2;
                    break;
                case 2:
                    dialog.GetNPCDialog("Doctor", "FirstStory_02");
                    dialog.setDialog();
                    progress = 3;
                    break;
                //case 3:

            }
        }
    }
}
