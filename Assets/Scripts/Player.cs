using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Animator controller;
    private Rigidbody2D body;

    private const string LEFT = "WalkLeft", RIGHT = "WalkRight", BACK = "WalkBack", FORWARD = "WalkForward", SPIN = "Spin";

    void Start() {
        controller = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    void Update() {
        DoMovement();
    }

    private void DoMovement() {
        Vector2 velocity = body.velocity; // Create a duplicate velocity so it can be manually adjusted
        if(LeftPressed()) {
            controller.Play(LEFT);
            velocity.x = -5f;
        } else if(RightPressed()) {
            controller.Play(RIGHT);
            velocity.x = 5f;
        } else if(UpPressed()) {
            controller.Play(BACK);
            velocity.y = 5f;
        }  else if(DownPressed()) {
            controller.Play(FORWARD);
            velocity.y = -5f;
        } else if(ShiftPressed()) {
            controller.Play(SPIN);
            velocity = Vector2.zero;
        } else {
            controller.Play(FORWARD);
            velocity = Vector2.zero; // Cancel any movement when no key is pressed
        }
        body.velocity = velocity; // Set the body's velocity to the new velocity
    }

    public bool LeftPressed() {
        return Input.GetKey("left") || Input.GetKey("a");
    }

    public bool RightPressed() {
        return Input.GetKey("right") || Input.GetKey("d");
    }

    public bool UpPressed() {
        return Input.GetKey("up") || Input.GetKey("w");
    }

    public bool DownPressed() {
        return Input.GetKey("down") || Input.GetKey("s");
    }

    public bool ShiftPressed() {
        return Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
    }
}
