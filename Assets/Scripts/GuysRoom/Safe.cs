using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Safe : MonoBehaviour
{
    // 自己身上的CanInteractAgain
    public CanInteractAgain canInteractAgain;
    public GameObject imageA;
    public GameObject imageB;
    public GameObject Item;

    private bool isShowingA = true;
    public float fadeDuration = 1f;

    void Start()
    {
        canInteractAgain = FindObjectOfType<CanInteractAgain>();
    }
    // 當按鈕被點擊
    public void OnClick()
    {
        if (canInteractAgain.interactCount == 0)
        {
            StartCoroutine(FadeTransition(imageA, imageB));
        
        }
    }
    IEnumerator FadeTransition(GameObject fadeOutObject, GameObject fadeInObject)
    {
        CanvasGroup fadeOutGroup = fadeOutObject.GetComponent<CanvasGroup>();
        CanvasGroup fadeInGroup = fadeInObject.GetComponent<CanvasGroup>();

        // 确保两个对象都是激活的，fadeInObject 初始透明
        fadeOutObject.SetActive(true);
        fadeInObject.SetActive(true);
        fadeInGroup.alpha = 0;
        fadeInGroup.interactable = false;

        float elapsedTime = 0f;

        // 同时淡出 fadeOutObject 并淡入 fadeInObject
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / fadeDuration;
            fadeOutGroup.alpha = 1 - t;
            fadeInGroup.alpha = t;
            yield return null;
        }
        fadeOutGroup.interactable = false;
        fadeOutGroup.blocksRaycasts = false;
        fadeInGroup.interactable = true;
    }

    void ItemPickUp(Image image)
    {
        Item.SetActive(isShowingA);
        Item.GetComponent<Image>().color = image.color;
        Item.GetComponent<Button>().interactable = isShowingA;
    }
}
