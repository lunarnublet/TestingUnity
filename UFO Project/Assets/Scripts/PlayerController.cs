using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rb2d;
    public float speed;
    private int collectableCount;
    public Text countText;
    public Text WinText;
    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        collectableCount = 0;
        WinText.text = "";
        setCountText();
    }
    public void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            collision.gameObject.SetActive(false);
            ++collectableCount;
            setCountText();
        }
    }
    private void setCountText()
    {
        countText.text = "Count: " + collectableCount.ToString();
        if (collectableCount >= 12)
        {
            WinText.text = "You Win!";
        }
    }
}
