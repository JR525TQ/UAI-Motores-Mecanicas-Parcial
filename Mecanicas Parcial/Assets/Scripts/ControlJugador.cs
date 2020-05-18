using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ControlJugador : MonoBehaviour
{

 // private NavMeshAgent navMeshAgent;
    private CapsuleCollider capsuleCollider;
    private Rigidbody rb;
    public LayerMask capaPiso;
    public Camera cam;
    public float magnitudSalto;

    // Start is called before the first frame update
    void Start()
    {
     // navMeshAgent = GetComponent<NavMeshAgent>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray rayo = cam.ScreenPointToRay(Input.mousePosition);

        ClickToMove(rayo);

        Salto();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coleccionable"))
        {
            /*vMeshAgent.acceleration += 20;
            navMeshAgent.speed += 20;
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);*/
        }
    }

    void Salto()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * magnitudSalto, ForceMode.Impulse);
        }
    }

    void ClickToMove(Ray rayo)
    {
        RaycastHit hit;

        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(rayo, out hit))
                {
                // navMeshAgent.destination = hit.point;
                }            
        }
    }
}


