using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speedPlayer;
    [SerializeField] private float rollPower;
    [SerializeField] private float rollTime;
    [SerializeField] private float rollTimeCoolDown;
    private Rigidbody2D rb;
    public SpriteRenderer characterSR;
    private Animator animator;
    private Vector2 moveInput;
    private Camera mainCamera;
    
    private bool isRolling = false;
    private float lastRollTime;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        animator = characterSR.GetComponent<Animator>();
        mainCamera = Camera.main;
    }

    void Update(){
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        UpdateAnimationPlayer();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > lastRollTime + rollTimeCoolDown && !isRolling) {
            StartCoroutine(RollPlayer());
        }
    }

    void FixedUpdate()
    {
        if (!isRolling) {
            rb.velocity = moveInput.normalized * speedPlayer;

            if (moveInput.x > 0) {
                characterSR.transform.localScale = Vector3.one; 
            } else if (moveInput.x < 0) {
                characterSR.transform.localScale = new Vector3(-1, 1, 1); 
            }
        }
    }   

    void UpdateAnimationPlayer(){
        if (moveInput.magnitude > 0 && !isRolling) {
            animator.SetBool("isRunning", true);
        } else {
            animator.SetBool("isRunning", false);
        }
    }

    private IEnumerator RollPlayer(){
        isRolling = true;
        lastRollTime = Time.time;
        Vector2 rollDirection = moveInput.normalized;
        rb.AddForce(rollDirection * rollPower, ForceMode2D.Impulse);
        animator.SetBool("Roll", true);

        yield return new WaitForSeconds(rollTime);

        animator.SetBool("Roll", false);
        isRolling = false;
    }
}
