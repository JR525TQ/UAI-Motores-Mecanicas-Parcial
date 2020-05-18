﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ControlJugador : MonoBehaviour
{

  //private NavMeshAgent navMeshAgent;
    private CapsuleCollider capsuleCollider;
    private Rigidbody rb;
    private Animator animator;
    public Camera cam;
    public LayerMask capaPiso;
    public float magnitudSalto;
    public float rapidez;

    // Start is called before the first frame update
    void Start()
    {
      //navMeshAgent = GetComponent<NavMeshAgent>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*Ray rayo = cam.ScreenPointToRay(Input.mousePosition);
        ClickToMove(rayo);*/

        MovimientoPlayer();

        Salto();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coleccionable"))
        {
            /*vMeshAgent.acceleration += 20;
            navMeshAgent.speed += 20;*/
            rapidez += 1.5f;
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
    }

    void Salto()
    {
        if (Input.GetKeyDown(KeyCode.Space) && EstaEnElPiso())
        {
            rb.AddForce(Vector3.up * magnitudSalto, ForceMode.Impulse);
        }
    }

    void MovimientoPlayer()
    {
        Vector3 direcciones = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
        Vector3 movimiento = cam.transform.InverseTransformDirection(direcciones);
        movimiento.y = 0.0f;
        movimiento.Normalize();

        if(movimiento != Vector3.zero)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movimiento), Time.deltaTime * 7.3f);
            animator.SetBool("estaCorriendo", true);
        } else {
            animator.SetBool("estaCorriendo", false);
        }
        

        transform.Translate(movimiento * rapidez * Time.deltaTime, Space.World);
    }

    private bool EstaEnElPiso()
    {
        return Physics.CheckCapsule(capsuleCollider.bounds.center, new Vector3(capsuleCollider.bounds.center.x, capsuleCollider.bounds.min.y,
                            capsuleCollider.bounds.center.z), capsuleCollider.radius* .9f, capaPiso);
    }

       //No encontre manera de saltar con la barra espaciadora y mover el personaje con navmesh al mismo tiempo.
/*   void ClickToMove(Ray rayo)
    {
        RaycastHit hit;

        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(rayo, out hit))
                {
                    navMeshAgent.destination = hit.point;
                }            
        }
    }
*/

}


