using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private CharacterController characterController;
    private Animator animator;

    [SerializeField]
    private float moveSpeed = 100f;
    [SerializeField]
    private float turnSpeed = 5;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update () {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var movement = new Vector3(horizontal, 0, vertical);

        characterController.SimpleMove(movement * Time.deltaTime * moveSpeed );

        animator.SetFloat("Speed", movement.magnitude);

        if (movement.magnitude > 0) // check if movement axis is really on  move
        {
            Quaternion newDirection = Quaternion.LookRotation(movement);
            //transform.rotation = newDirection; // snap rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime * turnSpeed); // smoothe rotation
        }
    }
}
