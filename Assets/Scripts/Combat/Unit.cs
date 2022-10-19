using UnityEngine;

public class Unit : MonoBehaviour
{
   [SerializeField] private Animator unitAnimator;
    private Vector3 targetPosition;

    private float moveSpeed = 4f;
    private float stoppingDistance = .1f;
    private float rotatingSpeed =10;

    

    private void Awake()
    {
        targetPosition = transform.position;
    }

    private void Update()
    {
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
        
    }

    public void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }
}
