using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public Rigidbody Sphere;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Sphere.isKinematic = false;
    }

    void OnTriggerStay()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
