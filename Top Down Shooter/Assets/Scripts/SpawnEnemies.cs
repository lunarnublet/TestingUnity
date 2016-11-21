using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {

    private float deltaTime;
    public float enemySpawnRate;
    public GameObject enemy;
    // Use this for initialization
    public void Start()
    {
        deltaTime = 0;
    }

    // Update is called once per frame
    public void Update()
    {
        deltaTime += Time.deltaTime;
        if (deltaTime >= enemySpawnRate)
        {
            Instantiate(enemy, new Vector3(Random.Range(-20, 20), Random.Range(-20, 20)), Quaternion.identity);
            deltaTime -= enemySpawnRate;
        }
    }
}
