using UnityEngine;
using System.Collections;

public class FireTest : MonoBehaviour
{

    private bool isButtonDown = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var mouseClick = Input.GetAxisRaw("Fire1");

        if (mouseClick != 0)
        {
            if (!isButtonDown)
            {
                float r = Random.Range(0.0f, 1.0f);
                float g = Random.Range(0.0f, 1.0f);
                float b = Random.Range(0.0f, 1.0f);
                float a = 1.0f;

                Color color = new Color(r, g, b, a);

                GetComponent<Renderer>().material.color = color;
                isButtonDown = true;
            }
        }
        else
        {
            isButtonDown = false;
        }
    }
}
