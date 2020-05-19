using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTorreta : MonoBehaviour
{
    public float rango = 15.0f;
    public float vida = 70.0f;
    public GameObject proyectil;

    private float tiempoDisparos;
    public float startTiempoDisparos;

    [SerializeField]
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0.0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float masCercano = Mathf.Infinity;
        GameObject enemigoMasCercano = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < masCercano)
            {
                masCercano = distanceToEnemy;
                enemigoMasCercano = enemy;
            }
        }

        if(enemigoMasCercano != null && masCercano <= rango)
        {
            target = enemigoMasCercano;
        } else
        {
            target = null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            return;
        }
        Vector3 vista = target.transform.position - transform.position;
        Quaternion vistaRotacion = Quaternion.LookRotation(vista);

        Vector3 rotation = vistaRotacion.eulerAngles;

        transform.rotation = Quaternion.Euler(0.0f, rotation.y, 0.0f);

        if (tiempoDisparos <= 0)
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
            Destroy(gameObject);
        }
    }

    public void RecibirDaño(float daño)
    {
        vida -= daño;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rango);
    }

    public GameObject Target()
    {
        return target;
    }
}
