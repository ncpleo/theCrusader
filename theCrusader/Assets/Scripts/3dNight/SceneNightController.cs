using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNightController : MonoBehaviour
{
    CanvasGroup msg;
    AudioSource audioSource;
    public AudioClip click;

    // Start is called before the first frame update
    void Start()
    {
        msg = GameObject.Find("Messagebox (1)").GetComponent<CanvasGroup>();
        audioSource = GameObject.Find("Canvas").GetComponent<AudioSource>();
        StartCoroutine(FadeIn(msg, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(click);
            msg.alpha = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("MapScene4");
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
        yield break;
    }
}
