
using UnityEngine;

public class TileCreationManager : MonoBehaviour
{
    [SerializeField] private GameManager manager;
    [SerializeField] private Tile tilePrefab;

    public TileGrid TileGrid { get; private set; }
    private TileSelectionManager selectionManager;
    private TileFocusManager focusManager;
    
    
    private void Awake()
    {
        selectionManager = GetComponent<TileSelectionManager>();
        focusManager = GetComponent<TileFocusManager>();
        TileGrid = new TileGrid(manager, selectionManager, focusManager, tilePrefab);
    }

    private void Start()
    {
        // this isn't being very polite
        // to the focus area manager, 
        // so it will probably cause problems down the 
        // line.
        Debug.Log("here", this);
        var randomTile = TileGrid.GetRandomTile();
        selectionManager.Activate(randomTile.GetFocusInteraction());
        focusManager.Activate(randomTile.GetFocusInteractor());
    }

}