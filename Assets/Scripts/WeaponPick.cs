using UnityEngine;
using TMPro;

public class WeaponPick : MonoBehaviour
{
    public bool canGrab;
    public Transform hand;
    public GameObject weapon;
    public TMP_Text grabText;
    public bool gunInHand;
    private Weapon gun;

    void Start()
    {
        canGrab = true;
        gunInHand = false;
        grabText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (weapon != null && weapon.transform.parent == hand)
            {
                Drop();
            }
            else if (weapon != null && canGrab)
            {
                Equip();
            }
        }
    }

    private void Equip()
    {
        if (!gunInHand)
        {
            gunInHand = true;
            weapon.transform.position = hand.position;
            weapon.transform.rotation = hand.rotation;
            weapon.transform.parent = hand;

            gun = weapon.GetComponent<Weapon>();
            gun.pick = this;

            grabText.gameObject.SetActive(false);
            canGrab = false;
        }
    }

    private void Drop()
    {
        if (weapon == null) return;

        gunInHand = false;
        weapon.transform.parent = null;
        weapon = null;
        gun = null;
        canGrab = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Weapon"))
        {
            grabText.gameObject.SetActive(true);
            if (weapon == null)
            {
                weapon = other.gameObject;
            } 
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Weapon"))
        {
            grabText.gameObject.SetActive(false);

            if (!gunInHand)
            {
                weapon = null;
            }
        }
    }
}
