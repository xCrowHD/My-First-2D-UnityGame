using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingDMG : MonoBehaviour
{
    float destroytime = 3f;
    public Vector3 offset = new Vector3(0, 2, -10);
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroytime);
        transform.localPosition += offset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
