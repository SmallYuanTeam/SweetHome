using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class QTESequenceController : MonoBehaviour
{
    public List<Image> qteImages;
    public int sequenceLength = 3;
    private List<KeyCode> currentSequence = new List<KeyCode>();
    private bool isSequenceActive = false;
    public bool isSequenceCompleted = false;
    public float timeBetweenSequences = 2f;

    private Dictionary<KeyCode, string> keyCodeToResourcePath = new Dictionary<KeyCode, string>()
    {
        { KeyCode.UpArrow, "QTE/Up" },
        { KeyCode.DownArrow, "QTE/Down" },
        { KeyCode.LeftArrow, "QTE/Left" },
        { KeyCode.RightArrow, "QTE/Right" }
    };

    private int currentIndex = 0;

    void Start()
    {
        //StartNewSequence();
    }

    void Update()
    {
        if (isSequenceActive && currentSequence.Count > 0)
        {
            isSequenceCompleted = false;
            KeyCode expectedKey = currentSequence[currentIndex];
            if (Input.GetKeyDown(expectedKey))
            {
                // 正确的按键被按下
                qteImages[currentIndex].gameObject.SetActive(false);
                currentIndex++;

                if (currentIndex >= currentSequence.Count)
                {
                    Debug.Log("QTE Sequence Completed Successfully!");
                    isSequenceActive = false;
                    StartCoroutine(WaitAndStartNewSequence(timeBetweenSequences));
                    isSequenceCompleted = true;
                }
            }
            else if (Input.anyKeyDown)
            {

                Debug.Log("Incorrect Key Pressed. Resetting QTE...");
                ResetQTE();
            }
        }
    }

    IEnumerator WaitAndStartNewSequence(float delay)
    {
        isSequenceActive = false;
        HideAllQTEImages();
        yield return new WaitForSeconds(delay);
        StartNewSequence();
    }

    public void StartNewSequence()
    {
        currentIndex = 0;
        isSequenceActive = true;
        currentSequence.Clear();
        HideAllQTEImages();

        for (int i = 0; i < sequenceLength; i++)
        {
            KeyCode randomKey = GetRandomKeyCode();
            currentSequence.Add(randomKey);
            if(i < qteImages.Count) {
                UpdateQTEImage(i, randomKey);
            }
        }

        Debug.Log("New QTE Sequence Started: " + string.Join(", ", currentSequence));
    }
    public void SetUpQTESetting(int sequenceLength, float timeBetweenSequences)
    {
        this.sequenceLength = sequenceLength;
        this.timeBetweenSequences = timeBetweenSequences;
    }
    KeyCode GetRandomKeyCode()
    {
        List<KeyCode> keys = new List<KeyCode>(keyCodeToResourcePath.Keys);
        return keys[Random.Range(0, keys.Count)];
    }

    void UpdateQTEImage(int index, KeyCode keyCode)
    {
        if (keyCodeToResourcePath.TryGetValue(keyCode, out string path))
        {
            Sprite sprite = Resources.Load<Sprite>(path);
            if (sprite != null)
            {
                qteImages[index].sprite = sprite;
                qteImages[index].gameObject.SetActive(true);
            }
        }
    }

    void HideAllQTEImages()
    {
        foreach (var img in qteImages)
        {
            img.gameObject.SetActive(false);
        }
    }

    void ResetQTE()
    {
        StartCoroutine(WaitAndStartNewSequence(timeBetweenSequences));
    }
}
