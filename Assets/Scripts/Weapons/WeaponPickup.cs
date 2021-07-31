using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public Weapon1_MouseMove weaponToPick;

    public GameObject explosion;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            collider.GetComponent<PlayerMove>().ChangeWeapon(weaponToPick);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy (gameObject);
        }
    }
}
