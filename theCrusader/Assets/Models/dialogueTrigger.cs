using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class dialogueTrigger : MonoBehaviour
{
    public CanvasGroup msg;
    AudioSource audioSource;
    public AudioClip click;
    Text LmsgText;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        LmsgText = msg.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (msg.alpha == 1) {
            if (Input.GetMouseButtonDown(0))
            {
                audioSource.PlayOneShot(click);
                Debug.Log(GameObject.Find("shield").GetComponent<Image>().enabled);
                if (LmsgText.text.StartsWith("Hey"))
                {
                    //GameObject.Find("shield").GetComponent<Image>().enabled = true;
                    LmsgText.text = "Shield: Defence + 1" + "\r\n" + "											¡¿";
                }
                else
                {
                    msg.alpha = 0;
                    GameObject.Find("shield").GetComponent<Image>().enabled = false;
                    SceneManager.LoadScene("BattleScene2");

                }

            }
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

    private void OnTriggerEnter(Collider other)
    {
        if (msg.alpha == 0)
        {
            StartCoroutine(FadeIn(msg, 1f));
        }       
        
    }
}
