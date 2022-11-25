using System.Collections;
using Elementary;
using UnityEngine;
using UnityEngine.UI;

public class TextTimerBehaviourView : MonoBehaviour
{
    [SerializeField] 
    private TimerBehaviour timerBehaviour;

    [SerializeField] 
    private Text text;
    
    private void Awake()
    {
        text.gameObject.SetActive(false);
        timerBehaviour.OnStarted += OnStarted;
        timerBehaviour.OnFinished += OnFinished;
    }

    private void OnFinished()
    {
        text.gameObject.SetActive(false);
        StopCoroutine(ShowTimerCoroutine());
    }

    private void OnStarted()
    {
        text.gameObject.SetActive(true);
        StartCoroutine(ShowTimerCoroutine());
    }
    
    private IEnumerator ShowTimerCoroutine()
    {
        while (timerBehaviour.IsPlaying)
        {
            text.text = $"{timerBehaviour.Duration - (int)timerBehaviour.CurrentTime}";
            yield return null;
        }
    }

}
