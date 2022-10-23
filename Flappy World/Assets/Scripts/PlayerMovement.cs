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
    public float horizontalForce = 50f;
    private float horizontalMove;
    public Animator animator;


    void Start()
    {

        //timer stuff
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

        animator.SetBool("isJumping", jump);

        horizontalMove = Input.GetAxisRaw("Horizontal") * horizontalForce;

    }
    void FixedUpdate()
    {
    
        if (jump && canJump)
        {
            rb.AddForce(new Vector2(0, upForce * Time.deltaTime));
            jump = false;
            canJump = false;
        }

        rb.AddForce(new Vector2(horizontalMove * Time.deltaTime, 0));
        
    }
}
