using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


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
    public float vida = 100.0f;
    public float mana = 40.0f;
    public float puntosParaGanar = 400.0f;
    private float puntos = 0.0f;

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

        CheckSiEstaVivo();

        CheckGano(puntos);

        MovimientoPlayer();

        Salto();

        if(Input.GetKeyDown(KeyCode.R))
        {
            IniciarEscena(0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CheckTagColeccionable(other);
        CheckTagHeal(other);
    }

    void CheckTagHeal(Collider col)
    {
        if (col.gameObject.CompareTag("Heal"))
        {
            if(vida <= 100)
            {
                if (vida != 100.0f)
                {
                    vida += 10.0f;
                }
                
                mana += 5.0f;
            }
            col.gameObject.SetActive(false);
            Debug.Log("Vida restante: " + vida);
            Destroy(col.gameObject);
        }
    }

    void CheckTagColeccionable(Collider col)
    {
        if (col.gameObject.CompareTag("Coleccionable"))
        {
            rapidez += 1.5f;
            col.gameObject.SetActive(false);
            Destroy(col.gameObject);
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
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movimiento), Time.deltaTime * 7.3f);
            animator.SetBool("estaCorriendo", false);
        }
        

        transform.Translate(movimiento * rapidez * Time.deltaTime, Space.World);
    }

    private bool EstaEnElPiso()
    {
        return Physics.CheckCapsule(capsuleCollider.bounds.center, new Vector3(capsuleCollider.bounds.center.x, capsuleCollider.bounds.min.y,
                            capsuleCollider.bounds.center.z), capsuleCollider.radius* .9f, capaPiso);
    }

    public void RecibirDaño(float daño)
    {
        vida -= daño;
    }

    public void GastarMana(float manaGastado)
    {
        mana -= manaGastado;
    }

    void CheckSiEstaVivo()
    {
        if(vida <= 0)
        {
            gameObject.SetActive(false);
            IniciarEscena(3);
        }
    }

    void IniciarEscena(int escena)
    {
        SceneManager.LoadScene(escena);
    }

    void CheckGano(float puntos)
    {
        if(puntos >= puntosParaGanar)
        {
            IniciarEscena(2);
        }
    }

    public void SumarPuntos(int idEnemy)
    {
        switch(idEnemy)
        {
            case 1: puntos += 15.0f;
                break;
            case 2: puntos += 25.0f;
                break;
            case 3: puntos += 40.0f;
                break;
            default: Debug.Log("id enemy no valido");
                break;
        }
    }

    public float Puntos()
    {
        return puntos;
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


