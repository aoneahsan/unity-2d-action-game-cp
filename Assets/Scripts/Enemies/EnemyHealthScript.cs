using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    public float health = 3f;

    public float damage = .3f;

    public float speed = 6f;

    public float timeBetweenAttachs = 10f;

    public float stopDistance = 3f;

    public float attackSpeed = 6f;

    public int weaponPickupChance = 2;

    public int healthPickupChance = 2;

    public GameObject[] weaponPickups;

    public GameObject healthPickup;

    [HideInInspector]
    public Transform playerPosition;

    [HideInInspector]
    public float attckTime = 0f;

    public GameObject deathEffect;

    // Start is called before the first frame update
    public virtual void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            // Weapon Pickup Chance
            int randomWeaponPickupChance = Random.Range(1, 101);
            if (randomWeaponPickupChance <= weaponPickupChance)
            {
                GameObject randomWeaponPickup =
                    weaponPickups[Random.Range(0, weaponPickups.Length)];
                Instantiate(randomWeaponPickup,
                transform.position,
                transform.rotation);
            }

            // Health Pickup Chance
            int randomHealthPickupChance = Random.Range(1, 101);
            if (randomHealthPickupChance <= healthPickupChance)
            {
                Instantiate(healthPickup,
                transform.position,
                transform.rotation);
            }
            // perkform death effect just before deleting enemy game object
            Instantiate(deathEffect, transform.position, Quaternion.identity);

            // Delete game object of this current enemy
            Destroy (gameObject);
        }
    }

    public IEnumerator AttackPlayer()
    {
        playerPosition.GetComponent<PlayerMove>().TakeDamage(damage);

        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = playerPosition.position;

        float percent = 0;
        while (percent <= 1)
        {
            percent += Time.deltaTime * attackSpeed;
            float formula = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position =
                Vector2.Lerp(originalPosition, targetPosition, formula);
            yield return null;
        }
    }
}
