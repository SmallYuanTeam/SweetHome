using UnityEngine;

public class SetCanvasCamera : MonoBehaviour
{
    void Start()
    {
        // 找到标记为MainCamera的相机
        Camera mainCamera = Camera.main;

        // 获取此游戏对象上的Canvas组件
        Canvas canvas = GetComponent<Canvas>();

        // 检查确保Canvas和相机都找到了
        if (canvas != null && mainCamera != null)
        {
            // 将Canvas的渲染相机设置为MainCamera
            canvas.worldCamera = mainCamera;
        }
        else
        {
            Debug.LogWarning("MainCamera或Canvas没有找到！");
        }
    }
}
