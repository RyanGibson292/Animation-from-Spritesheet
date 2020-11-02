using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
    private Animator controller;
    private Rigidbody2D body;

    void Start() {
        controller = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    void Update() {
        DoMovement();
    }

    private void DoMovement() {
        if(Input.GetKey("left") || Input.GetKey("a")) {
            controller.SetBool("IsWalkingRight", false);
            controller.SetBool("IsWalkingLeft", true);
        } else if(Input.GetKey("right") || Input.GetKey("d")) {
            controller.SetBool("IsWalkingLeft", false);
            controller.SetBool("IsWalkingRight", true);
        } else {
            controller.SetBool("IsWalkingLeft", false);
            controller.SetBool("IsWalkingRight", false);
            controller.SetBool("IsIdle", true);
        }
    }
}
