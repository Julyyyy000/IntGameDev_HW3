using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    public float minScaleY = 0.5f;
    public float maxScaleY = 1f;
    public float squeezeSpeed = 2f;
    public bool isJumping = false;

    public GameObject mainBody;

    Transform characterTransform;

    // Start is called before the first frame update
    void Start()
    {
        characterTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentScale = characterTransform.localScale;
        Vector3 newPos = characterTransform.position;

        if (Input.GetKey(KeyCode.Space) && !isJumping)
        {
            if (newPos.y > -0.85f)
            {
                newPos.y -= 1 * Time.deltaTime;
            }
            currentScale.y = Mathf.Lerp(currentScale.y, minScaleY, Time.deltaTime * squeezeSpeed);
            if (mainBody.GetComponent<PlayerForce>().power < 10)
            {
                mainBody.GetComponent<PlayerForce>().power += 0.5f;
            }
        }
        else
        {
            if (newPos.y < 0.07f)
            {
                newPos.y += 1 * Time.deltaTime;
            }
            currentScale.y = Mathf.Lerp(currentScale.y, maxScaleY, Time.deltaTime * squeezeSpeed);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = true;
        }
        
        characterTransform.position = newPos;
        characterTransform.localScale = currentScale;
        
    }
}
