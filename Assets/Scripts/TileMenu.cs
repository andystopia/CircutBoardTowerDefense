using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMenu : MonoBehaviour
{
    public Tile tileOpened;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hide()
    {
        gameObject.SetActive(false);
    }

    public void show()
    {
        gameObject.SetActive(true);
    }

    void upgradeTileOpened()
    {
        //make sure the player cana afford it
        //give the tileOpened slots to upgrade with! + take away the energy
        closeMenu();
    }

    void sellTileOpened()
    {
        //give energy equal to the sell amount of the tile
        closeMenu();
    }

    void closeMenu()
    {
        tileOpened.closeTileMenu();
    }

}
