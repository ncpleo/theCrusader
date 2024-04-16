using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameController : MonoBehaviour
{
    public void OnClickStart()
    {
        SceneManager.LoadScene("3.1_Map");
        print("Started");
    }
}
