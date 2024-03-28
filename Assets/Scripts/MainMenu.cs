using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public SceneManagerHelper sceneManagerHelper;
    public GameMasterScript gameMasterScript; // Add this line

    public void Start()
    {
        sceneManagerHelper = FindObjectOfType<SceneManagerHelper>();
        gameMasterScript = FindObjectOfType<GameMasterScript>();
    }

    public void StartGame()
    {
        //List<string> scenesToLoad = new List<string> {"StoryStart"};
        List<string> scenesToLoad = new List<string> {"GuysRoom"};
        gameMasterScript.InventoryPanelActive();
        sceneManagerHelper.LoadSceneWithTransition(scenesToLoad);
    }
}
