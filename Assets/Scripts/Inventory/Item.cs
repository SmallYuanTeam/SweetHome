using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public ItemObject item;
    public Player player;
    public Button button;

    void Start()
    {
        button = GetComponent<Button>();
        // 找到玩家
        player = FindObjectOfType<Player>();
        if (Player.Instance.HasObtainedItem(item.itemID))
        {
            Destroy(gameObject); // 如果物品已被取得过，隐藏之
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
        Player.Instance.AddObtainedItemID(item.itemID);
        gameObject.SetActive(false); // 隐藏物品
    }
}
