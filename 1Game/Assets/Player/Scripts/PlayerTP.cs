using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTP : MonoBehaviour
{
    public Transform tppos;
    public Transform collCheck;
    public PlayerStats stats;

    public LayerMask obstacleLayer;
    public int stamused = 40;
    private float tpready;
    
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawLine(collCheck.position, collCheck.position + Vector3.right * 3f, Color.red);

        if (Input.GetKeyDown(KeyCode.X) && CollisionCheck())
        {
            if (stats.stamina.currentstam - stamused >= 0 && Time.time >= tpready)
                
            {
                stats.stamina.UseStam(stamused);
                stats.animator.SetTrigger("TP");
                tpready = Time.time + 3f;
               
            }
        }
    }


    public void Teleport()
    {
        transform.position = tppos.position;

    }

    public bool CollisionCheck()
    {
        Vector3 dir = Vector3.right;
        if (stats.move.m_FacingRight)
        {
            dir = Vector3.right;
        }
        else if (!stats.move.m_FacingRight)
        {
            dir = -Vector3.right;
        }

        Vector2 endPos = collCheck.position + dir * 3f;
        RaycastHit2D ray = Physics2D.Linecast(collCheck.position, endPos, obstacleLayer);

        if(ray.collider != null )
        {
            if(ray.collider.tag == "Obstacle")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return true;
        }
        
    }

   
}