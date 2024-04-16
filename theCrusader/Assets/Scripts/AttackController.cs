using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttackController : MonoBehaviour
{
    public Transform targetToAttack;
    private GameObject obj;

    public bool win = false;
    [SerializeField] static int level = 0;

    private void Start()
    {
        obj = this.gameObject;
    }

    private void Update()
    {
        ChangeScene();
    }

    void ChangeScene() {
        if (win)
        {
            if (SceneManager.GetActiveScene().name == "3.3_Constinople")
            {
                return;
            }

            level++;
            if (level == 1)
            {
                SceneManager.LoadScene("CelebrateScene");
            }
            else if (level == 2)
            {
                SceneManager.LoadScene("CelebrateScene");
            }
            else if (level == 3)
            {
                SceneManager.LoadScene("CelebrateScene");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (obj.CompareTag("Army1")) {
            if(other.CompareTag("Enemy") && targetToAttack == null)
            {
                targetToAttack = other.transform;
            }
        }
        else
        {
            if (other.CompareTag("Army1") && targetToAttack == null)
            {
                targetToAttack = other.transform;
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (obj.CompareTag("Army1"))
        {
            if (other.CompareTag("Enemy") && targetToAttack != null)
            {
                targetToAttack = null;
                
            }
        }
        else
        {
            if (other.CompareTag("Army1") && targetToAttack != null)
            {
                targetToAttack = null;
            }
        }
    }
}
