using UnityEngine;
using System.Collections;
using System;

public class RedBadGuyController : MonoBehaviour {

    public GameObject target;
    private Rigidbody2D rb2d;
    public int speed;

    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void LateUpdate () {
        LookAtPlayer();
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        Vector2 movement = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y);
        rb2d.AddForce(movement.normalized * speed);
    }

    private void LookAtPlayer()
    {
        target = GameObject.FindGameObjectsWithTag(target.tag)[0];
        Vector3 targetWorldPosition = target.transform.position;

        targetWorldPosition.z = 0;

        Vector3 direction = (targetWorldPosition - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);

        transform.forward = direction;
        transform.rotation = rotation;
    }
}
