using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    public List<GameObject> columnA; // 列A的按钮列表
    public List<GameObject> columnB; // 列B的按钮列表
    private string storedText = ""; // 用于存储唯一文字

    private void Start()
    {
        // 设置列A按钮的OnClick事件
        for (int i = 0; i < columnA.Count; i++)
        {
            int index = i; // 为了避免闭包问题，必须使用一个局部变量存储循环变量的值
            Button button = columnA[i].GetComponent<Button>();
            button.onClick.AddListener(() => OnAClicked(index));
        }

        // 设置列B按钮的OnClick事件
        for (int i = 0; i < columnB.Count; i++)
        {
            int index = i; // 为了避免闭包问题，必须使用一个局部变量存储循环变量的值
            Button button = columnB[i].GetComponent<Button>();
            button.onClick.AddListener(() => OnBClicked(index));
        }
    }

    public void OnAClicked(int index)
    {
        // 获取列A中特定索引位置的按钮
        GameObject button = columnA[index];
        
        // 检查是否附加了TextMeshPro组件
        TextMeshProUGUI tmp = button.GetComponentInChildren<TextMeshProUGUI>();
        if (tmp != null)
        {
            // 获取按钮上的文字并存储
            storedText = tmp.text;
        }
    }

    public void OnBClicked(int index)
    {
        // 获取列B中特定索引位置的按钮
        GameObject button = columnB[index];
        
        // 检查是否附加了TextMeshPro组件
        TextMeshProUGUI tmp = button.GetComponentInChildren<TextMeshProUGUI>();
        if (tmp != null)
        {
            // 将存储的文字设置到按钮上
            tmp.text = storedText;
            // 清空存储的文字
            storedText = "";
        }
    }
}
