using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Vector3 characterScale;
    private float characterScaleX;
    private bool right = true;

    public float speed = 5f;
    public float jumpForce = 15f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float peaked;
    public bool test = false;

    private bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        characterScale = transform.localScale;
        characterScaleX = characterScale.x;
    }

    // Update is called once per frame
    void Update() {
        Move();
        Jump();
        CheckIfGrounded();
        CheckIfPeaked();
    }

    void Move() {
        // If left/right input obtained, x is set to 1/-1 else 0 for no movement.
        float x = Input.GetAxisRaw("Horizontal");
        // Determines whether we trigger running animation given the conditions
        anim.SetFloat ("Speed", Mathf.Abs (x));
        
        if (x < 0 && right) {
            characterScale.x = -characterScaleX;
            right = !right;
        } else if (x > 0 && !right) {
            characterScale.x = characterScaleX;
            right = !right;
        }
        transform.localScale = characterScale;

        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }

    void Jump() {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void BetterJump() {
        if (rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void CheckIfGrounded() {
        Collider2D collider = Physics2D.OverlapCircle(
            isGroundedChecker.position,
            checkGroundRadius,
            groundLayer
            );

            if (collider != null) {
                anim.SetBool("Ground", true);
                isGrounded = true;
                
                // Set Peaked to false and reassign peaked to ground level y again.
                anim.SetBool("Peaked", false);
                peaked = transform.position.y;
            } else {
                anim.SetBool("Ground", false);
                isGrounded = false;
            }
    }

    void CheckIfPeaked() {

        if (transform.position.y < peaked) {
            anim.SetBool("Peaked", true);
        } else if (transform.position.y > peaked && !isGrounded) {
            peaked = transform.position.y;
        }
    }
}
