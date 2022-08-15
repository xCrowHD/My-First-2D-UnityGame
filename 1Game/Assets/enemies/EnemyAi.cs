using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAi : MonoBehaviour
{
    
    [Header("Pathfinding")]
    public float pathUpdateSeconds = 0.1f;
    [Header("Physics")]

    public bool NoGravity = false;
    public float nextWaypointDistance = 1f;
    public float jumpNodeHeightRequirement = 0.8f;
    public float jumpForce = 5;
    public float jumpCheckOffset = 0.1f;


    private Path path;
    private int currentWaypoint = 0;
    
    RaycastHit2D isGrounded;
    [HideInInspector]
    public EnemyGM enemyGM;

    public void Start()
    {
        enemyGM = GetComponent<EnemyGM>();

        InvokeRepeating("UpdatePath", 0f, pathUpdateSeconds);
    }

    
    private void UpdatePath()
    {
        if (enemyGM.seeker.IsDone() && enemyGM.playerPosition != null)
        {
            enemyGM.seeker.StartPath(enemyGM.rb.position, enemyGM.playerPosition.position, OnPathComplete);
        }
    }

    public void PathFollow()
    {
        if (path == null)
        {
            return;
        }

        // Reached end of path
        if (currentWaypoint >= path.vectorPath.Count)
        {
            
            return;
        }
        

        // See if colliding with anything
        Vector3 startOffset = transform.position - new Vector3(0f, GetComponent<Collider2D>().bounds.extents.y + jumpCheckOffset);
        isGrounded = Physics2D.Raycast(startOffset, -Vector3.up, 0.05f);

        // Direction Calculation
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - enemyGM.rb.position).normalized;
        Vector2 force = direction * enemyGM.movespeed * Time.fixedDeltaTime * 100;

        // Jump
        if ( isGrounded && enemyGM.isStrong == false)
        {
            if (direction.y > jumpNodeHeightRequirement)
            {
                enemyGM.rb.AddForce(Vector2.up * jumpForce * 100);
            }
        }
        if (!isGrounded && NoGravity == false)
        {

            force.y = 0;

        }

        // Movement
        enemyGM.rb.AddForce(force, ForceMode2D.Force);
        
        // Next Waypoint
        float distance = Vector2.Distance(enemyGM.rb.position, path.vectorPath[currentWaypoint]);
        if (distance <= nextWaypointDistance)
        {
            currentWaypoint++;
        }

        //---------flipping------------
        enemyGM.flip.LookAtPlayer();
        
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
}
