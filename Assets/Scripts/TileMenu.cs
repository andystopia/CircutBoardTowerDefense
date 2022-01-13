using UnityEngine;

public class TileMenu : MonoBehaviour
{
    public Tile.Tile tileOpened;


    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
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

    private void upgradeTileOpened()
    {
        //make sure the player cana afford it
        //give the tileOpened slots to upgrade with! + take away the energy
        closeMenu();
    }

    private void sellTileOpened()
    {
        //give energy equal to the sell amount of the tile
        closeMenu();
    }

    private void closeMenu()
    {
        // tileOpened.closeTileMenu();
    }
}