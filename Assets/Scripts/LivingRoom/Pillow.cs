using UnityEngine;
using System.Collections;

public class Pillow : MonoBehaviour
{
    public GameObject pillow;
    void Start()
    {
        pillow = GameObject.Find("Pillow");
    }
    public void OnPillowClick()
    {
        pillow.SetActive(false);
    }
}