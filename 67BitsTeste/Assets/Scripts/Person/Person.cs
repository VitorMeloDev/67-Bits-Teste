using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField] private BoxCollider trigger;
    [SerializeField] private Rigidbody forceRB;
    [SerializeField] private float forceMagnitude;
    [SerializeField] private Animator anim;
    private Rigidbody[] ragdollRb;
    

    void Start()
    { 
        ragdollRb = GetComponentsInChildren<Rigidbody>();
        anim = GetComponent<Animator>();

        DisableRagdoll();
    }


    public void DisableRagdoll()
    {
        foreach (var rb in ragdollRb)
        {
            rb.isKinematic = true;
        }
    }

    public void EnableRagdoll()
    {
        anim.enabled = false;
        foreach (var rb in ragdollRb)
        {
            rb.isKinematic = false;
        }
    }

    public void Hit(Transform target)
    {
        trigger.enabled = false;
        StartCoroutine(ActionHit(target));
    }

    IEnumerator ActionHit(Transform target)
    {   
        yield return new WaitForSeconds(0.4f);
        
        EnableRagdoll();

        Vector3 direction = (transform.position - target.position).normalized;
        forceRB.AddForce(direction * forceMagnitude);
    }

    IEnumerator OnBag(Transform target)
    {
        yield return new WaitForSeconds(3f);
    }



}
