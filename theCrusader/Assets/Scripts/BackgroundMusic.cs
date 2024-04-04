using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [HideInInspector]  public AudioSource audioSource;
    public bool fadeIn;
    public float fadeTime;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeIn) {
            StartCoroutine(BackgroundMusic.FadeIn(audioSource, fadeTime));
            fadeIn = !fadeIn;
        }
    }

    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < FadeTime)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, 0, currentTime / FadeTime);
            yield return null;
        }
        audioSource.Stop();
        audioSource.volume = start;
        yield break;
    }

    public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
    {
        float currentTime = 0;
        float target = audioSource.volume;
        while (currentTime < FadeTime)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0, target, currentTime / FadeTime);
            yield return null;
        }
        yield break;
    }
}
