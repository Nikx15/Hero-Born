using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    //Inspector Variables
    public float MoveSpeed = 10f;
    public float RotateSpeed = 75f;
    public float JumpVelocity = 5f;

    //Private Vars
    private float VInput;
    private float HInput;
    private Rigidbody rb;
    private bool Jumping;

    void Start()
    {
        //rigidbody
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //keybinds
        Jumping |= Input.GetKeyDown(KeyCode.Space);
        VInput = Input.GetAxis("Vertical") * MoveSpeed;
        HInput = Input.GetAxis("Horizontal") * RotateSpeed;
    }

    void FixedUpdate()
    {
        //code to jump
        if (Jumping)
        {
            rb.AddForce(Vector3.up * JumpVelocity, ForceMode.Impulse);
        }
        Jumping = false;
        //code to move
        Vector3 rotation = Vector3.up * HInput;
        Quaternion angleRot = Quaternion.Euler(rotation *
        Time.fixedDeltaTime);
        rb.MovePosition(this.transform.position +
        this.transform.forward * VInput * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * angleRot);
    }
}
