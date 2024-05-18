using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform weaponPivot; // This should be a parent of the weapon
    public Transform shootPoint;  // This should be a child of the weapon
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;
    public WeaponPick pick;
    public float shootDelay = 0.5f; // Adjust this value as needed

    private bool canShoot = true; // Flag to control shooting

    void Update()
    {
        if (pick.gunInHand && this.transform.parent != null)
        {
            Aim();

            if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot)
            {
                StartCoroutine(Shoot());
            }
        }
    }

    private IEnumerator Shoot()
    {
        canShoot = false;

        GameObject newBullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Bullet bullet = newBullet.GetComponent<Bullet>();

        if (bullet != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            Vector3 shootDirection = (mousePos - shootPoint.position).normalized;
            bullet.Initialize(shootDirection, bulletSpeed);
        }
        StartCoroutine(BulletGone(newBullet));

        yield return new WaitForSeconds(shootDelay);

        canShoot = true; //shooting cooldown :)))))
    }

    void Aim()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseDirection = mousePosition - weaponPivot.position;
        float angle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;

        // Check if the mouse is to the left of the weapon pivot
        if (mouseDirection.x < 0)
        {
            weaponPivot.localScale = new Vector3(-1, 1, 1);
            angle += 180f; 
        }
        else
        {   
            weaponPivot.localScale = new Vector3(1, 1, 1);
        }
        weaponPivot.eulerAngles = new Vector3(0, 0, angle);
    }

    private IEnumerator BulletGone(GameObject bullet)
    {
        yield return new WaitForSeconds(5f);
        Destroy(bullet);
    }
}
