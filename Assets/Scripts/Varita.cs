using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Varita : MonoBehaviour
{
    private Rigidbody rb;

    public Transform attach;

    private bool volver;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        volver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedUpdate()
    {
        if (volver)
        {
            Volver();
        }
    }


    private void Volver()
    {
        rb.useGravity = false;
        if (Vector3.Distance(attach.position, transform.position) <= 0.1)
        {
            volver = false;
            rb.useGravity = true;
        }
        else
        {
            Vector3 dir = (attach.position-transform.position).normalized;
            rb.AddForce(dir * speed, ForceMode.Force);
        }
        
    }

    public void ActivaVolver()
    {
        volver = true;
    }
}
