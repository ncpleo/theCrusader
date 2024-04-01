using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uirotation : MonoBehaviour
{
    private Transform trans;
    private Vector3 offset = new Vector3(0, 180, 0);

    void Start()
    {
        trans = GameObject.Find("Camera").GetComponent<Transform>();
    }

    void Update()
    {
        transform.LookAt(trans);
        transform.Rotate(offset);
    }
}
