using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Animator controller;
    private Rigidbody2D body;

    private const string LEFT = "WalkLeft";
    private const string RIGHT = "WalkRight";
    private const string BACK = "WalkBack";
    private const string FORWARD = "WalkForward";
    private const string SPIN = "Spin";

    void Start() {
        controller = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    void Update() {
        DoMovement();
    }

    private void DoMovement() {
        Vector2 velocity = body.velocity; // Create a duplicate velocity so it can be manually adjusted
        if(Input.GetKey("left") || Input.GetKey("a")) {
            controller.Play(LEFT);
            velocity.x = -5f;
        } else if(Input.GetKey("right") || Input.GetKey("d")) {
            controller.Play(RIGHT);
            velocity.x = 5f;
        } else if(Input.GetKey("up") || Input.GetKey("w")) {
            controller.Play(BACK);
            velocity.y = 5f;
        }  else if(Input.GetKey("down") || Input.GetKey("s")) {
            controller.Play(FORWARD);
            velocity.y = -5f;
        } else if(Input.GetKey(KeyCode.LeftShift)) {
            controller.Play("Spin");
            velocity = Vector2.zero;
        } else {
            controller.Play(FORWARD);
            velocity = Vector2.zero; // Cancel any movement when no key is pressed
        }
        body.velocity = velocity; // Set the body's velocity to the new velocity
    }

    private void DoMovementOld() {
        Vector2 velocity = body.velocity;
        if(Input.GetKey("left") || Input.GetKey("a")) {
            controller.SetBool("IsWalkingRight", false);
            controller.SetBool("IsWalkingBack", false);
            controller.SetBool("IsWalkingLeft", true);
            velocity.x = -5f;
        } else if(Input.GetKey("right") || Input.GetKey("d")) {
            controller.SetBool("IsWalkingLeft", false);
            controller.SetBool("IsWalkingBack", false);
            controller.SetBool("IsWalkingRight", true);
            velocity.x = 5f;
        } else if(Input.GetKey("up") || Input.GetKey("w")) {
            controller.SetBool("IsWalkingLeft", false);
            controller.SetBool("IsWalkingRight", false);
            controller.SetBool("IsWalkingBack", true);
            velocity.y = 5f;
        }  else if(Input.GetKey("down") || Input.GetKey("s")) {
            controller.SetBool("IsWalkingLeft", false);
            controller.SetBool("IsWalkingRight", false);
            controller.SetBool("IsWalkingBack", false);
            controller.SetBool("IsIdle", true);
            velocity.y = -5f;
        } else {
            controller.SetBool("IsWalkingLeft", false);
            controller.SetBool("IsWalkingRight", false);
            controller.SetBool("IsWalkingBack", false);
            controller.SetBool("IsIdle", true);
            velocity = Vector2.zero;
        }
        body.velocity = velocity;
    }
}
