using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody rb;
    float xInput, yInput, angle;
    float moveSpeed = 20f;
    float lookSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;

        
    }

    // Update is called once per frame
    void Update()
    {
        //xInput = Input.GetAxis("Horizontal");
        //yInput = Input.GetAxis("Vertical");

        //rb.velocity = new Vector3(yInput * moveSpeed, rb.position.y, xInput * moveSpeed);

        //angle += Input.GetAxis("Mouse X") * lookSpeed * -Time.deltaTime;
        //angle = Mathf.Clamp(angle, -180, 180);
        //transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);

        xInput += Input.GetAxis("Mouse X") * lookSpeed;
        yInput += Input.GetAxis("Mouse Y") * lookSpeed;
        transform.localRotation = Quaternion.Euler(0, xInput, 0);
        transform.GetChild(0).localRotation = Quaternion.Euler(-yInput, 0, 0);

        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * moveSpeed * Time.deltaTime);

    }
}
