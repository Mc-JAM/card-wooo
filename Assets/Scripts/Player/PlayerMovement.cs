using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerManager pManager;
    private SimpleInput input;
    private CharacterController cController;
    private float speed, sprintSpeed, walkSpeed, crouchSpeed;
    private Vector3 move;
    [SerializeField]
    private Check groundCheck;
    float vVel;

    const float gravity = 9.81f;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        pManager = SimpleGM.instance.pManager;
        input = SimpleGM.instance.input;
        cController = GetComponent<CharacterController>();
        speed = pManager.GetSpeed();

        sprintSpeed = speed * 2;
        walkSpeed = speed;
        crouchSpeed = speed / 2;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        JumpCheck();

        cController.Move(move * Time.deltaTime);
    }

    private void MovePlayer()
    {
        if (input.GetButton("sprint"))
            speed = sprintSpeed;
        else if (input.GetButton("crouch"))
            Crouch();
        else
        {
            speed = walkSpeed;
            cController.height = 2;
        }

        float x = input.GetHorizontal() * speed;
        float z = input.GetVertical() * speed;

        move = (transform.forward * z) + (transform.right * x);
    }

    private void JumpCheck()
    {
        if (cController.isGrounded)
        {
            vVel = -gravity * pManager.mass * Time.deltaTime; //Literally just applying gravity
            if (input.GetButtonDown("jump"))
            {
                vVel = 8;
            }
        }
        else
        {
            vVel -= gravity * Time.deltaTime;
        }

        move.y = vVel;
    }

    private void Crouch()
    {
        speed = crouchSpeed;
        cController.height = 1;
    }
}
