using UnityEngine;

public class Unit : MonoBehaviour
{ 
    private MoveAction moveAction;
    private GridPosition gridPosition;
    private SpinAction spinAction;

    private void Awake()
    {
        moveAction = GetComponent<MoveAction>();
        spinAction= GetComponent<SpinAction>();
    }
    private void Start()
    {
        //showing the grid as well as placing the units in the grid
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtPosition(gridPosition, this);
    }

    private void Update()
    {      
        
        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        if(newGridPosition != gridPosition)
        {
            //unit moved
            LevelGrid.Instance.UnitMovedPosition(this, gridPosition, newGridPosition);

            gridPosition = newGridPosition;
        }

    }
    public MoveAction GetMoveAction() 
    {
        return moveAction; 
    }
    public SpinAction GetSpinAction()
    {
        return spinAction;
    }
    public GridPosition GetGridPosition()
    {
        return gridPosition;
    }

}
