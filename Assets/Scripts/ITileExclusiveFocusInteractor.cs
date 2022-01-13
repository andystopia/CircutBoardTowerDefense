using PrimitiveFocus;
using UnityEngine;

public interface ITileExclusiveFocusInteractor : IExclusiveFocusInteractor
{
    public Tile.Tile Root { get; }
}