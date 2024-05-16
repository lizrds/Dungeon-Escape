using UnityEngine;
using TMPro;

public class WeaponPick : MonoBehaviour
{
    
    public bool canGrab;
    public Transform hand;
    public GameObject weapon; // Reference to the weapon object
    public TMP_Text grabText;

    void Start()
    {
        canGrab = false;
        grabText.gameObject.SetActive(false); // Deactivate the text initially
    }


    void Update()
    {
        if (canGrab && Input.GetKeyDown(KeyCode.F)) // Check if canGrab is true and "F" is pressed
        {
            Equip();
        }
    }

    private void Equip()
    {
        weapon.transform.position = hand.position;
        weapon.transform.rotation = hand.rotation;
        weapon.transform.parent = hand;
        grabText.gameObject.SetActive(false); // Deactivate the grab text after picking up
    }

    void OnTriggerEnter2D(Collider2D other) // Use Collider2D instead of Collision for 2D triggers
    {
        if (other.CompareTag("Weapon")) // Check if the collider belongs to a weapon
        {
            canGrab = true;
            grabText.gameObject.SetActive(true); // Activate the grab text
            weapon = other.gameObject; // Assign the weapon object
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Weapon")) // Check if the collider belongs to a weapon
        {
            canGrab = false;
            grabText.gameObject.SetActive(false); // Deactivate the grab text
            weapon = null; // Reset the weapon object
        }
    }
}
