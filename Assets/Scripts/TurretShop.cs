using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShop : MonoBehaviour
{
    public GameObject shopTurret;
    public GameObject turretMouseDrag;


    private GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        gameManagerScript.selectedTurret = shopTurret;
        //spawn in the thing that follows you (inside the scirpt it follows you + kills itself if selectedTurret null)
    }

}
