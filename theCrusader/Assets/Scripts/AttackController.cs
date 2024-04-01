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
        if (win)
        {         
            level++;
            if (level == 1)
            {
                SceneManager.LoadScene("MapScene2");
            }
            else if (level == 2)
            {
                SceneManager.LoadScene("MapScene3");
            }else if (level == 3)
            {
                SceneManager.LoadScene("WinScene");
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
