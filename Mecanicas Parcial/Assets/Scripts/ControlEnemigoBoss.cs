using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemigoBoss : ControlEnemigo
{

    public float daño;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, GameObject.FindGameObjectWithTag("Player").transform.rotation, speed * Time.deltaTime);
        }

        CheckVida();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<ControlJugador>().RecibirDaño(daño);
            Debug.Log("Vida restante: " + other.gameObject.GetComponent<ControlJugador>().vida);
            Destroy(gameObject);
        }
    }
}
