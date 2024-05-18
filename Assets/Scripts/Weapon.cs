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
        if (pick.gunInHand)
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
        Vector3 mouseOffset = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - weaponPivot.position).normalized;
        float angle = Mathf.Atan2(mouseOffset.y, mouseOffset.x) * Mathf.Rad2Deg;
        weaponPivot.eulerAngles = new Vector3(0, 0, angle);
    }

    private IEnumerator BulletGone(GameObject bullet)
    {
        yield return new WaitForSeconds(5f);
        Destroy(bullet);
    }
}
