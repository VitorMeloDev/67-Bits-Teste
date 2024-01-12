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

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Person"))
        {
            if(GameManager.instance.personOnBag < GameManager.instance.limitPersonOnBag)
            {
                components.anim.Play("Cross Punch");
                GameManager.instance.personOnBag += 1;
                other.GetComponent<Person>().Hit(transform);
            }
        }
    }
}
