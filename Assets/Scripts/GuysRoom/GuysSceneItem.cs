using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class GuysSceneItem : MonoBehaviour
{
    // 自己身上的CanInteractAgain
    public CanInteractAgain canInteractAgain;
    public GameObject imageA;
    public GameObject imageB;
    public string Item;
    public string Room;
    public string ItemID;

    private bool isShowingA = true;
    public float fadeDuration = 1f;
    Player player;
    Dialog Dialog;
    void Start()
    {
        canInteractAgain = FindObjectOfType<CanInteractAgain>();
        player = FindObjectOfType<Player>();
        Dialog = GameObject.Find("Dialog").GetComponent<Dialog>();
    }
    // 當按鈕被點擊
    public void OnClick()
    {
        // 如果玩家已經獲得物品 或 物品沒有資料
        if (player.HasObtainedItem(Item) || Item == "")
        {
            if (canInteractAgain.interactCount == 0)
            {
                StartCoroutine(FadeTransition(imageA, imageB));
            }
        }
        else
        {
            Dialog.GetRoomItem(Room, ItemID);
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
}
