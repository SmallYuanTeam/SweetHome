using System.Collections;
using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine.UI;

public class TransitionHelper : MonoBehaviour
{
    private ProCamera2DTransitionsFX transitionsFX;
    void Awake()
    {
        transitionsFX = ProCamera2DTransitionsFX.Instance; 
    }
    public IEnumerator BackgroundTransitionCoroutine(string ImageName, GameObject Background)
    {
        transitionsFX.TransitionExit();
        yield return new WaitForSeconds(transitionsFX.DurationExit);

        yield return null;

        Background.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/Story/{ImageName}");
        transitionsFX.TransitionEnter();
    }
}