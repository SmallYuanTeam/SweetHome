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
    private Coroutine clearItemsCoroutine;
    private void Start()
    {
        // 找到自己底下的所有itemslots按鈕(名字要對)
        itemSlots = GetComponentsInChildren<Button>();
        selectedItemImage.gameObject.SetActive(false);

        // 為每個背包格子的按鈕添加監聽器
        for (int i = 0; i < itemSlots.Length; i++)
        {
            int index = i; // 由於閉包問題，我們需要在迴圈內部創建一個局部變數
            itemSlots[i].onClick.AddListener(() => StartCoroutine(OnItemSlotClicked(index)));
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
    private IEnumerator OnItemSlotClicked(int slotIndex)
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
                yield return new WaitForSeconds(1f);
                selectedItemImage.gameObject.SetActive(false);

            }
            else
            {
                selectedItemImage.sprite = null;
                selectedItemImage.enabled = false;
            }

            TryCraftItem();
            if (clearItemsCoroutine != null)
            {
                StopCoroutine(clearItemsCoroutine);
            }

            // 啟動新的協程並將其賦值給追蹤變量
            clearItemsCoroutine = StartCoroutine(ClearSelectedItemsAfterDelay(5f));
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
        // 載入預設的物品槽圖片
        Sprite defaultSprite = Resources.Load<Sprite>("Sprites/UI/Inventory/InvSlot");

        // 初始化所有物品槽為預設圖片
        foreach (var itemSlot in itemSlots)
        {
            Image targetImage = GetItemSlotImage(itemSlot);
            if (targetImage != null)
            {
                // 將每個物品槽的圖片設置為預設圖片
                targetImage.sprite = defaultSprite;
            }
        }

        // 更新物品槽以顯示當前背包中的物品
        for (int i = 0; i < player.inventory.Container.Count && i < itemSlots.Length; i++)
        {
            Image targetImage = GetItemSlotImage(itemSlots[i]);
            if (targetImage != null && player.inventory.Container[i] != null && player.inventory.Container[i].item != null)
            {
                // 如果物品槽有物品，則顯示該物品的圖標
                targetImage.sprite = player.inventory.Container[i].item.icon;
            }
            // 如果無物品或出現空引用，則已經預設為預設圖片，無需進一步操作
        }
    }

    // Helper 方法來查找物品槽中的 Image 組件
    private Image GetItemSlotImage(Button itemSlot)
    {
        foreach (Transform child in itemSlot.transform)
        {
            if (child.CompareTag("ItemSlotImage"))
            {
                return child.GetComponent<Image>();
            }
        }
        return null; // 沒有找到帶有 "ItemSlotImage" 標籤的子物件
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
    private IEnumerator ClearSelectedItemsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        selectedItems.Clear();
        Debug.Log("Selected items have been cleared after delay.");
        UpdateInventoryUI();
    }

}
