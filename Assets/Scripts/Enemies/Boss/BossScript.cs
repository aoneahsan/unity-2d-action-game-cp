using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossScript : MonoBehaviour
{
    public float damage = 1f;

    public float health = 10f;

    public EnemyHealthScript[] enemies;

    public float spawnOffset = 20f;

    public GameObject[] weaponPickups;

    public GameObject healthPickup;

    public GameObject deathParticleEffect;

    public GameObject bloodSprite;

    private float halfHealth;

    private Animator animator;

    private GameObject bossHealthBar;
    private Slider bossHealthBarSlider;

    // Start is called before the first frame update
    void Start()
    {
        halfHealth = health / 2;
        animator = GetComponent<Animator>();
        bossHealthBarSlider = FindObjectOfType<Slider>();
        bossHealthBarSlider.maxValue = health;
        bossHealthBarSlider.value = health;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        bossHealthBarSlider.value = health;
        if (health <= halfHealth)
        {
            animator.SetTrigger("run");
        }

        if (health > 0)
        {
            // on hit spanw a random enemy
            EnemyHealthScript randomEnemy =
                enemies[Random.Range(0, enemies.Length)];
            Instantiate(randomEnemy, transform.position, transform.rotation);
        }

        // check if health is zero then delete boss enemy
        if (health <= 0)
        {
            // hide boss health bar
            bossHealthBarSlider.gameObject.SetActive(false);

            // Weapon Pickup Chance
            if (weaponPickups.Length > 0)
            {
                for (int i = 0; i < weaponPickups.Length; i++)
                {
                }
                int randomWeaponPickupChance = Random.Range(1, 101);
                GameObject randomWeaponPickup =
                    weaponPickups[Random.Range(0, weaponPickups.Length)];
                Instantiate(randomWeaponPickup,
                transform.position,
                transform.rotation);
            }

            // Health Pickup Chance
            if (healthPickup != null)
            {
                Instantiate(healthPickup,
                transform.position,
                transform.rotation);
                Instantiate(healthPickup,
                transform.position,
                transform.rotation);
            }

            // perkform death effect just before deleting enemy game object
            Instantiate(bloodSprite, transform.position, Quaternion.identity);
            Instantiate(deathParticleEffect,
            transform.position,
            Quaternion.identity);

            // Delete game object of this current enemy
            Destroy (gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            collider.GetComponent<PlayerMove>().TakeDamage(damage);
        }
    }
}
