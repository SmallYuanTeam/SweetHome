using UnityEngine;
using UnityEngine.UI;

public class Return : MonoBehaviour
{
    public GameObject objectToHide;

    void Start()
    {
        // 将按钮点击事件与 HideObject 方法关联
        GetComponent<Button>().onClick.AddListener(HideObject);
    }

    void HideObject()
    {
        // 隐藏物体
        objectToHide.SetActive(false);
    }
}
