using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float RotateSpeed = 75f;
    private float VInput;
    private float HInput;
    private Rigidbody rb;
    public float JumpVelocity = 5f;
    private bool Jumping;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Jumping |= Input.GetKeyDown(KeyCode.Space);
        VInput = Input.GetAxis("Vertical") * MoveSpeed;
        HInput = Input.GetAxis("Horizontal") * RotateSpeed;
        /*this.transform.Translate(Vector3.forward * _vInput *
        Time.deltaTime);
        this.transform.Rotate(Vector3.up * _hInput *
        Time.deltaTime);*/
    }

    void FixedUpdate()
    {
        if (Jumping)
        {
            rb.AddForce(Vector3.up * JumpVelocity, ForceMode.Impulse);
        }
        Jumping = false;
        Vector3 rotation = Vector3.up * HInput;
        Quaternion angleRot = Quaternion.Euler(rotation *
        Time.fixedDeltaTime);
        rb.MovePosition(this.transform.position +
        this.transform.forward * VInput * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * angleRot);
    }
}
