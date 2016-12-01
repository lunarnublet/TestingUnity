using UnityEngine;
using System.Collections;

public class SpawnGameObject : MonoBehaviour {

    private float deltaTime;
    public float spawnRate;
    public GameObject obj;
    public float centerX;
    public float centerY;
    public float offsetX;
    public float offsetY;
    // Use this for initialization
    public void Start()
    {
        deltaTime = 0;
    }

    // Update is called once per frame
    public void Update()
    {
        deltaTime += Time.deltaTime;
        if (deltaTime >= spawnRate)
        {
            Instantiate(obj, new Vector3(Random.Range(centerX - offsetX, centerX + offsetX), Random.Range(centerY - offsetY, centerY + offsetY)), Quaternion.identity);
            deltaTime -= spawnRate;
        }
    }
}
