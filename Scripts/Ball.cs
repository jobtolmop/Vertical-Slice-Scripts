using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private bool isPressed;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Rigidbody2D swing;

    [SerializeField] private float releaseTime = .15f;

    [SerializeField] private float maxDragDistance = 4f;

    private void Update()
    {
        if (isPressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector3.Distance(mousePos, swing.position) > maxDragDistance)
            {
                rb.position = swing.position + (mousePos - swing.position).normalized * maxDragDistance;
            }
            else
            {
                rb.position = mousePos;
            }

        }
    }

    private void OnMouseDown()
    {
        gameObject.GetComponent<TrailRenderer>().enabled = false;
        isPressed = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        gameObject.GetComponent<TrailRenderer>().enabled = true;
        isPressed = false;
        rb.isKinematic = false;

        StartCoroutine(Release());
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);

        GetComponent<SpringJoint2D>().enabled = false;

        this.enabled = false;
    }
}
