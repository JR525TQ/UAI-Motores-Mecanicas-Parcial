using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{

    public GameObject itemVelocidadPreFab;
    private Vector3 screenBounds;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawns());
    }

    void SpawnItemVelocidad()
    {
            GameObject item = Instantiate(itemVelocidadPreFab) as GameObject;
            item.transform.position = new Vector3(Random.Range(transform.position.x, transform.position.x + 10), 1, Random.Range(transform.position.z, transform.position.z + 10));
    }

    IEnumerator Spawns()
    {
        while(true)
        {
            SpawnItemVelocidad();
            yield return new WaitForSeconds(30);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
