using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enterBattle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Battle1")
        {
            SceneManager.LoadScene("BattleScene1");

        }
        else if (other.gameObject.tag == "Battle2")
        {
            SceneManager.LoadScene("DialogueScene2");

        }
        else if (other.gameObject.tag == "Battle3")
        {
            SceneManager.LoadScene("3d_EventScene");

        }
        else if (other.gameObject.tag == "Event1")
        {
            SceneManager.LoadScene("EventScene1");
        }
    }
}
