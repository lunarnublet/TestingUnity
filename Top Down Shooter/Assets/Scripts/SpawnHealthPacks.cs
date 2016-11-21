using UnityEngine;
using System.Collections;

public class SpawnHealthPacks : MonoBehaviour {
    private float deltaTime;
    public float healthPackSpawnRate;
	// Use this for initialization
	public void Start () {
        deltaTime = 0;
	}
	
	// Update is called once per frame
	public void Update () {
        deltaTime += Time.deltaTime;
        if (deltaTime >= healthPackSpawnRate)
        {
            for (int i = 0; i < transform.childCount; ++i)
            {
                GameObject child = transform.GetChild(i).gameObject;
                if (!child.activeInHierarchy)
                {
                    child.SetActive(true);
                }
            }
            deltaTime -= healthPackSpawnRate;
        }
	}
}
