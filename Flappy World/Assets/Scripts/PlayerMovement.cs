using System.Timers;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //variables
    private System.Timers.Timer Timer;
    public int millisecondsBetweenJumps = 1000;

    public Rigidbody2D rb;
    public float upForce = 50f;
    private bool jump;
    private bool canJump = true;

    void Start()
    {
        Timer = new Timer(millisecondsBetweenJumps);
        Timer.Elapsed += Timer_Elapsed;
        Timer.Enabled = true;
        Timer.AutoReset = true;
        Timer.Start();
    }

    private void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        //throw new System.NotImplementedException();
        canJump = true;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (canJump == true)
            {
                jump = true;
            }
            else
            {
                jump = false;
            }

        }
    }


    void FixedUpdate()
    {
    
        if (jump && canJump)
        {
            rb.AddForce(new Vector2(0, upForce));
            jump = false;
            canJump = false;
        }
        
    }
}
