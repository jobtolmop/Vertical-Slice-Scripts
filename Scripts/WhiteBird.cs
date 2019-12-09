using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBird : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
