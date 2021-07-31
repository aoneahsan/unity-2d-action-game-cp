using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthPickup : MonoBehaviour
{
    public int healthAmount;

    public GameObject explussion;

    private PlayerMove playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript =
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            playerScript.Heal (healthAmount);
            Instantiate(explussion, transform.position, transform.rotation);
            Destroy (gameObject);
        }
    }
}
