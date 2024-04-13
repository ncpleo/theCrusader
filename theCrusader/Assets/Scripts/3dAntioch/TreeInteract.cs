using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteract : MonoBehaviour
{
    CanvasGroup guide;
    bool triggered = false;
    public AudioClip get;
    AudioSource audioSource;
    SceneAntiochController controller;
    
    // Start is called before the first frame update
    void Start()
    {
        guide = GameObject.Find("GuideText").GetComponent<CanvasGroup>();
        audioSource = GameObject.Find("Canvas").GetComponent<AudioSource>();
        controller = GameObject.Find("SceneController").GetComponent<SceneAntiochController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (guide.alpha == 1 && !triggered) {
            if (Input.GetMouseButtonDown(0)) { 
                audioSource.PlayOneShot(get);

                if(controller.timber<5)
                    controller.timber++;
                if(controller.fruit<3)
                    if (this.tag == "Apple")
                        controller.fruit++;

                guide.alpha = 0;
                triggered = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        guide.alpha = 1;
    }

    private void OnTriggerExit(Collider other)
    {
        
        guide.alpha = 0;
    }
}
