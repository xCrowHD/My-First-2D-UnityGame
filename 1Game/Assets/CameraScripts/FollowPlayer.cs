using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
	//offset from the viewport center to fix damping
	public float m_DampTime = 10f;
	public Transform m_Target;
	public float m_XOffset = 0;
	public float m_YOffset = 0;
	public float m_ZOffset = -10f;
	

	public void Start()
	{
		
		//if (m_Target == null)
		//{
			// m_Target = GameObject.FindWithTag("Player").transform;
		//}
	}

	void LateUpdate()
	{
		if (m_Target == null)
		{
			m_Target = GameObject.FindWithTag("Player").transform;
		
		}
		if (m_Target)
		{
			float targetX = m_Target.position.x + m_XOffset;
			float targetY = m_Target.position.y + m_YOffset;
			float targetZ = m_Target.position.y + m_ZOffset;
			
			transform.position = new Vector3(m_Target.position.x, transform.position.y, targetZ);
		}
	}
}
