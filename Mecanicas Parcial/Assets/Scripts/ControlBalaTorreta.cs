using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBalaTorreta : MonoBehaviour
{

    public float damage = 20.0f;
    public float speed = 20f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<ControlEnemigo>().RecibirDaño(damage);
            Debug.Log("Vida restante: "+ other.gameObject.tag + other.gameObject.GetComponent<ControlEnemigo>().vida);
            Destroy(gameObject);
        }
    }
}
