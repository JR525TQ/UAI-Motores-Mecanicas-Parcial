using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{

    public GameObject itemVelocidadPreFab;
    public Camera cam;
    public float tiempoRespawn;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawns());
    }

    void SpawnItemVelocidad()
    {
            GameObject item = Instantiate(itemVelocidadPreFab) as GameObject;
            item.transform.position = new Vector3(Random.Range(transform.position.x -6, transform.position.x + 6), 1, Random.Range(transform.position.z -6 , transform.position.z + 6));
    }

    IEnumerator Spawns()
    {
        while(true)
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
