using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForce : MonoBehaviour
{
    public Rigidbody2D armBody;
    Rigidbody2D mainBody;
    public float power;

    public AudioSource mySource;
    public AudioClip jumpClip;
    // Start is called before the first frame update
    void Start()
    {
        mainBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mainBody.velocity = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //mySource.PlayOneShot(jumpClip);
            mySource.clip = jumpClip;
            mySource.Play();
            armBody.AddForce(transform.up * power, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.W))
        {
            mainBody.velocity = new Vector3(0, power, 0);

        }
        if (Input.GetKey(KeyCode.S))
        {
            mainBody.velocity = new Vector3(0, -power, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            mainBody.velocity = new Vector3(-power, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            mainBody.velocity = new Vector3(power, 0, 0);
        }
    }
}
