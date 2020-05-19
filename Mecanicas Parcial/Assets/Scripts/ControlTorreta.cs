using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTorreta : MonoBehaviour
{
    public float speedDisparo;
    public float damage = 20.0f;
    public float rango = 15.0f;

    private Vector3 target;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void UpdateTarget()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rango);
    }
}
