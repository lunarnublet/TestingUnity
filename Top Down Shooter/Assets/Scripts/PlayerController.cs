using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController: MonoBehaviour
{

    private Rigidbody2D rb2d;
    public float speed;
    public int health;
    public int maxHealth;
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
            if (health < maxHealth)
            {
                collision.gameObject.SetActive(false);
                health += HealthPack.healthGain;
                if (health > maxHealth)
                {
                    health = maxHealth;
                }
                SetHealthText();
            }
        }
        else if (collision.gameObject.CompareTag("Bomb"))
        {

            Object.Destroy(collision.gameObject);
            health -= BombStats.damage;
            SetHealthText();
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Object.Destroy(collision.gameObject);
            health -= Enemy.damage;
            SetHealthText();
        }
    }
    private void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString() + "/" + maxHealth.ToString();
        if (health <= 0)
        {
            WinText.text = "You Lose!";
        }
    }
}
