using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    public float Force;
    public Slider forceUI;
    public float power;

    AudioManager audioManager;
    public float jumpForce = 20.0f;
    public float maxJumpTime = 0.5f;
    public float baseJump = 50;
    public float groundCheckDistance = 0.1f;
    public float gauageChargeRate = 0.5f;

    private Rigidbody2D rb;
    private bool isJumping = false;
    private float jumpTime = 0.0f;

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        audioManager.PlaySFX(audioManager.croak);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
        {
            Force = Force + gauageChargeRate;
            Force = Mathf.Clamp(Force, 0.0f, 650);
            slider();
        }

        else if (!Input.GetKeyUp(KeyCode.Space) || (!Input.GetKeyUp(KeyCode.Mouse0)))
        {
            ResetGauge();
        }

        bool isGrounded = IsGrounded();
        // Check for jump input.
        if (Input.GetButtonDown("Jump") && isGrounded && !isJumping)
        {
            isJumping = true;
            jumpTime = 0.0f;
        }
        else if (Input.GetButton("Jump") && isJumping)
        {
            jumpTime += Time.deltaTime;

            jumpTime = Mathf.Clamp(jumpTime, 0.0f, maxJumpTime);
        }
        else if (Input.GetButtonUp("Jump") && isJumping)
        {
            if (Mathf.Abs(rb.velocity.x) < 0.1f)
            {
                Vector2 jumpDirection = new Vector2(jumpForce * jumpTime + baseJump, jumpForce * jumpTime + baseJump * 2);

                rb.velocity = jumpDirection;
                audioManager.PlaySFX(audioManager.jump);
                
            }

            isJumping = false;
        }
        power = jumpForce * jumpTime + baseJump;
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance);

        return hit.collider != null;
    }


    public void slider()
    {
        forceUI.value = Force;
    }

    public void ResetGauge()
    {
        Force = 0;
        forceUI.value = 0;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        ResetGauge();
    }
}
