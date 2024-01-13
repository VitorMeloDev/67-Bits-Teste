using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{

    [Header("===== HIT =====")]
    [SerializeField] private GameObject body;
    [SerializeField] private BoxCollider trigger;
    [SerializeField] private Rigidbody forceRB;
    [SerializeField] private float forceMagnitude;
    [SerializeField] private Animator anim;
    private Rigidbody[] ragdollRb;
    

    [Header("===== Stack =====")]
    [SerializeField] private float followSpeed;
    public bool droped;
    private Coroutine myCoroutine;


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

    public void UpdatePersonPosition(Transform followed, bool isFollowStart)
    {
        DisableRagdoll();
        body.transform.position = trigger.transform.position;
        myCoroutine = StartCoroutine(StartFollowingToLastCubePosition(followed, isFollowStart));
    }

    public void StopUpdatePersonPosition()
    {
        droped = true;
        EnableRagdoll();
        StopCoroutine(myCoroutine);
    }

    IEnumerator StartFollowingToLastCubePosition(Transform followed, bool isFollowStart)
    {
        while (isFollowStart)
        {
            yield return new WaitForEndOfFrame();
            
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, followed.position.x, followSpeed * Time.deltaTime),
            transform.position.y,followed.position.z);
        }
    }
}
