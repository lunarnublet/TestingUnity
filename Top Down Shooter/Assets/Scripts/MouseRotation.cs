using UnityEngine;
using System.Collections;

public class MouseRotation : MonoBehaviour
{

    public Camera Camera;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 mousePosition = Input.mousePosition;

        Vector3 worldPosition = Camera.ScreenToWorldPoint(mousePosition);

        worldPosition.z = 0;

        Vector3 direction = (worldPosition - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
        transform.rotation = rotation;
    }
}
