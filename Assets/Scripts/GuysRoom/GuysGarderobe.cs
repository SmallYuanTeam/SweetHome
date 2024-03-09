using UnityEngine;
using UnityEngine.UI;


public class GuysGarderobe : MonoBehaviour
{
    // 自己身上的CanInteractAgain
    public CanInteractAgain canInteractAgain;

    void Start()
    {
        canInteractAgain = FindObjectOfType<CanInteractAgain>();
    }
    // 當按鈕被點擊
    public void OnClick()
    {
        if (canInteractAgain.interactCount >= 0)
        {
            //改變Garderobe自己的圖片

            gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/GuysGarderobe/GarderobeOpen");

        }
    }
}
