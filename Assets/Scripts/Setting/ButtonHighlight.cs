using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ButtonHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Image targetImage;
    public HighlightController highlightController;
    public float fadeSpeed = 1f;

    private void Start()
    {
        if (targetImage != null)
        {
            // 初始化图像为完全透明
            Color c = targetImage.color;
            c.a = 0;
            targetImage.color = c;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines(); // 停止所有正在进行的淡入淡出协程
        StartCoroutine(FadeImageToFullAlpha()); // 启动淡入效果
        if(highlightController != null)
        {
            highlightController.MoveToButton(this.GetComponent<RectTransform>()); // 通知HighlightController移动高亮到当前按钮
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines(); // 同上
        StartCoroutine(FadeImageToZeroAlpha()); // 启动淡出效果
        if(highlightController != null)
        {
            highlightController.MoveHighlightToDefaultPosition(); // 通知HighlightController将高亮移回默认位置
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        StopAllCoroutines();
        if(highlightController != null)
        {
            highlightController.MoveHighlightToDefaultPosition();
        }
    }

    IEnumerator FadeImageToFullAlpha()
    {
        while (targetImage.color.a < 1.0f)
        {
            Color newColor = targetImage.color;
            newColor.a += Time.deltaTime * fadeSpeed;
            targetImage.color = newColor;
            yield return null;
        }
    }

    IEnumerator FadeImageToZeroAlpha()
    {
        while (targetImage.color.a > 0.0f)
        {
            Color newColor = targetImage.color;
            newColor.a -= Time.deltaTime * fadeSpeed;
            targetImage.color = newColor;
            yield return null;
        }
    }
}
