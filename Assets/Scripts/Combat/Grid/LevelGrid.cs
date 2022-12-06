using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{

    public static LevelGrid Instance { get; private set; }


    [SerializeField] private Transform gridDebugOBJPrefab;
    private GridSystem gridSystem;


    private void Awake()
    {

        if(Instance != null)
        {
            Debug.Log("more then one Level Grid");
            Destroy(gameObject);
            return;
        }
        Instance = this;

        gridSystem = new GridSystem(10, 10, 2f);
        gridSystem.createDebugObj(gridDebugOBJPrefab);
    }

    public void AddUnitAtPosition(GridPosition gridPosition,Unit unit)
    {
        GridObject gridObject =  gridSystem.GetGridObject(gridPosition);
        gridObject.AddUnit(unit);
    }

    public List<Unit> GetUnitListAtGridPosition(GridPosition gridPosition)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        return gridObject.GetUnitList();
    }

    public void RemoveUnitAtPosition(GridPosition gridPosition, Unit unit)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.RemoveUnit(unit);
    }

    public void UnitMovedPosition(Unit unit, GridPosition fromGridPosition, GridPosition toGridPosition)
    {
        RemoveUnitAtPosition(fromGridPosition,unit);

        AddUnitAtPosition(toGridPosition, unit);
    }


    public GridPosition GetGridPosition(Vector3 WorldPosition) => gridSystem.getGridPosition(WorldPosition);
   
}
