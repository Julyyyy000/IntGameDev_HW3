using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForce : MonoBehaviour
{
    public HingeJoint2D leftArm;
    public HingeJoint2D rightArm;
    Rigidbody2D mainBody;
    public float power;
    public float armAngle = 20;
    JointMotor2D leftMotor;
    JointMotor2D rightMotor;

    //Squat
    public HingeJoint2D leftThigh;
    public HingeJoint2D rightThigh;
    private JointAngleLimits2D leftThighLimits;
    private JointAngleLimits2D rightThighLimits;
    private float squatAngle = 30f;

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

        leftThighLimits = leftThigh.limits;
        rightThighLimits = rightThigh.limits;
    }

    // Update is called once per frame
    void Update()
    {
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

        if (Input.GetKey(KeyCode.W))
        {
            mainBody.velocity = new Vector3(0, power, 0);

        }
        if (Input.GetKey(KeyCode.S))
        {
            JointMotor2D leftThighMotor = leftThigh.GetComponent<HingeJoint2D>().motor;
            leftThighMotor.motorSpeed = -100f;
            leftThigh.GetComponent<HingeJoint2D>().motor = leftThighMotor;

            JointMotor2D rightThighMotor = rightThigh.GetComponent<HingeJoint2D>().motor;
            rightThighMotor.motorSpeed = 100f;
            rightThigh.GetComponent<HingeJoint2D>().motor = rightThighMotor;
        }
        else
        {
            JointMotor2D leftThighMotor = leftThigh.GetComponent<HingeJoint2D>().motor;
            leftThighMotor.motorSpeed = 0f;
            leftThigh.GetComponent<HingeJoint2D>().motor = leftThighMotor;

            JointMotor2D rightThighMotor = rightThigh.GetComponent<HingeJoint2D>().motor;
            rightThighMotor.motorSpeed = 0f;
            rightThigh.GetComponent<HingeJoint2D>().motor = rightThighMotor;
        }
        /*
        if (Input.GetKey(KeyCode.A))
        {
            mainBody.velocity = new Vector3(-power, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            mainBody.velocity = new Vector3(power, 0, 0);
        }
        */
    }
}
