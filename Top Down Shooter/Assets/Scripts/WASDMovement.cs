using UnityEngine;
using System.Collections;

public class WASDMovement : MonoBehaviour
{
    private Rigidbody2D m_rigidbody;

    public float speed = 5;

    // Use this for initialization
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        m_rigidbody.AddForce(new Vector2(x, y) * speed);
    }
}
