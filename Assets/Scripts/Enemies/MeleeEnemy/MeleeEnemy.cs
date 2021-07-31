using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyHealthScript
{
    // Update is called once per frame
    void Update()
    {
        if (playerPosition != null)
        {
            if (
                Vector2.Distance(transform.position, playerPosition.position) >
                stopDistance
            )
            {
                transform.position =
                    Vector2
                        .MoveTowards(transform.position,
                        playerPosition.position,
                        speed * Time.deltaTime);
            }
            else
            {
                if (Time.time >= attckTime)
                {
                    StartCoroutine(AttackPlayer());
                    attckTime = Time.time + timeBetweenAttachs;
                }
            }
        }
    }
}
