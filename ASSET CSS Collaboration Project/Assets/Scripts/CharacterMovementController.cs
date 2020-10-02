using UnityEngine;

//Credits to Brackeys for the Basic 2D Movement tutorial 
public class CharacterMovementController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 400f;                    //value for force added during jump
    [Range(0, 1)] [SerializeField] private float crouchSpeed = .30f;    //value of maxSpeed applied to crouch movement. 1 = 100%
    [Range(0, 1)] [SerializeField] private float movementSmooth = .05f; //value that smooths out movement
    [SerializeField] private bool airControl = false;                   //allows steering direction while mid-air
    [SerializeField] private LayerMask groundDefinition;                //defines what counts as the ground
    [SerializeField] private Transform ceilingCheck;                    //position where to check for ceilings
    [SerializeField] private Transform groundCheck;                      //position where to check if player is grounded
    [SerializeField] private Collider2D crouchDisableCollider;          //Collider that will be disabled when crouching

    const float groundedRadius = .2f;         //Radius of overlap circle to determine if player is grounded
    const float ceilingRadius = .2f;         // Radius of overlap circle to determine if player can stand
    private bool grounded;                  //whether player is grounded or not
    private bool facingRight = true;        //check if player is facing right
    private Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    private Animator anime;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
    }

    private void Flip()
    {
        //switch the way the player is facing
        facingRight = !facingRight;

        //multiply the player's local scale by 1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void FixedUpdate()
    {
        grounded = false;
        
        //player is grounded if the circlecast on groundCheck's position touches anything defined as ground
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, groundDefinition);
        for(int i = 0; i < colliders.Length; i++)
        {
            if(colliders[i].gameObject != gameObject)
            {
                grounded = true;
            }
        }
    }

    public void Move(float movement, bool crouch, bool jump)
    {
        //if crouching, when you let go of crouch, check if the player can stand
        if (!crouch)
        {
            //if player is touching a ceiling while crouching, prevent them from standing up
            if (Physics2D.OverlapCircle(ceilingCheck.position, ceilingRadius, groundDefinition))
            {
                crouch = true;
            }
        }

        //only control player if grounded or air control is on
        if (grounded || airControl)
        {
            //movement while crouching
            if (crouch)
            {
                //reduce move speed
                movement *= crouchSpeed;

                //disable one of the colliders if crouching
                if (crouchDisableCollider != null)
                {
                    crouchDisableCollider.enabled = false;
                }

                anime.SetBool("Crouch", true);
               
            }
            else
            {
                //enable collider if player is not crouched
                if (crouchDisableCollider != null)
                {
                    crouchDisableCollider.enabled = true;
                }

                anime.SetBool("Crouch", true);
            }

            //character moves by finding its target velocity 
            Vector3 targetVelocity = new Vector2(movement * 10f, rb.velocity.y);

            //movement smoothing applied to character
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmooth);

            //flipping player depending on whether he's facing left or right
            if (movement > 0 && !facingRight)
            {
                Flip();
            }
            else if (movement < 0 && facingRight)
            {
                Flip();
            }
        }

        //walking animation if moving 
        if(movement > 0 || movement < 0)
        {
            //checking if grounded so walking anim only plays while grounded
            if (grounded)
            {
                anime.SetBool("Walking", true);
            }
            else
            {
                anime.SetBool("Walking", false);
            }
        }
        else
        {
            anime.SetBool("Walking", false);
        }

        //checking for jump
        if (grounded && jump)
        {
            //add vertical force on player
            grounded = false;
            rb.AddForce(new Vector2(0f, jumpForce));
        }

        //jumping animation when jump pressed or while in air
        if (jump || !grounded)
        {
            anime.SetBool("Jump", true);
        }
        else
        {
            anime.SetBool("Jump", false);
        }

        //crouch animation on crouch press
        if (crouch)
        {
            anime.SetBool("Crouch", true);
        }
        else
        {
            anime.SetBool("Crouch", false);
        }
    }
    
}
