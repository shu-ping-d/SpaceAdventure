using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        DirectToCamera();
    }

    public virtual void DirectToCamera()
    {
        Vector2 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        //Debug.Log($"Mousedir = {Mousedir}");
        transform.up = dir;
    }
}
