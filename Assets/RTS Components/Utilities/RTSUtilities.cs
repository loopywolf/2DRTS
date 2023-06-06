using UnityEngine;

public class RTSUtilities : MonoBehaviour
{
    public const int sortingOrderDefault = 5000;
    public static int width;
    public static int height;    
    public static float cellSize;
    public static Vector3 originPosition;
    public static GridCell[,] gridArray;


    #region TextMesh
    // Create Text in the World
    public static TextMesh CreateWorldText(string text, Transform parent = null, Vector3 localPosition = default(Vector3), int fontSize = 40, Color? color = null, TextAnchor textAnchor = TextAnchor.UpperLeft, TextAlignment textAlignment = TextAlignment.Left, int sortingOrder = sortingOrderDefault)
    {
        if (color == null) color = Color.white;
        return CreateWorldText(parent, text, localPosition, fontSize, (Color)color, textAnchor, textAlignment, sortingOrder);
    }

    // Create Text in the World
    public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment, int sortingOrder)
    {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        return textMesh;
    }
    #endregion 

    #region Mouse Position
    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }

    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }

    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenpoint, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenpoint);
        return worldPosition;
    }
    #endregion

    #region Grid
    public static GridCell[,] CustomGrid(int width, int height, float cellSize, bool showDebug, Transform parent, Vector3 originPosition)
    {

        RTSUtilities.gridArray = new GridCell[width, height];
        RTSUtilities.cellSize = cellSize;
        RTSUtilities.originPosition = originPosition;

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                GameObject cell = new GameObject("Cell_" + x + "_" + y);
                cell.transform.position = (new Vector3(x, y, 0) * cellSize) + originPosition;
                cell.transform.parent = parent;
                GridCell gridCell = cell.AddComponent<GridCell>();
                gridCell.SetupGridCell(x, y);
                gridCell.SetDebugTextMesh(RTSUtilities.CreateWorldText(gridCell.ToString(), cell.transform, (new Vector3(x, y) * cellSize + originPosition) + new Vector3(cellSize, cellSize) * .5f, 50, Color.white, TextAnchor.MiddleCenter).gameObject);
                gridCell.ShowDebug(showDebug);
                gridArray[x, y] = gridCell;
            }
        }
        return gridArray;
    }

    private static GridCell GetGridObject(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        else
        {
            return default(GridCell);
        }
    }

    

    



    #endregion
}
