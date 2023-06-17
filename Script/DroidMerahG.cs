using UnityEngine;

public class DroidMerahG : MonoBehaviour
{
    public Transform greenDroid;
    public LayerMask wallLayer;
    public float moveSpeed = 2f;
    public float chaseDistance = 5f;

    private bool isChasing = false;
    private Vector2 previousMoveDirection;

    private void Start()
    {
        InvokeRepeating("MoveRedDroid", moveSpeed, moveSpeed);
    }
     public void mulaiterus()
    {
        InvokeRepeating("MoveRedDroid", moveSpeed, moveSpeed);
    }
    private void MoveRedDroid()
    {
        if (!isChasing)
        {
            if (HasLineOfSight())
            {
                isChasing = true;
                ChaseGreenDroid();
            }
            else
            {
                RandomMove();
            }
        }
    }

    private bool HasLineOfSight()
    {
        Vector2 targetDirection = greenDroid.position - transform.position;
        targetDirection.Normalize();

        float distanceToGreenDroid = Vector2.Distance(transform.position, greenDroid.position);

        return distanceToGreenDroid <= chaseDistance && !IntersectsWalls(transform.position, targetDirection, distanceToGreenDroid);
    }

    private bool IntersectsWalls(Vector2 startPosition, Vector2 direction, float distance)
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(startPosition, direction, distance, wallLayer);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.CompareTag("Wall"))
            {
                return true;
            }
        }

        return false;
    }

    private void ChaseGreenDroid()
    {
        Vector2 targetDirection = greenDroid.position - transform.position;
        targetDirection.Normalize();

        if (IntersectsWalls(transform.position, targetDirection, 1f))
        {
            targetDirection = -targetDirection;
        }

        Vector2 targetPosition = (Vector2)transform.position + targetDirection;
        transform.position = targetPosition;
    }

    private void RandomMove()
    {
        Vector2[] directions = { Vector2.up, Vector2.down, Vector2.right, Vector2.left };
        Vector2 validDirection = Vector2.zero;

        foreach (Vector2 direction in directions)
        {
            if (direction != -previousMoveDirection && !IntersectsWalls(transform.position, direction, 1f))
            {
                validDirection = direction;
                break;
            }
        }

        if (validDirection == Vector2.zero)
        {
            // All directions are blocked/only the previous move direction is available
            validDirection = directions[Random.Range(0, directions.Length)];
        }

        previousMoveDirection = validDirection;
        Vector2 targetPosition = (Vector2)transform.position + validDirection;
        transform.position = targetPosition;
    }
}