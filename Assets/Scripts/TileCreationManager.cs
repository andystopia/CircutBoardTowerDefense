
using System.Collections.Generic;
using DefaultNamespace;
using GameGrid;
using UnityEngine;

public class TileCreationManager : MonoBehaviour
{
    [SerializeField] private GameManager manager;
    [SerializeField] private Tile.Tile tilePrefab;

    public ExclusionCheckedTileGrid TileGrid { get; private set; }
    private TileSelectionManager selectionManager;
    private TileFocusManager focusManager;

    [SerializeField]
    private List<EditorGridPositionedObjectMonoBehaviour> pathNodes;

    private List<IExclusionZone> exclusionZones = new List<IExclusionZone>
    {
        // turret menu
        new RectangleExclusionZone(new GridLocation(0, 0), new GridLocation(3, 10)),
        // energy counter
        new RectangleExclusionZone(new GridLocation(3, 0), new GridLocation(3, 3)),
        // enemy spawner
        new RectangleExclusionZone(new GridLocation(12, 0), new GridLocation(12, 4)),
        // motherboard entrance
        new RectangleExclusionZone(new GridLocation(0, 14), new GridLocation(0, 18)),
        // wave numberx
        new RectangleExclusionZone(new GridLocation(12, 5), new GridLocation(12, 6))
    };
    
    private void Awake()
    {
        // add all on path to the exclusion list.
        for (var i = 0; i < pathNodes.Count - 1; i++)
        {
            exclusionZones.Add(new RectangleExclusionZone(pathNodes[i].GetLocation(), pathNodes[i + 1].GetLocation()));
        }
        
        
        selectionManager = GetComponent<TileSelectionManager>();
        focusManager = GetComponent<TileFocusManager>();
        TileGrid = new ExclusionCheckedTileGrid(new Dimensions<int>(21, 13), manager, selectionManager, focusManager, tilePrefab, exclusionZones);
    }

    private void Start()
    {
        // this isn't being very polite
        // to the focus area manager, 
        // so it will probably cause problems down the 
        // line.
        var randomTile = TileGrid.GetRandomNonNullGridItem();
        selectionManager.Activate(randomTile.GetFocusInteraction());
        focusManager.Activate(randomTile.GetFocusInteractor());
    }

}