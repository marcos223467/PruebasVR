using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.OpenXR.Input;

public class Varita : MonoBehaviour
{
    private Rigidbody rb;

    public Transform attach;

    private bool volver;

    public float speed;

    private InputDevice device;

    public GameObject luz;

    private bool activaLuz, cogido;

    private InputData _inputData;
    // Start is called before the first frame update
    void Start()
    {
        _inputData = GetComponent<InputData>();
        
        rb = GetComponent<Rigidbody>();
        volver = false;
        activaLuz = false;
        cogido = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (cogido)
        {
            if (_inputData._rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool buttonValue))
            {
                if (buttonValue)
                {
                    activaLuz = !activaLuz;
                    CompruebaLumos();
                }
            }
            
        }
        
        
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
            rb.AddForce(dir.normalized * speed, ForceMode.Force);
        }
        
    }

    public void ActivaVolver()
    {
        volver = true;
    }

    private void CompruebaLumos()
    {
        luz.SetActive(activaLuz);
    }

    public void setActive(bool enter)
    {
        cogido = enter;
    }
}
