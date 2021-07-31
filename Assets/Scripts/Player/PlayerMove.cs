using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float speed;

    private Rigidbody2D playerBody;

    private Vector2 moveAmount;

    private Animator playerAnimator;

    public float health;

    public Image[] hearts;

    public Sprite fullHeart;

    public Sprite emptyHeart;

    public Animator playerHurtAnimator;

    // Start is called before the first frame update
    private void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 moveInput =
            new Vector2(Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical"));
        moveAmount = moveInput.normalized * speed;

        if (moveInput != Vector2.zero)
        {
            playerAnimator.SetBool("isRunning", true);
        }
        else
        {
            playerAnimator.SetBool("isRunning", false);
        }
    }

    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    private void FixedUpdate()
    {
        playerBody
            .MovePosition(playerBody.position +
            moveAmount * Time.fixedDeltaTime);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        UpdateHealth (health);
        if (playerHurtAnimator != null)
        {
            playerHurtAnimator.SetTrigger("hurt");
        }
        if (health <= 0)
        {
            Destroy (gameObject);
        }
    }

    public void ChangeWeapon(Weapon1_MouseMove weaponToPick)
    {
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));
        Instantiate(weaponToPick,
        transform.position,
        transform.rotation,
        transform);
    }

    public void UpdateHealth(float currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    public void Heal(float healthAmount)
    {
        if (health + healthAmount > 5)
        {
            health = 5;
        }
        else
        {
            health += healthAmount;
        }
    }
}
