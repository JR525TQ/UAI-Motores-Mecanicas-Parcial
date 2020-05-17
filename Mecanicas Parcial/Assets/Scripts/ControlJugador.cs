using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControlJugador : MonoBehaviour
{

    private Animator animator;

    private NavMeshAgent navMeshAgent;

    public Camera cam;

    private bool isRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray rayo = cam.ScreenPointToRay(Input.mousePosition);

        ClickToMove(rayo);
    }

    void ClickToMove(Ray rayo)
    {
        RaycastHit hit;

        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(rayo, out hit, 400))
            {
                navMeshAgent.destination = hit.point;
            }
        }

        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            isRunning = false;
        }
        else
        {
            isRunning = true;
        }

        animator.SetBool("isRunning", isRunning);
    }
}


