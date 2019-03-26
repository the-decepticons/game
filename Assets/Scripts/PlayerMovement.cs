using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float m_Speed = 12f;
    public float m_TurnSpeed = 180f;

    private Rigidbody m_Rigidbody;

    static Animator anim;

    private Vector3 moveDirection;
    private Vector3 input;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }


    private void OnEnable()
    {
        m_Rigidbody.isKinematic = false;
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

        input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

    }

    private void FixedUpdate()
    {
        if (input != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(input);
        }

        Vector3 movement = transform.forward * input.magnitude * m_Speed * Time.deltaTime;


        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);

       // moveDirection = transform.TransformDirection(input);

        //transform.Translate(moveDirection * Time.deltaTime * m_Speed);


        if (input != Vector3.zero)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
}
   
