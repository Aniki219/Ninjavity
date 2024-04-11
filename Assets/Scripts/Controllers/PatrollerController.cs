using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PatrollerController : MonoBehaviour
{
    public string direction;
    public GameObject path;
    public float speed = 4f;

    CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void FixedUpdate() {
        // if (cc.collisionData.top && direction == "UP") {
        //     direction = "DOWN";
        // }
        // if (cc.collisionData.bottom && direction == "DOWN") {
        //     direction = "UP";
        // }
        // if (cc.collisionData.left && direction == "LEFT") {
        //     direction = "RIGHT";
        // }
        // if (cc.collisionData.right && direction == "RIGHT") {
        //     direction = "LEFT";
        // }
        // cc.velocity = speed * GetDirectionFromString();
    }

    Vector2 GetDirectionFromString() {
        switch (direction) {
            case "UP":
                return Vector2.up;
            case "DOWN":
                return Vector2.down;
            case "LEFT":
                return Vector2.left;
            case "RIGHT":
                return Vector2.right;
            default:
                return Vector2.zero;
        }
    }
}
