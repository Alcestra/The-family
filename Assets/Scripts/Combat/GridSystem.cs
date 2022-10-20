using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem 
{

    private int width;
    private int height;
    private float cellSize;

   public GridSystem(int width,int height, float CellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = CellSize;

        for(int x= 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                Debug.DrawLine(getWorldPos(x,z),getWorldPos(x,z) + Vector3.right * .2f, Color.white,10000);
            }
        }
    }

    public Vector3 getWorldPos(int x , int z)
    {
        return new Vector3(x,0,z) * cellSize;
    }


    public GridPosition getGridPosition(Vector3 worldPosition)
    {
        return new GridPosition(
         Mathf.RoundToInt(worldPosition.x / cellSize),
           Mathf.RoundToInt(worldPosition.z / cellSize)
            );
    }
}
