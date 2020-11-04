using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Animator controller;
    private Rigidbody2D body;

    private const string LEFT = "WalkLeft", RIGHT = "WalkRight", BACK = "WalkBack", FORWARD = "WalkForward", SPIN = "Spin", BACK_LEFT = "BackLeft", BACK_RIGHT = "BackRight", UP_RIGHT = "ForwardRight", UP_LEFT = "ForwardLeft";

    void Start() {
        controller = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    void Update() {
        DoMovement();
    }

    private void DoMovement() {
        Vector2 velocity = body.velocity; // Create a duplicate velocity so it can be manually adjusted
        if(LeftPressed() && !(UpPressed() || DownPressed())) {
            controller.CrossFade(LEFT, 2f);
            controller.Update(2f);
            velocity.x = -5f;
        } else if(RightPressed() && !(UpPressed() || DownPressed())) {
            controller.CrossFade(RIGHT, 2f);
            controller.Update(2f);
            velocity.x = 5f;
        } else if(UpPressed() && !(LeftPressed() || RightPressed())) {
            controller.CrossFade(BACK, 2f);
            controller.Update(2f);
            velocity.y = 5f;
        }  else if(DownPressed() && !(LeftPressed() || RightPressed())) {
            controller.CrossFade(FORWARD, 2f);
            controller.Update(2f);
            velocity.y = -5f;
        } else if(LeftPressed() && UpPressed()) {
            controller.CrossFade(BACK_LEFT, 2f);
            controller.Update(2f);
            velocity.x = -5f;
            velocity.y = 5f;
        } else if(RightPressed() && UpPressed()) {
            controller.CrossFade(BACK_RIGHT, 2f);
            controller.Update(2f);
            velocity.x = 5f;
            velocity.y = 5f;
        } else if(RightPressed() && DownPressed()) {
            controller.CrossFade(UP_RIGHT, 2f);
            controller.Update(2f);
            velocity.x = 5f;
            velocity.y = -5f;
        } else if(LeftPressed() && DownPressed()) {
            controller.CrossFade(UP_LEFT, 2f);
            controller.Update(2f);
            velocity.x = -5f;
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
