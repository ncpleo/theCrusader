using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class AutoScroll : MonoBehaviour
{
    float speed = 75.0f;
    //float textPosBegin = -1450.0f;
    float boundaryTextEnd = 1450.0f;

    RectTransform rectTransform;
    [SerializeField]
    TextMeshProUGUI mainText;

    public BackgroundMusic bgm;


    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (rectTransform.localPosition.y < boundaryTextEnd)
        {
            rectTransform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            StartCoroutine(BackgroundMusic.FadeOut(bgm.audioSource, 3f));
            if (!bgm.audioSource.isPlaying)
            {
                SceneManager.LoadScene("DialogueScene1");
            }

        }
    }

    
}
