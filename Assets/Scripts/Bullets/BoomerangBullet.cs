using UnityEngine;

public class BoomerangBullet : MonoBehaviour
{
    public float spinSpeed = 50f;

    void Update()
    {
        transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
    }
}
