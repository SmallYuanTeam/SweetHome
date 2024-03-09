using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AlphaClickableImage : Image, IPointerClickHandler
{
    public float alphaThreshold = 0.1f;

    protected override void Awake()
    {
        base.Awake();
        this.alphaHitTestMinimumThreshold = alphaThreshold;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!IsActive() || !IsRaycastLocationValid(eventData.position, eventData.pressEventCamera))
        {
            return;
        }
    }
}
