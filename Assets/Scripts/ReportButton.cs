using UnityEngine;
using UnityEngine.UI;

public class ReportButton : MonoBehaviour
{
    public GameObject objectToShow;

    void Start()
    {
        // 将按钮点击事件与 ShowObject 方法关联
        GetComponent<Button>().onClick.AddListener(ShowObject);
    }

    void ShowObject()
    {
        // 显示物体
        objectToShow.SetActive(true);
    }
}
