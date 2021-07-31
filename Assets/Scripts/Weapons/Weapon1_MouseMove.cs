using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1_MouseMove : MonoBehaviour
{
    public GameObject WeaponProjectile;

    public Transform shotPoint;

    public float timeBetweenShots;

    private float shotTime;

    private Animator mainCameraAnimator;

    void Start()
    {
        mainCameraAnimator = Camera.main.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction =
            Camera.main.ScreenToWorldPoint(Input.mousePosition) -
            transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;

        if (Input.GetMouseButton(0))
        {
            if (Time.time >= shotTime)
            {
                // start main camera shake animation
                mainCameraAnimator.SetTrigger("shake");

                // create a weapon projectile gameobject
                Instantiate(WeaponProjectile,
                shotPoint.position,
                transform.rotation);
                shotTime = Time.time + timeBetweenShots;
            }
        }
    }
}
