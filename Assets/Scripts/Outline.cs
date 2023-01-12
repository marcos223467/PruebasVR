using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour
{
    [SerializeField] private Material outlineMaterial;
    [SerializeField] private float outlineScaleFactor;
    [SerializeField] private Color outlineColor;

    private Renderer outlineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        outlineRenderer = CreateOutLine(outlineMaterial, outlineScaleFactor, outlineColor);
        outlineRenderer.enabled = true;
    }

    Renderer CreateOutLine(Material mat, float scale, Color color)
    {
        GameObject outlineObject = Instantiate(this.gameObject, transform.position, transform.rotation, transform);
        Renderer renderer = outlineObject.GetComponent<Renderer>();

        renderer.material = mat;
        renderer.material.SetColor("_Color", color);
        renderer.material.SetFloat("_Scale", scale);
        renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        outlineObject.GetComponent<Outline>().enabled = false;
        //outlineObject.GetComponent<Collider>().enabled = false;

        renderer.enabled = false;

        return renderer;
    }
}
