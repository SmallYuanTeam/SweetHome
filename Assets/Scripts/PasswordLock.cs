using UnityEngine;
using UnityEngine.UI; // 需要使用 UI 命名空间
using System.Collections.Generic; // 使用列表
using TMPro; // 使用 TextMeshProUGUI

public class PasswordLock : MonoBehaviour
{
    public List<Button> numberButtons;
    public Button confirmButton;
    public Button deleteButton;
    public TextMeshProUGUI inputDisplay;
    public bool isLocked = true; 
    public string correctPassword = "1120";
    private string userInput = "";
    Safe safe;
    void Start()
    {
        safe = GameObject.Find("Safe").GetComponent<Safe>();
        for (int i = 0; i < numberButtons.Count; i++)
        {
            int index = i;
            numberButtons[i].onClick.AddListener(() => AddDigitToInput(index.ToString()));
        }

        confirmButton.onClick.AddListener(CheckPassword);

        deleteButton.onClick.AddListener(DeleteLastDigit);
    }

    void AddDigitToInput(string digit)
    {
        if (userInput.Length < 4)
        {
            userInput += digit;
            UpdateDisplay();
        }
    }

    void DeleteLastDigit()
    {
        if (userInput.Length > 0)
        {
            userInput = userInput.Substring(0, userInput.Length - 1);
            UpdateDisplay();
        }
    }

    void CheckPassword()
    {
        if (userInput == correctPassword)
        {
            Debug.Log("Password correct!");
            isLocked = false;
            safe.OnClick();
        }
        else
        {
            Debug.Log("Password incorrect!");
        }
        userInput = "";
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        inputDisplay.text = userInput;
    }

}
