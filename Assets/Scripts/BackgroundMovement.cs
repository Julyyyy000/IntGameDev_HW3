
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = camera.GetComponent<Transform>().position;
        Vector3 newPos = transform.position;
        newPos.x -= 0.01f;
        newPos.y = cameraPos.y;
        if (newPos.x <= -13.5f)
        {
            newPos.x = 13.5f;
        }

        transform.position = newPos;
    }
}
