using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LineVisibilityManager : MonoBehaviour
{
    public XRInteractorLineVisual _lineRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        _lineRenderer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnUiEntered()
    {
        _lineRenderer.enabled = true;
    }
    
    public void OnUiExited()
    {
        _lineRenderer.enabled = false;
    }
}
