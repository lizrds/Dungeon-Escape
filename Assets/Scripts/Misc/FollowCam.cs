using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    private Transform target;
    public Vector3 offset;
    [Range(0.01f, 0.99f)] public float smoothness;
    [Space]
    public float zoomSpeed = 2f;
    public float minZoom = 2f;
    public float maxZoom = 10f;
    Camera cam;
    float targetOrthographicSize;

    void Start()
    {
        cam = GetComponent<Camera>();
        targetOrthographicSize = cam.orthographicSize;
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

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            targetOrthographicSize = Mathf.Min(targetOrthographicSize + zoomSpeed * Time.deltaTime, maxZoom);
        }
        else
        {
            targetOrthographicSize = Mathf.Max(targetOrthographicSize - zoomSpeed * Time.deltaTime, minZoom);
        }
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetOrthographicSize, Time.deltaTime * zoomSpeed);
        
    }
    void LateUpdate()
    {

        if (target != null)
        {
            
            transform.position = Vector3.Lerp(transform.position, target.position + offset, smoothness);
        }
    }
}
