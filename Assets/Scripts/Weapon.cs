using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    private Transform weaponPivot;

    void Awake()
    {
        weaponPivot = transform.Find("weaponOffset");
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector3 aimDirection = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        weaponPivot.eulerAngles = new Vector3(0, 0, angle);

    }
}
