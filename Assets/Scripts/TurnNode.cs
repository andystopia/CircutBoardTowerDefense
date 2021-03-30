using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnNode : MonoBehaviour
{
    public GameObject nextNode;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.transform.position.Equals(transform.position))
        {
            other.GetComponent<Enemy>().nextNode = this.nextNode;
            other.transform.LookAt(nextNode.transform);
        }
    }


}
