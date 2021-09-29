using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class Player_Movement : MonoBehaviour
{
    public NavMeshAgent agent;

    public float rotateSpeedMovement = 0.1f;
    float rotateVelocity;

    private void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            //Checking if the raycast shot hits something that uses the navmesh system.
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                //if (hit.collider.tag == "Floor")
                {
                    //MOVEMENT
                    agent.SetDestination(hit.point);                   
                    //agent.stoppingDistance = 0;

                    //ROTATION
                    Quaternion rotationToLookAt = Quaternion.LookRotation(hit.point - transform.position);
                    float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                        rotationToLookAt.eulerAngles.y,
                        ref rotateVelocity,
                        rotateSpeedMovement * (Time.deltaTime * 5));

                    transform.eulerAngles = new Vector3(0, rotationY, 0);
                }

            }


        }
    }

}
