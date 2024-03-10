using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryObject inventory;
    public InventoryUI inventoryUI;

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
    // 遊戲結束時，背包內的物品會被清空
    public void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
