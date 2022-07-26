using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyType;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("WaitForSpawn");
    }
    IEnumerator WaitForSpawn()
    {
        yield return new WaitForSeconds(0.3f);
        Instantiate(enemyType, new Vector3(this.transform.position.x, this.transform.position.y, 0), Quaternion.identity);
    }

}
