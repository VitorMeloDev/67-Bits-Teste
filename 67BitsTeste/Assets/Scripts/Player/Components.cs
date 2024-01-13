using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Components : MonoBehaviour
{
    public Animator anim;
    public Rigidbody myRB;
    public Stacking stacking;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myRB = GetComponent<Rigidbody>();
        stacking = GetComponent<Stacking>();
    }
}
