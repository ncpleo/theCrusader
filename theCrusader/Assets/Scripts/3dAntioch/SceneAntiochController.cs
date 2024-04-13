using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneAntiochController : MonoBehaviour
{
    CanvasGroup msg, mission;
    AudioSource audioSource;
    public AudioClip click;
    public int timber, fruit = 0;
    Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        msg = GameObject.Find("Messagebox (1)").GetComponent<CanvasGroup>();
        mission = GameObject.Find("Missions").GetComponent<CanvasGroup>();
        audioSource = GameObject.Find("Canvas").GetComponent<AudioSource>();
        anim = GameObject.Find("Canvas").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (msg.alpha == 1) {
            if (Input.GetMouseButtonDown(0)) {
                audioSource.PlayOneShot(click);
                msg.alpha = 0;
                if (timber == 0)
                    mission.alpha = 1;
                else
                {
                    anim.SetTrigger("Fade");
                    SceneManager.LoadScene("3d_Interactive");
                }
            }
        }

        if (mission.alpha == 1) {
            mission.GetComponentInChildren<Text>().text = "Timber	("+timber+"/5)" + "\r\n" + "Fruit		("+fruit+"/3) ";
        }

        if (timber > 4 && fruit > 2 && mission.alpha==1) { 
            msg.GetComponentInChildren<Text>().text = "Alright, I guess these are enough for now." + "\r\n" + "Let's think of how to get inside those walls." + "\r\n" + "\r\n" + "It doesn't seems possible to break in directly." + "\r\n" + "I heard that the commander of the Antioch army loves wine." + "\r\n" + "Perhaps we could be good partners." + "\r\n" + "																							¡¿";
            msg.alpha = 1;
            mission.alpha = 0;
        }
    }
}
