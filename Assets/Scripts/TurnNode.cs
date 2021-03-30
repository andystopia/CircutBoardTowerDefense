using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnNode : MonoBehaviour
{
    public Quaternion rotateToThisAngle;


    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("COLIDED!!!");
        //collision.gameObject.transform.rotation = rotateToThisAngle;
    }


}
