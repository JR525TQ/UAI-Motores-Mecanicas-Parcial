using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemigo : MonoBehaviour
{

    public float speed;
    public float stoppingDistance;

    private float tiempoDisparos;
    public float startTiempoDisparos;

    public GameObject proyectil;

    private Transform player;

    public float vida = 50f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        tiempoDisparos = startTiempoDisparos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, player.rotation, speed * Time.deltaTime);
        }

        if(tiempoDisparos <= 0)
        {
            Instantiate(proyectil, transform.position, Quaternion.identity);
            tiempoDisparos = startTiempoDisparos;
        }
        else
        {
            tiempoDisparos -= Time.deltaTime;
        }

        if(vida <= 0)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    public void RecibirDaño(float daño)
    {
        vida -= daño;
    }
}
