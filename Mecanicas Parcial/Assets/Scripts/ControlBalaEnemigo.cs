using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBalaEnemigo : MonoBehaviour
{
    public float speed;
    public float damage = 10.0f;

    private GameObject player;
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(target == transform.position)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<ControlJugador>().RecibirDaño(damage);
            Debug.Log("Vida restante: " + other.gameObject.GetComponent<ControlJugador>().vida);
            Destroy(gameObject);
        }
    }

    public GameObject getPlayer()
    {
        return player;
    }

    public Vector3 getTarget()
    {
        return target;
    }
}
