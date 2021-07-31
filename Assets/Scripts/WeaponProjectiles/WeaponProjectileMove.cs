using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProjectileMove : MonoBehaviour
{
    public float speed;
    public float timeToDestroy;
    public GameObject explosion;
    public float damage;

    public GameObject fireSound;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", timeToDestroy);
        Instantiate(fireSound, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.fixedDeltaTime);
    }

    void DestroyProjectile()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Enemy")
        {
            collider.GetComponent<EnemyHealthScript>().TakeDamage(damage);
            DestroyProjectile();
        }
    }
}
