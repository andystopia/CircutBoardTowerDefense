using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnNode : MonoBehaviour
{
    private GameObject nextNode;
    public int nextNodeX;
    public int nextNodY;

    public GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        nextNode = gameManagerScript.gameBoard[nextNodeX, nextNodY];
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
