using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonerScript : EnemyHealthScript
{
    public float minX = -10f;

    public float maxX = 10f;

    public float minY = -10f;

    public float maxY = 10f;

    public float timeBetweenSummons = 8f;

    public float EnemiesToSummonBetween = 3f;

    public GameObject enemyToSummon;

    private Vector2 targetPosition;

    private Animator animator;

    private float summonTime;

    private float numberOfEnemiesToSummon = 1f;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        targetPosition = new Vector2(randomX, randomY);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPosition != null)
        {
            // get to target position and start summoning enemies
            if (Vector2.Distance(transform.position, targetPosition) > .5f)
            {
                transform.position =
                    Vector2
                        .MoveTowards(transform.position,
                        targetPosition,
                        speed * Time.fixedDeltaTime);
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
                if (Time.time >= summonTime)
                {
                    summonTime = Time.time + timeBetweenSummons;
                    animator.SetTrigger("summon");
                }
            }

            // check if player is near and attack
            if (
                Vector2.Distance(transform.position, playerPosition.position) <
                stopDistance
            )
            {
                if (Time.time >= attckTime)
                {
                    StartCoroutine(AttackPlayer());
                    attckTime = Time.time + timeBetweenAttachs;
                }
            }
        }
    }

    public void SummonEnemies()
    {
        if (playerPosition != null)
        {
            while (numberOfEnemiesToSummon >= 1)
            {
                UnityEngine
                    .Object
                    .Instantiate(enemyToSummon,
                    transform.position,
                    transform.rotation);
                numberOfEnemiesToSummon--;
            }
            numberOfEnemiesToSummon = Random.Range(1, EnemiesToSummonBetween);
        }
    }
}
