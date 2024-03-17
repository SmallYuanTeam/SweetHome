using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class HighlightController : MonoBehaviour
{
    public RectTransform highlightRect; // 高亮的RectTransform
    public RectTransform defaultPositionRect; // 预设位置的RectTransform
    public float transitionSpeed = 10.0f; // 高亮移动的速度

    private RectTransform targetButtonRect = null; // 目标按钮的RectTransform

    private void Start()
    {
        // 如果需要，可以在这里初始化高亮的位置到defaultPositionRect的位置
        MoveHighlightToDefaultPosition();
    }
    public void MoveToButton(RectTransform buttonRect)
    {
        StopAllCoroutines();
        targetButtonRect = buttonRect;
        StartCoroutine(MoveHighlight());
    }

    IEnumerator MoveHighlight()
    {
        Vector2 targetPosition;

        if (targetButtonRect != null)
        {
            // 为目标按钮的Y轴位置加上192的偏移
            float targetY = targetButtonRect.anchoredPosition.y + 192; // 加上固定偏移量
            targetPosition = new Vector2(highlightRect.anchoredPosition.x, targetY);
        }
        else
        {
            // 对于默认位置也做相同的处理，如果需要
            float defaultY = defaultPositionRect.anchoredPosition.y + 192; // 同样加上固定偏移量
            targetPosition = new Vector2(highlightRect.anchoredPosition.x, defaultY);
        }

        while (Vector2.Distance(highlightRect.anchoredPosition, targetPosition) > 0.01f)
        {
            highlightRect.anchoredPosition = Vector2.MoveTowards(highlightRect.anchoredPosition, targetPosition, transitionSpeed * Time.deltaTime);
            yield return null;
        }
        highlightRect.anchoredPosition = targetPosition;
    }


    // 用于初始化或重置高亮位置到默认位置的方法
    public void MoveHighlightToDefaultPosition()
    {
        if (defaultPositionRect != null)
        {
            // 启动协程，平滑移动到默认位置
            StopAllCoroutines(); // 停止当前的所有协程，确保不会有多个移动操作同时进行
            StartCoroutine(MoveHighlightTo(defaultPositionRect.anchoredPosition.y)); // 假设你想在Y轴上加192的偏移
        }
    }
    IEnumerator MoveHighlightTo(float targetY)
    {
        Vector2 targetPosition = new Vector2(highlightRect.anchoredPosition.x, targetY);
        while (Vector2.Distance(highlightRect.anchoredPosition, targetPosition) > 0.01f)
        {
            highlightRect.anchoredPosition = Vector2.MoveTowards(highlightRect.anchoredPosition, targetPosition, transitionSpeed * Time.deltaTime);
            yield return null;
        }
    }


}
