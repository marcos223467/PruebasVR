using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.OpenXR.Input;

public class Varita : MonoBehaviour
{
    private Rigidbody rb;

    public Transform attach, p_ataque;

    private bool volver;

    public float speed;

    private InputDevice device;

    public GameObject luz;

    private InputData _inputData;

    private VoiceRecognition _voiceRecognition;

    public GameObject proyectil;
    // Start is called before the first frame update
    void Start()
    {
        _inputData = GetComponent<InputData>();
        
        rb = GetComponent<Rigidbody>();
        volver = false;
        _voiceRecognition = GetComponent<VoiceRecognition>();
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
            rb.AddForce(dir.normalized * speed, ForceMode.Force);
        }
        
    }

    public void ActivaVolver()
    {
        volver = true;
    }

    public void setActive(bool enter)
    {
        if (enter)
            _voiceRecognition.Stop(false);
        else
            _voiceRecognition.Stop(true);
    }

    public void Lumos(bool activar)
    {
        luz.SetActive(activar);
    }

    public void Flipendo()
    {
        GameObject _proyectil = Instantiate(proyectil, p_ataque.position, p_ataque.rotation);
        _proyectil.GetComponent<Rigidbody>().AddForce(p_ataque.forward * 2, ForceMode.Impulse);
        Destroy(_proyectil, 10f);
    }
}
