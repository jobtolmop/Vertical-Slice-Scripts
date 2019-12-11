using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBird : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    void OnCollisionEnter2D()
    {
        StartCoroutine("DestroyBird");
    }

    private IEnumerator DestroyBird()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
