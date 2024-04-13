using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene33Controller : MonoBehaviour
{
    AudioSource audioSource;
    int fadeIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("Canvas").GetComponent<AudioSource>();
        StartCoroutine(FadeIn(GameObject.Find("Panel").GetComponent<CanvasGroup>(), 1f));
        StartCoroutine(AudioEnd());
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeIndex == 2) {
            SceneManager.LoadScene("3.2_Map");
        }
    }

    IEnumerator FadeIn(CanvasGroup img, float FadeTime)
    {
        float currentTime = 0;
        //float target = img.alpha;
        while (currentTime < FadeTime)
        {
            currentTime += Time.deltaTime;
            img.alpha = Mathf.Lerp(0, 1, currentTime / FadeTime);
            yield return null;
        }
        fadeIndex++;
        yield break;
    }

    IEnumerator AudioEnd()
    {
        yield return new WaitUntil(() => audioSource.isPlaying == false);
        Debug.Log("end");
        StartCoroutine(FadeIn(GameObject.Find("Blackfade").GetComponent<CanvasGroup>(), 1f));
    }
}
