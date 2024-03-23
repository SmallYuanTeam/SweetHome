using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Puppet : MonoBehaviour
{
    public GameObject imageA;
    public GameObject imageB;
    public GameObject player;
    public InventoryUI inventoryUI;
    public GameObject Item;
    List<string> itemIDToCheck = new List<string> {"Hat", "Cloth", "Pant", "Shoe"};
    public List<ItemObject> itemsToCheck;
    bool hasAllItems;
    float fadeDuration = 1.0f; 

    public void Awake()
    {
        hasAllItems = Player.Instance.HaveObtainedAllItems(itemIDToCheck);
        player = GameObject.Find("Player");
        inventoryUI = GameObject.Find("InventoryScreen").GetComponent<InventoryUI>();
    }

    public void ClickPuppet()
    {
        if (hasAllItems)
        {
            Debug.Log("Has all items, proceeding with fade transition.");
            // 確保這裡只會執行一次，例如透過檢查物件的激活狀態
            if (!imageB.activeSelf) // 假設初始狀態下imageB是非激活的
            {
                
                StartCoroutine(FadeTransition(imageA, imageB));
                if (player != null)
                {
                    Player.Instance.inventory.RemoveListItem(itemsToCheck);
                    inventoryUI.UpdateInventoryUI();
                }
            }
        }
        else
        {
            Debug.Log("Does not have all items.");
        }
    }
    IEnumerator FadeTransition(GameObject fadeOutObject, GameObject fadeInObject)
    {
        Debug.Log("FadeTransition started.");
        CanvasGroup fadeOutGroup = fadeOutObject.GetComponent<CanvasGroup>();
        CanvasGroup fadeInGroup = fadeInObject.GetComponent<CanvasGroup>();

        fadeInObject.SetActive(true);
        fadeInGroup.alpha = 0;

        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {  
            Debug.Log($"Fading out. Alpha: {fadeOutGroup.alpha}");
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / fadeDuration;
            fadeOutGroup.alpha = 1 - t;
            yield return null;
        }

        fadeOutGroup.interactable = false;
        fadeOutGroup.blocksRaycasts = false;

        // 重置 elapsedTime 为 0 以用于淡入效果
        elapsedTime = 0f;

        // 淡入 fadeInObject
        while (elapsedTime < fadeDuration)
        {
            Debug.Log($"Fading in. Alpha: {fadeInGroup.alpha}");
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / fadeDuration;
            fadeInGroup.alpha = t;
            yield return null;
        }
        Debug.Log("FadeTransition completed.");
    }
}
