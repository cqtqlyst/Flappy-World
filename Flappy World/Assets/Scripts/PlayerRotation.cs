using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public PlayerMovement movement;
    private bool direction = true; //true = right, false = left
    public Transform transform;

    // Update is called once per frame
    void Update()
    {
        if (movement.horizontalMove > 0.0 && !direction) {
            flip();
        }
        else if (movement.horizontalMove < 0.0 && direction) {
            flip();
        }   
    }

    void flip() {
        direction = !direction;

        transform.Rotate(0, 180, 0);
    }
}
