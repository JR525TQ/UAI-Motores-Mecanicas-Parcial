using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBalaTorreta : MonoBehaviour
{
    public float damage;
    public float rango = 15.0f;
    public float speedDisparo;

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
            if (distanceToEnemy < masCercano)
            {
                masCercano = distanceToEnemy;
                enemigoMasCercano = enemy;
            }
        }

        if (enemigoMasCercano != null && masCercano <= rango)
        {
            target = enemigoMasCercano;
        }
        else
        {
            target = null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(target==null)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speedDisparo * Time.deltaTime);

        if (target.transform.position == transform.position)
        {
            target.GetComponent<ControlEnemigo>().RecibirDaño(damage);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
