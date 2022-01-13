
using System.Collections.Generic;
using System.Linq;
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

    [SerializeField] private EnemyPathManager pathManager;
    
    private readonly List<IExclusionZone> exclusionZones = new List<IExclusionZone>
    {
        // turret menu
        new RectangleExclusionZone(new GridLocation(0, 0), new GridLocation(3, 10)),
        // energy counter
        new RectangleExclusionZone(new GridLocation(3, 0), new GridLocation(3, 3)),
        // enemy spawner
        new RectangleExclusionZone(new GridLocation(12, 0), new GridLocation(12, 4)),
        // motherboard entrance
        new RectangleExclusionZone(new GridLocation(0, 14), new GridLocation(0, 18)),
        // wave number
        new RectangleExclusionZone(new GridLocation(12, 5), new GridLocation(12, 6))
    };
    
    private void Awake()
    {
        // in theory, this can be done without allocation.
        var minimal = pathManager.GetActivePath().GetExtrapolator().GetMinimalRepresentation().ToList();

        for (var i = 0; i < minimal.Count - 1; i++)
        {
            var first = minimal[i].Location;
            var second = minimal[i + 1].Location;
            
            exclusionZones.Add(new RectangleExclusionZone(first, second));
        }


        selectionManager = GetComponent<TileSelectionManager>();
        focusManager = GetComponent<TileFocusManager>();
        TileGrid = new ExclusionCheckedTileGrid(new Dimensions<int>(21, 13), manager, selectionManager, focusManager, tilePrefab, exclusionZones);
    }
}