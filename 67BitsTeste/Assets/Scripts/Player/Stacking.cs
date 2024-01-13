using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stacking : MonoBehaviour
{
    [SerializeField] private Transform firstPosStack;
    private Vector3 currentPos;
    public List<GameObject> list = new List<GameObject>();
    private int listIndexCounter = 0;

    public void Drop()
    {
        foreach(GameObject person in list)
        {
            person.GetComponent<Person>().StopUpdatePersonPosition();
        }
        list.Clear();
        listIndexCounter = 0;
    }

    public IEnumerator OnTheBack(GameObject other)
    {
        yield return new WaitForSeconds(3f);
        
        if(list.Count == 1)
        {
            currentPos = new Vector3(other.transform.position.x, firstPosStack.position.y, other.transform.position.z);
            other.gameObject.transform.position = currentPos;
            currentPos = new Vector3(other.transform.position.x, firstPosStack.position.y + 1.5f, other.transform.position.z);
            other.gameObject.GetComponent<Person>().UpdatePersonPosition(firstPosStack, true);
        }
        else if (list.Count > 1)
        {
            other.gameObject.transform.position = currentPos;
            currentPos = new Vector3(other.transform.position.x, other.gameObject.transform.position.y + 1.5f, other.transform.position.z);
            other.gameObject.GetComponent<Person>().UpdatePersonPosition(list[listIndexCounter].transform, true);
            listIndexCounter++;
        }
    }
}
