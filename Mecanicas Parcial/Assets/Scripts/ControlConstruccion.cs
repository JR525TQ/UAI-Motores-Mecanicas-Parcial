using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlConstruccion : MonoBehaviour
{
    public GameObject torreta;

    private GameObject player;
    private ControlJugador jugador;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if(player.GetComponent<ControlJugador>().mana >= 10.0f)
            {
                Instantiate(torreta, new Vector3(transform.position.x, 0.07f, transform.position.z) , Quaternion.identity);
                player.GetComponent<ControlJugador>().GastarMana(10);
            } else {
                Debug.Log("El mana no es suficiente");
            }              
        }

    }
}
