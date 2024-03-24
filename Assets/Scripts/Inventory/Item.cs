using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Item : MonoBehaviour
{
    public ItemObject item;
    public Player player;
    public Button button;
    public string SceneName;
    Dialog Dialog;

    void Start()
    {
        button = GetComponent<Button>();
        Dialog = FindObjectOfType<Dialog>();
        // 找到玩家
        player = FindObjectOfType<Player>();
        if (Player.Instance.HasObtainedItem(item.itemID))
        {
            Destroy(gameObject); 
        }
        else
        {
            button.onClick.AddListener(OnItemPickedUp);
        }
        
    }
    public void OnItemPickedUp()
    {
        // 假设这个方法在物品被玩家拾取时被调用
        Player.Instance.AddItemToInventory(item);
        Dialog.GetRoomItem(SceneName,item.itemID);
        Player.Instance.AddObtainedItemID(item.itemID);
        gameObject.SetActive(false); // 隐藏物品
    }
}
