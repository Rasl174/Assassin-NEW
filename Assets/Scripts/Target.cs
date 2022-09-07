using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public class Target : MonoBehaviour
{
    private Outline _outline;

    private void Start()
    {
        _outline = GetComponent<Outline>();
        _outline.enabled = false;
    }

    public void OnRayEnter()
    {
        _outline.enabled = true;
    }

    public void OnRayExit()
    {
        _outline.enabled = false;
    }
}
