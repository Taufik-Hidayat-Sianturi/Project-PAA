using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroidHijauG : MonoBehaviour
{
    public Transform redDroid;
    public LayerMask wallLayer;
    public float moveSpeed = 2f;
    public float fleeDistance = 3f;

    private bool isFleeing = false;
    private Vector2 previousMoveDirection;

    private void Start()
    {
        InvokeRepeating("MoveGreenDroid", moveSpeed, moveSpeed);
    }

    public void mulaiterus()
    {
        InvokeRepeating("MoveGreenDroid", moveSpeed, moveSpeed);
    }

    private void MoveGreenDroid()
    {
        if (!isFleeing)
        {
            if (IsTooClose())
            {
                isFleeing = true;
                FleeFromRedDroid();
            }
            else
            {
                RandomMove();
            }
        }
        else
        {
            // Green droid is fleeing, check if red droid reached the same position
            if (transform.position == redDroid.position)
            {
                isFleeing = false;
            }
        }
    }

    private bool IsTooClose()
    {
        float distanceToRedDroid = Vector2.Distance(transform.position, redDroid.position);
        return distanceToRedDroid <= fleeDistance;
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

    private void FleeFromRedDroid()
    {
        Vector2 targetDirection = transform.position - redDroid.position;
        targetDirection.Normalize();

        if (IntersectsWalls(transform.position, targetDirection, 1f))
        {
            targetDirection = FindAlternateDirection(targetDirection);
        }

        Vector2 targetPosition = (Vector2)transform.position + targetDirection;
        transform.position = targetPosition;
    }

    private Vector2 FindAlternateDirection(Vector2 blockedDirection)
    {
        Vector2[] directions = { Vector2.up, Vector2.down, Vector2.right, Vector2.left };
        Vector2 validDirection = Vector2.zero;

        foreach (Vector2 direction in directions)
        {
            if (direction != blockedDirection && !IntersectsWalls(transform.position, direction, 1f))
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

        return validDirection;
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
            // All directions are blocked or only the previous move direction is available
            validDirection = directions[Random.Range(0, directions.Length)];
        }

        previousMoveDirection = validDirection;
        Vector2 targetPosition = (Vector2)transform.position + validDirection;
        transform.position = targetPosition;
    }
}
