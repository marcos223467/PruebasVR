using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectaVarita : MonoBehaviour
{
    public Varita varita;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3) //Manos
        {
            varita.setActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            varita.setActive(false);
        }
    }
}
