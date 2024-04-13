using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTavernController : MonoBehaviour
{
    CanvasGroup msg, option;
    AudioSource audioSource;
    public AudioClip click;

    // Start is called before the first frame update
    void Start()
    {
        msg = GameObject.Find("Messagebox (1)").GetComponent<CanvasGroup>();
        option = GameObject.Find("Optionbox").GetComponent<CanvasGroup>();
        audioSource = GameObject.Find("Canvas").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (msg.alpha == 1) {
            if (Input.GetMouseButtonDown(0))
            {
                audioSource.PlayOneShot(click);
                if (msg.GetComponentInChildren<Text>().text.StartsWith("So"))
                {
                    msg.GetComponentInChildren<Text>().text = "Why would I help you?\r\nWhat benefit are you offering me?" + "\r\n	                                    											¡¿";
                    option.alpha = 1;
                }
            }
        }
    }

    public void Wine() {
        msg.GetComponentInChildren<Text>().text = "Great! I think we're gonna be best friends." + "\r\n	               						                                        					¡¿";
        option.alpha = 0;
        SceneManager.LoadScene("3d_nightBattle");
    }

    public void Gold() {
        msg.GetComponentInChildren<Text>().text = "Hilarious! Do I look like I care about money?\r\nThink of other." + "\r\n	                                                        											¡¿";
    }
}
