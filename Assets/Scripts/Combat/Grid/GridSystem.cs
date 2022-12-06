using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem 
{

    private int width;
    private int height;
    private float cellSize;
    private GridObject[,] GridObjectArray;

   public GridSystem(int width,int height, float CellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = CellSize;

        GridObjectArray = new GridObject[width, height];

        for (int x= 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                GridPosition gridPosition = new GridPosition(x, z);
                GridObjectArray[x,z] = new GridObject(this, gridPosition); 
            }
        }
    }

    public Vector3 GetWorldPosition(GridPosition gridPosition)
    {
        return new Vector3(gridPosition.X, 0, gridPosition.z) * cellSize;
    }


    public GridPosition getGridPosition(Vector3 worldPosition)
    {
        return new GridPosition(
         Mathf.RoundToInt(worldPosition.x / cellSize),
           Mathf.RoundToInt(worldPosition.z / cellSize)
            );
    }


    public void createDebugObj(Transform debugPrefab)
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                GridPosition gridPosition = new GridPosition(x, z);

                Transform debugTransform =GameObject.Instantiate(debugPrefab,GetWorldPosition(gridPosition), Quaternion.identity);
                GridDebugObject gridDebugObject =  debugTransform.GetComponent<GridDebugObject>();
                gridDebugObject.setGridObject(GetGridObject(gridPosition));
            }
        }
    }


    public GridObject GetGridObject(GridPosition gridPosition)
    {
        return GridObjectArray[gridPosition.X,gridPosition.z];
    }


    public bool isValidGridPosition(GridPosition gridPosition)
    {
        return gridPosition.X >= 0 &&
               gridPosition.z >= 0 &&
               gridPosition.X < width &&
               gridPosition.z < height;
    }
}
