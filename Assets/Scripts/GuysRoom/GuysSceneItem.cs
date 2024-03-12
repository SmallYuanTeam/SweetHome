using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class GuysSceneItem : MonoBehaviour
{
    // 自己身上的CanInteractAgain
    public CanInteractAgain canInteractAgain;
    public Image imageA;
    public Image imageB;
    public GameObject Item;

    private bool isShowingA = true;
    public float fadeDuration = 1f;

    void Start()
    {
        canInteractAgain = FindObjectOfType<CanInteractAgain>();
        Item.GetComponent<Button>().interactable = false;
    }
    // 當按鈕被點擊
    public void OnClick()
    {
        if (canInteractAgain.interactCount == 0)
        {
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
            if (Item != null)
            {
                ItemPickUp(fadeInImage);
            }
            yield return null;
        }
        
        isShowingA = !isShowingA; // Toggle the flag
    }
    void ItemPickUp(Image image)
    {
        Item.SetActive(isShowingA);
        Item.GetComponent<Image>().color = image.color;
        Item.GetComponent<Button>().interactable = isShowingA;
    }
}
