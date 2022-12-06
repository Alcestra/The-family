using UnityEngine;

public class Unit : MonoBehaviour
{
   [SerializeField] private Animator unitAnimator;
    private Vector3 targetPosition;

    private float moveSpeed = 4f;
    private float stoppingDistance = .1f;
    private float rotatingSpeed =10;

    private GridPosition gridPosition;

    private void Awake()
    {
        targetPosition = transform.position;
    }

    private void Start()
    {
        //showing the grid as well as placing the units in the grid
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtPosition(gridPosition, this);
    }

    private void Update()
    {

        //Setting up the unit movement on mouse click as well as the animations
        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {

         Vector3 MoveDirection = (targetPosition - transform.position).normalized;
         transform.position += MoveDirection * moveSpeed * Time.deltaTime;

         transform.forward = Vector3.Lerp(transform.forward,MoveDirection, Time.deltaTime * rotatingSpeed);
         unitAnimator.SetBool("isWalking", true);

        }else
        {
            unitAnimator.SetBool("isWalking", false);

        }

        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        if(newGridPosition != gridPosition)
        {
            //unit moved
            LevelGrid.Instance.UnitMovedPosition(this, gridPosition, newGridPosition);

            gridPosition = newGridPosition;
        }

    }

    public void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }
}
