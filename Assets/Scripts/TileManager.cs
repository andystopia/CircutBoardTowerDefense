using UnityEngine;

public class TileManager
{
    /// <summary>
    /// initialized by Unity
    /// </summary>
    public readonly Tile tilePrefab;

    private Dimensions<int> dimensions;

    private GameManager manager;


    private Tile selected;

    public TileManager(Tile tilePrefab, Dimensions<int> dimensions, GameManager manager)
    {
        this.tilePrefab = tilePrefab;
        this.dimensions = dimensions;
        this.manager = manager;
    }

    public Tile Selected
    {
        get => selected;
        set
        {
            if (selected != null)
            {
                selected.Deselect();
            }
            selected = value;
            if (selected != null)
            {
                Debug.Log($"Selected : {selected.Location}");
                selected.Hovered();
            }
        }
    }


    public bool AttemptMoveCardinalDirection(CardinalDirection direction)
    {
        Location<int> deltaLoc = Location<int>.MakeFromCardinalDirection(direction);
        if (Selected != null)
        {
            Location<int> transform = selected.Location;
            do
            {
                transform = Location<int>.Add(transform, deltaLoc);
                if (manager.gameBoard[transform.column, transform.row] != null)
                {
                    Selected = manager.gameBoard[transform.column, transform.row];
                    return true;
                }
            } while (IsLocationValid(transform));
        }
        return false;

    }

    private bool IsLocationValid(Location<int> transform)
    {
        return transform.row < dimensions.height && transform.row >= 0 && transform.column < dimensions.width && transform.column >= 0;
    }

    public void EnsureDeselected(Tile tile)
    {
        if (ReferenceEquals(tile, Selected))
        {
            Selected = null;
            tile.Deselect();
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            AttemptMoveCardinalDirection(CardinalDirection.North);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            AttemptMoveCardinalDirection(CardinalDirection.South);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            AttemptMoveCardinalDirection(CardinalDirection.East);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            AttemptMoveCardinalDirection(CardinalDirection.West);
        }
    }
}
