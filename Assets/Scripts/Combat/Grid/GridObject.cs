using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject

{

    private GridSystem gridSystem;
    private GridPosition GridPosition;
    private List <Unit> unitList;

    public GridObject(GridSystem gridSystem, GridPosition gridPosition)
    {
        this.gridSystem = gridSystem;
        this.GridPosition = gridPosition;

        unitList = new List<Unit>();
    }

    public override string ToString()
    {

        string unitString = "";
        foreach(Unit unit in unitList)
        {
           unitString += unit +"\n";
        }
        return GridPosition.ToString() + "\n" + unitString;
    }

    public void AddUnit(Unit unit)
    {
        unitList.Add(unit);
    }

    public void RemoveUnit(Unit unit)
    {
        unitList.Remove(unit);
    }

    public List<Unit> GetUnitList()
    {
        return unitList;
    }

    public bool hasAnyUnit()
    {
        return unitList.Count > 0;
    }

}
      