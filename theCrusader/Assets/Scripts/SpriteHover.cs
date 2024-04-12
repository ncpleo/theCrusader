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
        SceneManager.LoadScene("BattleScene1");
    }
}
