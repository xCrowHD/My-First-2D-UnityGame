using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlip : MonoBehaviour
{
	[HideInInspector]
	public EnemyGM enemyGM;
	public bool isFlipped = false;
    private void Start()
    {
		enemyGM = GetComponent<EnemyGM>();
		
	}
    private void Update()
    {
		if (enemyGM.playerPosition == null)
		{
			enemyGM.playerPosition = GameObject.FindWithTag("Player").transform;
		}
	}
    public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x < enemyGM.playerPosition.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x > enemyGM.playerPosition.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}

}
