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


    public void UpdateInventoryUI()
    {
        foreach (var itemSlot in itemSlots)
        {
            Image targetImage = null;
            foreach (Transform child in itemSlot.transform)
            {
                if (child.CompareTag("ItemSlotImage"))
                {
                    targetImage = child.GetComponent<Image>();
                    break;
                }
            }
            
            if (targetImage != null)
            {
                targetImage.sprite = null;
            }
        }

        
        for (int i = 0; i < player.inventory.Container.Count && i < itemSlots.Length; i++)
        {
            Image targetImage = null;
            foreach (Transform child in itemSlots[i].transform)
            {
                if (child.CompareTag("ItemSlotImage"))
                {
                    targetImage = child.GetComponent<Image>();
                    break;
                }
            }

            if (targetImage != null && player.inventory.Container[i] != null && player.inventory.Container[i].item != null)
            {
                targetImage.sprite = player.inventory.Container[i].item.icon;
            }
            else
            {
                Debug.LogError($"在索引 {i} 檢查到空引用");
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
                CraftItem(recipe);
                crafted = true;
            }
        }

        if (!crafted)
        {
            Debug.Log("沒有找到合適的配方");
        }

        if (crafted)
        {
            selectedItems.Clear();
        }

        UpdateInventoryUI(); // 更新 UI
    }

    bool IsMatch(List<ItemObject> requiredItems, List<ItemObject> selectedItems)
    {
        foreach (var reqItem in requiredItems)
        {
            if (!selectedItems.Contains(reqItem))
            {
                return false;
            }
        }
        return true;
    }

}
