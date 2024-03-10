using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 引用 UnityEngine.UI 命名空間來操作 UI 元件

public class InventoryUI : MonoBehaviour
{
    public Player player; // 參考到玩家物件
    public Button[] itemSlots; // 儲存所有背包格子的按鈕
    public List<ItemObject> selectedItems = new List<ItemObject>();
    public List<CraftRecipe> allRecipes = new List<CraftRecipe>();
    public Image selectedItemImage;

    private void Start()
    {
        // 找到自己底下的所有itemslots按鈕(名字要對)
        itemSlots = GetComponentsInChildren<Button>();
        selectedItemImage.gameObject.SetActive(false);

        // 為每個背包格子的按鈕添加監聽器
        for (int i = 0; i < itemSlots.Length; i++)
        {
            int index = i; // 由於閉包問題，我們需要在迴圈內部創建一個局部變數
            itemSlots[i].onClick.AddListener(() => OnItemSlotClicked(index));
        }
        LoadAllRecipes();
        UpdateInventoryUI();
    }
    void LoadAllRecipes()
    {
        // 假設所有配方存儲在 Resources/ScriptableObject/CraftRecipe 目錄下
        CraftRecipe[] recipes = Resources.LoadAll<CraftRecipe>("ScriptableObject/CraftRecipe");
        allRecipes = new List<CraftRecipe>(recipes);
    }

    // 按鈕被點擊時調用的方法
    private void OnItemSlotClicked(int slotIndex)
    {
        Debug.Log($"ItemSlot {slotIndex} 被點擊");

        var selectedItem = player.inventory.Container[slotIndex].item;
        // 只是將物品加入到 selectedItems 列表，不從背包移除
        if (!selectedItems.Contains(selectedItem))
        {
            selectedItems.Add(selectedItem);

            if (selectedItem.icon != null)
            {
                selectedItemImage.sprite = selectedItem.icon;
                selectedItemImage.gameObject.SetActive(true);

            }
            else
            {
                selectedItemImage.sprite = null;
                selectedItemImage.enabled = false;
            }

            TryCraftItem();
        }
    }

    void CraftItem(CraftRecipe recipe)
    {
        foreach (var item in recipe.materials)
        {
            // 這裡從背包中移除所需的物品，假設你有一個方法可以正確處理這一操作
            player.inventory.RemoveItem(item);
        }
        // 添加合成結果物品到背包
        player.inventory.AddItem(recipe.result);

        // 清空選擇的物品列表
        selectedItems.Clear();
        selectedItemImage.enabled = false; // 隱藏選擇物品的圖片

        UpdateInventoryUI(); // 更新 UI 以反映新的背包狀態
    }

    public void PutDownItem()
    {
        selectedItemImage.sprite = null;
        selectedItemImage.enabled = false; // 可以選擇禁用 Image 元件，如果不顯示空白框架是你想要的行為
    }


    // 更新背包 UI 的方法
    public void UpdateInventoryUI()
    {
        // 首先將所有的背包格子設為預設狀態，比如空的圖標
        foreach (var itemSlot in itemSlots)
        {
            itemSlot.GetComponentInChildren<Image>().sprite = null  ; // 或是一個預設的空物品圖標
        }

        // 根據玩家背包內的物品更新背包格子
        for (int i = 0; i < player.inventory.Container.Count; i++)
        {
            if (i < itemSlots.Length)
            {
                if (itemSlots[i] != null && itemSlots[i].GetComponentInChildren<Image>() != null && player.inventory.Container[i] != null && player.inventory.Container[i].item != null) 
                {
                    itemSlots[i].GetComponentInChildren<Image>().sprite = player.inventory.Container[i].item.icon;
                }
                else 
                {
                    Debug.LogError("在索引" + i + "檢測到空引用");
                }

            }
        }
    }
    void TryCraftItem()
    {
        bool crafted = false;

        foreach (var recipe in allRecipes)
        {
            if (IsMatch(recipe.materials, selectedItems))
            {
                // 配方匹配，進行合成
                CraftItem(recipe);
                crafted = true;
                // 不再使用 break;，繼續遍歷所有配方
            }
        }

        if (!crafted)
        {
            Debug.Log("沒有找到合適的配方");
        }

        // 只有在所有需要的物品都已選擇後才清空 selectedItems
        if (crafted)
        {
            selectedItems.Clear();
        }

        UpdateInventoryUI(); // 更新 UI
    }

    bool IsMatch(List<ItemObject> requiredItems, List<ItemObject> selectedItems)
    {
        // 檢查 selectedItems 是否包含所有 requiredItems
        foreach (var reqItem in requiredItems)
        {
            if (!selectedItems.Contains(reqItem))
            {
                return false; // 如果缺少任何所需物品，返回 false
            }
        }
        return true; // 所有所需物品都被選中
    }

}
