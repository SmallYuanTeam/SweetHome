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
        SceneName = SceneManager.GetActiveScene().name;
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
        // 從父對像身上得到場景
        SceneName = transform.parent.name;
        Dialog.GetRoomItem(SceneName, item.itemID);
        Player.Instance.AddObtainedItemID(item.itemID);
        gameObject.SetActive(false); // 隐藏物品
    }
}
