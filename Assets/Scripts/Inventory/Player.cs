using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance {get; private set; }
    public HashSet<string> obtainedItemIDs = new HashSet<string>();
    public InventoryObject inventory;
    public InventoryUI inventoryUI;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void AddItemToInventory(ItemObject item)
    {
        inventory.AddItem(item);
        inventoryUI.UpdateInventoryUI();
    }
    public void RemoveItemFromInventory(ItemObject item)
    {
        inventory.RemoveItem(item);
        inventoryUI.UpdateInventoryUI();
    }
    public void AddObtainedItemID(string itemID)
    {
        obtainedItemIDs.Add(itemID);
    }

    public bool HasObtainedItem(string itemID)
    {
        return obtainedItemIDs.Contains(itemID);
    }
    public bool HaveObtainedAllItems(List<string> itemIDs)
    {
        foreach (string id in itemIDs)
        {
            if (!obtainedItemIDs.Contains(id))
            {
                return false; // 如果有任何一个 ID 没有被获取过，返回 false
            }
        }
        return true; // 所有 ID 都已被获取过，返回 true
    }

    // 遊戲結束時，背包內的物品會被清空
    public void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
