using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    public Material def, outliner;
    // Start is called before the first frame update
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    public void HitByRay()
    {
        Debug.Log("Me toca");
        _meshRenderer.materials[0] = outliner;
        _meshRenderer.materials[1] = outliner;
    }
}
