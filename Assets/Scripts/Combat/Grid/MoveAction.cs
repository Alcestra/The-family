using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveAction : BaseAction
{
    [SerializeField] private Animator unitAnimator;
    [SerializeField] private int maxMoveDistance;

    private Vector3 targetPosition;
   

    private float moveSpeed = 4f;
    private float stoppingDistance = .1f;
    private float rotatingSpeed = 10;

    protected override void Awake()
    {
        base.Awake();
        targetPosition = transform.position;
    }
    private void Update()
    {
        //Setting up the unit movement on mouse click as well as the animations
        if (!isActive) 
        {
            return;
        }
        Vector3 MoveDirection = (targetPosition - transform.position).normalized;
        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {

            
            transform.position += MoveDirection * moveSpeed * Time.deltaTime;

           
            unitAnimator.SetBool("isWalking", true);

        }
        else
        {
            unitAnimator.SetBool("isWalking", false);
            isActive = false;
            onActionComplete();
        }
        transform.forward = Vector3.Lerp(transform.forward, MoveDirection, Time.deltaTime * rotatingSpeed);
    }

    public void Move(GridPosition gridPosition,Action onActionComplete)
    {
        this.onActionComplete = onActionComplete;
        this.targetPosition = LevelGrid.Instance.GetWorldPosition(gridPosition);
        isActive= true;
    }


    public bool IsValidActionGridPostition(GridPosition gridPosition)
    {
        List<GridPosition> validGridPositionList =   GetValidActionGridPositionList();
        return validGridPositionList.Contains(gridPosition);
    }

    public List<GridPosition> GetValidActionGridPositionList()
    {
        List<GridPosition> ValidGridPositionList = new List<GridPosition>();
        GridPosition unitGridPosition = unit.GetGridPosition();


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
