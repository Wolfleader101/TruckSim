using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentreOfMass : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 CentreOfMass2;
    public bool awake;
    protected Rigidbody r;
    void Start()
    {
        r = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        r.centerOfMass = CentreOfMass2;
        r.WakeUp();
        awake = !r.IsSleeping();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + transform.rotation * CentreOfMass2, 1f);
    }
}
