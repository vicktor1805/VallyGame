using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    private float InitZ;

    void Start()
    {
        InitZ = transform.position.z - 98f;
    }

    void Update()
    {
        transform.position += new Vector3(0, 0, -0.6f);

        if(transform.position.z <= -156)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        print(other.name); 
    }
}

