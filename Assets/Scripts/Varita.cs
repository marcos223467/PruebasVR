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

    private bool activaLuz;
    // Start is called before the first frame update
    void Start()
    {
        /*List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        if (devices.Count > 0)
            device = devices[0];
        
        rb = GetComponent<Rigidbody>();*/
        volver = false;
        activaLuz = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*device.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        device.TryGetFeatureValue(CommonUsages.trigger, out float trig);
        if (primaryButtonValue || trig > 0.1)
            activaLuz = true;

        luz.SetActive(activaLuz);*/
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
}
