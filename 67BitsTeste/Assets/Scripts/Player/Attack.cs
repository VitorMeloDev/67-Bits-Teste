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
            if(GameManager.instance.personOnBack < GameManager.instance.limitPersonOnBack)
            {
                if(other.gameObject.GetComponent<Person>().droped){return;}
                
                components.stacking.list.Add(other.gameObject);
                StartCoroutine(components.stacking.OnTheBack(other.gameObject));

                components.anim.Play("Cross Punch");
                other.GetComponent<Person>().Hit(transform);
                GameManager.instance.personOnBack += 1;
            }
        }
    }
}
