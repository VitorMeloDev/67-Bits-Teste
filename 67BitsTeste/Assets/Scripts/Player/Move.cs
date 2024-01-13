using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speedMove;
    private Vector3 direction;
    private VariableJoystick joystick;
    private Components components;
    

    // Start is called before the first frame update
    void Start()
    {
        joystick = GameObject.Find("Variable Joystick").GetComponent<VariableJoystick>();
        components = GetComponent<Components>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        direction = (Vector3.forward * joystick.Vertical) + (Vector3.right * joystick.Horizontal);
        
        if(direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
            components.anim.SetBool("Running", true);
        }
        else
        {
            components.anim.SetBool("Running", false);
        }

        transform.Translate(direction * (speedMove * Time.deltaTime), Space.World);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("DropArea") && GameManager.instance.personOnBack > 0)
        {
            GameManager.instance.dropBtn.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if(col.gameObject.CompareTag("DropArea"))
        {
            GameManager.instance.dropBtn.SetActive(false);
        }
    }
}
