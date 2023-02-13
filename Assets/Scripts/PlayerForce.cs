using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerForce : MonoBehaviour
{
    public HingeJoint2D leftArm;
    public HingeJoint2D rightArm;
    Rigidbody2D mainBody;
    public float power;
    float horizontalPower = 2f;
    public float armAngle = 20;
    JointMotor2D leftMotor;
    JointMotor2D rightMotor;

    public GameObject PlayerJump;
    public float gravity = 9.8f;

    //Squat
    public HingeJoint2D leftThigh;
    public HingeJoint2D rightThigh;

    //Ending display
    public GameObject textBox;
    public int starNum = 0;
    bool finishedGame;


    //public AudioSource mySource;
    //public AudioClip jumpClip;
    // Start is called before the first frame update
    void Start()
    {
        mainBody = GetComponent<Rigidbody2D>();
        leftMotor = leftArm.motor;
        rightMotor = rightArm.motor;
        leftMotor.motorSpeed = -armAngle;
        rightMotor.motorSpeed = armAngle;
        leftArm.motor = leftMotor;
        rightArm.motor = rightMotor;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;
        mainBody.velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            leftMotor.motorSpeed = armAngle;
            leftArm.motor = leftMotor;
        }
        else
        {
            leftMotor.motorSpeed = -armAngle;
            leftArm.motor = leftMotor;
        }

        if (Input.GetKey(KeyCode.D))
        {
            rightMotor.motorSpeed = -armAngle;
            rightArm.motor = rightMotor;
        }
        else
        {
            rightMotor.motorSpeed = armAngle;
            rightArm.motor = rightMotor;
        }

        if (PlayerJump.GetComponent<PlayerJump>().isJumping)
        {
            mainBody.velocity = new Vector3(0, power, 0);

        } else
        {
            mainBody.velocity = new Vector3(0, -20, 0);
        }


        if (Input.GetKey(KeyCode.LeftArrow) && newPos.x > -3.3f)
        {
            mainBody.velocity = new Vector3(-horizontalPower, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) && newPos.x < 3.3f)
        {
            mainBody.velocity = new Vector3(horizontalPower, 0, 0);
        }

        /*
        
        if (Input.GetKey(KeyCode.S))
        {
            JointMotor2D leftThighMotor = leftThigh.motor;
            leftThighMotor.motorSpeed = -100;
            leftThigh.motor = leftThighMotor;

            JointMotor2D rightThighMotor = rightThigh.motor;
            rightThighMotor.motorSpeed = 100;
            rightThigh.motor = rightThighMotor;
        }
        else
        {
            JointMotor2D leftThighMotor = leftThigh.motor;
            leftThighMotor.motorSpeed = 100;
            leftThigh.motor = leftThighMotor;

            JointMotor2D rightThighMotor = rightThigh.motor;
            rightThighMotor.motorSpeed = -100;
            rightThigh.motor = rightThighMotor;
        }
        */
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "stop")
        {
            PlayerJump.GetComponent<PlayerJump>().isJumping = false;
        }

        if (collision.gameObject.name == "block" && finishedGame)
        {
            if (starNum >= 5)
            {
                textBox.GetComponent<TextMeshProUGUI>().text = "You win! You got all 5 stars!";
            } else {
                textBox.GetComponent<TextMeshProUGUI>().text = "You lose! You did not get all 5 stars!";
            }    
            textBox.SetActive(true);
        } 
    }
    /*
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name == "block")
        {
            mainBody.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    */
    
}
