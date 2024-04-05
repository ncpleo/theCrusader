using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip press;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();    
    }
    public void Hover() {
        audioSource.PlayOneShot(press);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
