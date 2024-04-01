using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{
    Camera _camera;
    NavMeshAgent _agent;

    public LayerMask ground;



    private void Start()
    {
        _camera = Camera.main;
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit _hit;
            Ray _ray = _camera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(_ray, out _hit, Mathf.Infinity, ground))
            {                
                _agent.SetDestination(_hit.point);
                
            }
        }

    }

}
