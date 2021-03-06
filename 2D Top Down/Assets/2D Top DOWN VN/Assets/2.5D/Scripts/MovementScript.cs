﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {

    public Animator Anim;
    Material Mats;
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    CharacterController cc;
    public GameObject Sprite;
    Quaternion myRotate;
    Vector3 rotValue;

    void Start()
    {

    }

    void Update()
    {
        cc = GetComponent<CharacterController>();
        if (cc.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            ColorChange();
        }
        moveDirection.y -= gravity * Time.deltaTime;
        cc.Move(moveDirection * Time.deltaTime);
    }

        /* if (Input.GetKey(KeyCode.A))
        {
            rotateMove(180);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotateMove(0);
        }

}
    private void rotateMove(int dir)
    {
        Sprite.transform.Rotate(0, dir, 0);
    } */

        void ColorChange()
    {
        if (moveDirection.x > 1)
        {
            Anim.SetBool("Left", false);
            Anim.SetBool("Backward", false);
            Anim.SetBool("Forward", false);
            Anim.SetBool("Right", true);
            Anim.SetBool("Idle", false);
           
        }

        else if (moveDirection.z > 1)
        {
            Anim.SetBool("Left", false);
            Anim.SetBool("Backward", false);
            Anim.SetBool("Forward", true);
            Anim.SetBool("Right", false);
            Anim.SetBool("Idle", false);
        }
        else if (-moveDirection.z > 1)
        {
            Anim.SetBool("Left", false);
            Anim.SetBool("Backward", true);
            Anim.SetBool("Forward", false);
            Anim.SetBool("Right", false);
            Anim.SetBool("Idle", false);
        }

        else if (-moveDirection.x > 1)
        {
            Anim.SetBool("Left", true);
            Anim.SetBool("Backward", false);
            Anim.SetBool("Forward", false);
            Anim.SetBool("Right", false);
            Anim.SetBool("Idle", false);

        } 
        else if (moveDirection.x == 0 && moveDirection.z == 0)
        {
            Anim.SetBool("Left", false);
            Anim.SetBool("Backward", false);
            Anim.SetBool("Forward", false);
            Anim.SetBool("Right", false);
            Anim.SetBool("Idle", true);
        }


    }
}