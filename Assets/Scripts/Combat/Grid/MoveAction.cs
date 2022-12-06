using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveAction : MonoBehaviour
{
    [SerializeField] private Animator unitAnimator;
    [SerializeField] private int maxMoveDistance;

    private Vector3 targetPosition;
    private Unit Unit;

    private float moveSpeed = 4f;
    private float stoppingDistance = .1f;
    private float rotatingSpeed = 10;

    private void Awake()
    {
        Unit = GetComponent<Unit>();
        targetPosition = transform.position;
    }
    private void Update()
    {
        //Setting up the unit movement on mouse click as well as the animations
        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {

            Vector3 MoveDirection = (targetPosition - transform.position).normalized;
            transform.position += MoveDirection * moveSpeed * Time.deltaTime;

            transform.forward = Vector3.Lerp(transform.forward, MoveDirection, Time.deltaTime * rotatingSpeed);
            unitAnimator.SetBool("isWalking", true);

        }
        else
        {
            unitAnimator.SetBool("isWalking", false);

        }
    }

    public void Move(GridPosition gridPosition)
    {
        this.targetPosition = LevelGrid.Instance.GetWorldPosition(gridPosition);
    }


    public bool IsValidActionGridPostition(GridPosition gridPosition)
    {
        List<GridPosition> ValidGridPositionList =   GetValidActionGridPositionList();
        return ValidGridPositionList.Contains(gridPosition);
    }

    public List<GridPosition> GetValidActionGridPositionList()
    {
        List<GridPosition> ValidGridPositionList = new List<GridPosition>();
        GridPosition unitGridPosition = Unit.GetGridPosition();


        //checks for valied areas for the unit to move within the max range

        for (int x = -maxMoveDistance; x <= maxMoveDistance ; x++)
        {
            for (int z = -maxMoveDistance; z <= maxMoveDistance; z++)
            {
                GridPosition offsetGridPostition = new GridPosition(x, z);
                GridPosition testGridPosition = unitGridPosition + offsetGridPostition;

               if(!LevelGrid.Instance.isValidGridPosition(testGridPosition))
                {
                    //Checks if there is  a valied area to move to
                    continue;
                }
               if(unitGridPosition == testGridPosition)
                {
                    //same position as the one the unit is standing on
                    continue;
                }

                if (LevelGrid.Instance.HasAnyUnitOnThisPosition(testGridPosition))
                {
                    //Gridpos occupied with a unit
                    continue;
                }
                ValidGridPositionList.Add(testGridPosition);
                Debug.Log(testGridPosition);
            }
        }
        
        return ValidGridPositionList;
    }

    
}
