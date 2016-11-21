using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController: MonoBehaviour
{

    private Rigidbody2D rb2d;
    public float speed;
    public int health;
    public Text healthText;
    public Text WinText;
    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        SetHealthText();
        WinText.text = "";
        SetHealthText();
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
        if (collision.gameObject.CompareTag("HealthPack"))
        {
            collision.gameObject.SetActive(false);
            health += HealthPack.healthGain;
            SetHealthText();
        }
    }
    private void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
        if (health <= 0)
        {
            WinText.text = "You Lose!";
        }
    }
}
