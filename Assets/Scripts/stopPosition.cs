using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopPosition : MonoBehaviour
{
    public float yPosition;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 newPos = transform.position;
        newPos.y = yPosition;
        transform.position = newPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
