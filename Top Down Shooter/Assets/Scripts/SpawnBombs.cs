using UnityEngine;
using System.Collections;

public class SpawnBombs : MonoBehaviour {

    private float deltaTime;
    public float bombSpawnRate;
    public GameObject bomb;
    // Use this for initialization
    public void Start()
    {
        deltaTime = 0;
    }

    // Update is called once per frame
    public void Update()
    {
        deltaTime += Time.deltaTime;
        if (deltaTime >= bombSpawnRate)
        {
            Instantiate(bomb, new Vector3(Random.Range(-20, 20), Random.Range(-20, 20)), Quaternion.identity);
            deltaTime -= bombSpawnRate;
        }
    }
}
