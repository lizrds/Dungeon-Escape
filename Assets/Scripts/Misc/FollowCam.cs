using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    private Transform target;
    public Vector3 offset;
    [Range(0.01f, 0.99f)] public float smoothness;

    void Start()
    {
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        
        if (player != null)
        {
            
            target = player.transform;
        }
        else
        {
            Debug.LogWarning("Player not found! Make sure to tag your player GameObject with the 'Player' tag.");
        }
    }

    void LateUpdate()
    {
        
        if (target != null)
        {
            
            transform.position = Vector3.Lerp(transform.position, target.position + offset, smoothness);
        }
    }
}
