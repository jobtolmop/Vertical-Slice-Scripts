using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private float smoothSpeed = 4.5f;
    [SerializeField] private float maxOrtho = 12.0f;
    [SerializeField] private float minOrtho = 1.0f;
    [SerializeField] private float zoomSpeed = 2;
    [SerializeField] private float targetOrtho;

    private float offset = 3;
    private float minCamx = -0.01f;
    private float maxCamx = 25.5f;
    private float maxCamSize = 8f;
    private float camPos = 0.5f;

    void Start()
    {
        targetOrtho = Camera.main.orthographicSize;
    }
    void Update()
    {
        if (player)
        {
            transform.position = new Vector3(player.position.x + offset, transform.position.y, transform.position.z);

            if (transform.position.x > maxCamx)
            {
                transform.position = new Vector3(maxCamx, transform.position.y, transform.position.z);
            }
            if (transform.position.x < minCamx)
            {
                transform.position = new Vector3(minCamx, transform.position.y, transform.position.z);
            }
            if (transform.position.x > camPos)
            {
                targetOrtho += maxCamSize * zoomSpeed;
                targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);

                Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
            }
        }
    }
}