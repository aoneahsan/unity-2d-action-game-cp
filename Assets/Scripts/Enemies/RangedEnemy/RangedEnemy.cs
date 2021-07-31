using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : EnemyHealthScript
{
    public Transform shotPoint;
    public GameObject bullet;

    private float attackTime;

    private Animator animator;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }

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

            if (Time.time >= attackTime)
            {
                attackTime = Time.time + timeBetweenAttachs;
                animator.SetTrigger("attack");
            }
        }
    }

    void RangedAttackPlayer()
    {
        Vector2 direction = playerPosition.position - shotPoint.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        shotPoint.rotation = rotation;

        UnityEngine
            .Object
            .Instantiate(bullet, shotPoint.position, shotPoint.rotation);
    }
}
