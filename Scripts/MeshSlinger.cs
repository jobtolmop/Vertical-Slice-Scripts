using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshSlinger : MonoBehaviour
{
    public Material mat;
    [SerializeField] private Transform player;
    private float height = 1;
    private float width = 1;

    void Start()
    {
        Mesh slinger = new Mesh();

        Vector3[] vertices = new Vector3[4];

        /*vertices[0] = new Vector3(-width, -height);
        vertices[1] = new Vector3(-width, height);
        vertices[2] = new Vector3(width, height);
        vertices[3] = new Vector3(width, -height);*/

        vertices[0] = new Vector3(-6.6f, -0.55f);
        vertices[1] = new Vector3(-6.6f, -0.77f);
        vertices[2] = new Vector3(player.position.x, 0.1f);
        vertices[3] = new Vector3(player.position.y, 0.1f);

        slinger.vertices = vertices;

        slinger.triangles = new int[] {0, 1, 2, 0, 2, 3};

        GetComponent<MeshRenderer>().material = mat;

        GetComponent<MeshFilter>().mesh = slinger;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
