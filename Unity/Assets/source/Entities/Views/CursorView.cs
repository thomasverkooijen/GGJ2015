using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CursorView : MonoBehaviour {

    public GameObject CursorObject;
    private GameObject M06;
    private Renderer[] Renderers;

    public void Deactivate()
    {
        Renderers = CursorObject.GetComponentsInChildren<Renderer>();
        M06 = GameObject.FindGameObjectWithTag("M06");
        foreach (Renderer _renderer in Renderers)
        {
            _renderer.enabled = false;
        }
        this.enabled = false;
    }

    public void Activate()
    {
        Renderers = CursorObject.GetComponentsInChildren<Renderer>();
        M06 = GameObject.FindGameObjectWithTag("M06");
        foreach (Renderer _renderer in Renderers)
        {
            _renderer.enabled = true;
        }
        this.enabled = true;
    }

    void Start()
    {
        Renderers = CursorObject.GetComponentsInChildren<Renderer>();
        M06 = GameObject.FindGameObjectWithTag("M06");
    }
}
