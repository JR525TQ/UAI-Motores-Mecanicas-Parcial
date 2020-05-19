using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{

    public GameObject enemy;
    public Camera cam;
    public float tiempoRespawn;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawns());
    }

    void SpawnItemVelocidad()
    {
        GameObject item = Instantiate(enemy) as GameObject;
        item.transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
    }

    IEnumerator Spawns()
    {
        while (true)
        {
            yield return new WaitForSeconds(tiempoRespawn);
            SpawnItemVelocidad();
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
