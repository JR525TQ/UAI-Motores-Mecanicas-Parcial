using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemigo : MonoBehaviour
{

    public float speed;
    public float stoppingDistance;

    private float tiempoDisparos;
    public float startTiempoDisparos;
    public float rango = 15;

    public GameObject proyectil;

    private Transform player;

    public float vida = 50f;

    public GameObject playerCompleto;

    public int idEnemy;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerCompleto = GameObject.FindGameObjectWithTag("Player");
        tiempoDisparos = startTiempoDisparos;
    }

    // Update is called once per frame
    void Update()
    {

        float distancia = Vector3.Distance(transform.position, player.position);

        if (Vector3.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, player.rotation, speed * Time.deltaTime);
        }

        if(tiempoDisparos <= 0 && distancia < rango)
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
