using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.XR;
using UnityEngine.XR.OpenXR.Input;

public class Bola : MonoBehaviour
{
    private Rigidbody rb;
    public Transform[] targets;
    private int tam;
    private bool chutar;

    public float maxF, minF;
    
    private InputData _inputData;

    private Transform origPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        chutar = false;
        tam = targets.Length;
        _inputData = GetComponent<InputData>();
        origPos = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            if (gripValue > 0.1)
            {
                chutar = true;
            }
        }
        if (_inputData._leftController.TryGetFeatureValue(CommonUsages.grip, out float LgripValue))
        {
            if (LgripValue > 0.1)
            {
                Reposicionar();
            }
        }
        Chutar();
    }

    private void Chutar()
    {
        if (chutar && rb.velocity.magnitude <= 0.1f)
        {
            chutar = false;

            int pos = Random.Range(0, tam);
            float F = Random.Range(minF, maxF);
            Transform target = targets[pos];
            Vector3 dir = new Vector3(target.position.x - transform.position.x,
                target.position.y - transform.position.y, target.position.z - transform.position.z).normalized;
            
            rb.AddForce(dir*F, ForceMode.Impulse);
        }
    }

    private void Reposicionar()
    {
        rb.velocity = Vector3.zero;
        transform.position = origPos.position;
    }
}
