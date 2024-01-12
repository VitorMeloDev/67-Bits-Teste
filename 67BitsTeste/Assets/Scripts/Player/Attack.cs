using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Components components;

    // Start is called before the first frame update
    void Start()
    {
        components = GetComponent<Components>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Person"))
        {
            components.anim.Play("Cross Punch");
            other.GetComponent<Person>().Hit(transform);
        }

    }
}
