using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable]
public class RotationHandler
{
    public KeyCode input;
    public Vector3 direction;
    public Transform transform;
    
    private bool hastapped;

    public void Update()
    {
        if (Input.GetKeyDown(input))
        {
            hastapped = true;
        }
    }
    
    public void FixedUpdate()
    {
        if (Input.GetKey(input) || hastapped)
        {
            transform.Rotate(direction);
        }

        hastapped = false;
    }
}

public class Head : MonoBehaviour
{
    public RotationHandler left;
    public RotationHandler right;
    private bool hasTappedRight;

    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
    }

    private void Update()
    {
        left.Update();
        right.Update();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        left.FixedUpdate();
        right.FixedUpdate();
        transform.position += transform.up;
    }
}
