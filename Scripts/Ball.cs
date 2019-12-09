using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private bool isPressed;

    private float explosionDelay = 0.2f;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Rigidbody2D swing;

    [SerializeField] private float releaseTime = 0.15f;

    [SerializeField] private float maxDragDistance = 4.0f;

    [SerializeField] private Animator boom;

    private void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

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

    void OnCollisionEnter2D()
    {
        StartCoroutine("ExplosionDelay");
        boom.Play("birdExplode");
            
    }

    private IEnumerator ExplosionDelay()
    {
        yield return new WaitForSeconds(2f);

        transform.GetChild(0).gameObject.SetActive(true);
        Destroy(gameObject, explosionDelay);
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);

        GetComponent<SpringJoint2D>().enabled = false;
    }
}
