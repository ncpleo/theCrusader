using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SpriteHover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter() {
        transform.localScale = new Vector3(1.25f, 1.25f, 1.0f);
    }

    void OnMouseExit() {
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    private void OnMouseDown()
    {
        if (SceneManager.GetActiveScene().name == "3.1_Map")
            SceneManager.LoadScene("3.3_Constinople");
        else if (SceneManager.GetActiveScene().name == "3.2_Map")
        {
            StartCoroutine(GameObject.Find("SceneController").GetComponent<Scene32Controller>().FadeIn(GameObject.Find("Window").GetComponent<CanvasGroup>(), 0.2f));
            //SceneManager.LoadScene("BattleScene2");
        }

    }
}
