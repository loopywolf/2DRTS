using System.Collections.Generic;

public interface IMoveLocation
{
    public void MoveLocation(List<GridCell> gridCell);

    public GridCell GetCurrentTile();
}

