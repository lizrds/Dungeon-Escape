using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    private Transform weaponPivot;
    private Transform shootPos;
    public Transform shootPoint;
    public GameObject boomerangShot;

    void Awake()
    {
        weaponPivot = transform.Find("weaponOffset");
        shootPos = transform.Find("shootPivot");
    }
    
    void Update()
    {
        Aim();

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Aim()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector3 aimDirection = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        weaponPivot.eulerAngles = new Vector3(0, 0, angle);
    }

    void Shoot()
    {

    }
}
