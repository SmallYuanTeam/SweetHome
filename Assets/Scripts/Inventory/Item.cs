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
        button.onClick.AddListener(AddItem);
    }
    void AddItem()
    {
        player.AddItemToInventory(item);
    }
}
