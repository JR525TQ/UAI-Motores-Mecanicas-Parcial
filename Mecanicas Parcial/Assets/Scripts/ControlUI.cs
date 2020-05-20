using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlUI : MonoBehaviour
{

    public Text vida;
    public Text mana;
    public Text puntos;

    public GameObject playerCompleto;

    // Start is called before the first frame update
    void Start()
    {
        playerCompleto = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        vida.text = playerCompleto.GetComponent<ControlJugador>().vida.ToString();
        mana.text = playerCompleto.GetComponent<ControlJugador>().mana.ToString();
        puntos.text = playerCompleto.GetComponent<ControlJugador>().Puntos().ToString();
    }
}
