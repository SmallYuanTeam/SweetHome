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
    // 遊戲結束時，背包內的物品會被清空
    public void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
