using UnityEngine;
using TMPro;

public class WeaponPick : MonoBehaviour
{
    public bool canGrab;
    public Transform hand;
    public GameObject weapon;
    public TMP_Text grabText;
    public bool gunInHand;

    void Start()
    {
        canGrab = false;
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
            if (weapon != null && canGrab)
            {
                Equip();
            }
        }
    }

    private void Equip()
    {
        gunInHand = true;
        weapon.transform.position = hand.position;
        weapon.transform.rotation = hand.rotation;
        weapon.transform.parent = hand;
        grabText.gameObject.SetActive(false);
        //weapon.GetComponent<CircleCollider2D>().enabled = false;
    }

    private void Drop()
    {
        if (weapon == null) return;

        gunInHand = false;
        weapon.transform.parent = null;
        weapon = null;
        //weapon.GetComponent<CircleCollider2D>().enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Weapon"))
        {
            canGrab = true;
            grabText.gameObject.SetActive(true);
            weapon = other.gameObject; 
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Weapon"))
        {
            canGrab = false;
            grabText.gameObject.SetActive(false);
        }
    }
}
