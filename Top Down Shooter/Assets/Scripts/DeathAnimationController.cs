using UnityEngine;
using System.Collections;

public class DeathAnimationController : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        GameObject.Destroy(this, 1.0f);
    }

}
