using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControlEnemigo : MonoBehaviour
{

    public float speed;
    public float stoppingDistance;

    public float vida = 50f;
    public int idEnemy;

    public float startTiempoDisparos;
    public float rango = 15;

    public GameObject proyectil;

    private float tiempoDisparos;
    private Transform player;
    private GameObject playerCompleto;

    // Start is called before the first frame update
    void Start()
    {
        playerCompleto = GameObject.FindGameObjectWithTag("Player");
        tiempoDisparos = startTiempoDisparos;
    }

    // Update is called once per frame
    void Update()
    {

        float distancia = Vector3.Distance(transform.position, playerCompleto.transform.position);

        if (Vector3.Distance(transform.position, playerCompleto.transform.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerCompleto.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, playerCompleto.transform.rotation, speed * Time.deltaTime);
        }

        if (tiempoDisparos <= 0 && distancia < rango)
        {
            Instantiate(proyectil, transform.position, Quaternion.identity);
            tiempoDisparos = startTiempoDisparos;
        }
        else
        {
            tiempoDisparos -= Time.deltaTime;
        }

        CheckVida();
    }

    public void CheckVida()
    {
        if (vida <= 0)
        {     
            gameObject.SetActive(false);
            Destroy(gameObject);
            playerCompleto.GetComponent<ControlJugador>().SumarPuntos(idEnemy);

        }
    }

    public void RecibirDaño(float daño)
    {
        vida -= daño;
        Debug.Log("La vida del enemigo es: " + vida);
    }
}
