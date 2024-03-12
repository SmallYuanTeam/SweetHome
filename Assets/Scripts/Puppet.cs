using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Puppet : MonoBehaviour
{
    public Image imageA;
    public Image imageB;
    private bool isShowingA = true;
    public GameObject Item;
    List<string> itemIDToCheck = new List<string> {"Hat", "Cloth", "Pant", "Shoe"};
    bool hasAllItems;
    float fadeDuration = 1.0f; 

    public void Awake()
    {
        hasAllItems = Player.Instance.HaveObtainedAllItems(itemIDToCheck);
        SetItemAlpha(0); 
    }

    public void ClickPuppet()
    {
        if (!hasAllItems)
        {
            StartCoroutine(FadeInItem());
            StartCoroutine(FadeTransition());
        }
    }
    IEnumerator FadeTransition()
    {
        Image fadeOutImage = isShowingA ? imageA : imageB;
        Image fadeInImage = isShowingA ? imageB : imageA;

        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / fadeDuration;
            fadeOutImage.color = new Color(fadeOutImage.color.r, fadeOutImage.color.g, fadeOutImage.color.b, 1 - t);
            fadeInImage.color = new Color(fadeInImage.color.r, fadeInImage.color.g, fadeInImage.color.b, t);
            yield return null;
        }
        
        //isShowingA = !isShowingA; // Toggle the flag
    }
    IEnumerator FadeInItem()
    {
        float currentTime = 0;
        Image itemImage = Item.GetComponent<Image>();
        Item.SetActive(true);
        Color startColor = itemImage.color;
        Color endColor = new Color(1, 1, 1, 1);

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(currentTime / fadeDuration);
            itemImage.color = Color.Lerp(startColor, endColor, alpha);
            yield return null;
        }

        Item.GetComponent<Button>().interactable = true; 
    }

    void SetItemAlpha(float alpha)
    {
        Image itemImage = Item.GetComponent<Image>();
        itemImage.color = new Color(itemImage.color.r, itemImage.color.g, itemImage.color.b, alpha);
    }
}
