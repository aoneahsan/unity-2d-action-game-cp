using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyBullet : MonoBehaviour
{
    public float speed = 40f;

    public float damage = 1f;

    private PlayerMove player;

    private Vector2 targetPosition;

    public GameObject destroParticleEffect;

    // Start is called before the first frame update
    void Start()
    {
        player =
            GameObject
                .FindGameObjectWithTag("Player")
                .GetComponent<PlayerMove>();
        targetPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, targetPosition) > .1f)
        {
            transform.position =
                Vector2
                    .MoveTowards(transform.position,
                    targetPosition,
                    speed * Time.deltaTime);
        }
        else
        {
            Instantiate(destroParticleEffect, transform.position, Quaternion.identity);
            Destroy (gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            player.TakeDamage (damage);
        }
    }
}
