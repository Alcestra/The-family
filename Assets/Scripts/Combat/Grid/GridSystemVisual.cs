using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystemVisual : MonoBehaviour
{
    [SerializeField] Transform GridSystemSinglePrefab;


    private GridSystemVisualSingle[,] gridSystemVisualSinglesArray;


   public static GridSystemVisual Instance { get;private set; }


    public void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("there be more visuals" + transform + "-" + Instance);
            Destroy(gameObject);
            return;
        }
    }
    private void Start()
    {

        gridSystemVisualSinglesArray = new GridSystemVisualSingle[
            LevelGrid.Instance.GetWidth(),
            LevelGrid.Instance.GetHight()
            ];
        for ( int x = 0; x< LevelGrid.Instance.GetWidth(); x++)
        {
            for (int z = 0; z < LevelGrid.Instance.GetHight(); z++)
            {
                GridPosition gridPosition= new GridPosition(x,z);

               Transform gridSystemVisualSingleTransform =
                    Instantiate(GridSystemSinglePrefab,LevelGrid.Instance.GetWorldPosition(gridPosition), Quaternion.identity);

                gridSystemVisualSinglesArray[x,z] = gridSystemVisualSingleTransform.GetComponent<GridSystemVisualSingle>();
            }
        }
    }

    private void Update()
    {
        UpdateGridVisual();
    }


    public void HideAllGridPositions()
    {
        for (int x = 0; x < LevelGrid.Instance.GetWidth(); x++)
        {
            for (int z = 0; z < LevelGrid.Instance.GetHight(); z++)
            {
                gridSystemVisualSinglesArray[x, z].Hide();

            }
        }      

    }


    public void ShowGridPositionList(List<GridPosition> gridPositionList)
    {

        foreach(GridPosition gridPosition in gridPositionList)

            gridSystemVisualSinglesArray[gridPosition.x,gridPosition.z].Show();
    }

    private void UpdateGridVisual()
    {
        HideAllGridPositions();

        Unit selectedUnit = UnitActionSystem.Instance.GetSelectedUnit();

        ShowGridPositionList(
               selectedUnit.GetMoveAction().GetValidActionGridPositionList());
    }
}
