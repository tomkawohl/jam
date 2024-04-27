using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float gravity = 9.8f;

    public float velocityX = 0.0f;

    public Rigidbody rb;

    public Transform Sun;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.right * velocityX * Time.deltaTime;
    }

    void Update()
    {
        transform.LookAt(Sun);
        rb.velocity += transform.forward * gravity * Time.deltaTime;
        //rb.velocity += transform.forward * gravity * Time.deltaTime / Vector3.Distance(Sun.position, transform.position);
    }
}