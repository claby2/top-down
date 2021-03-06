﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Camera MainCamera;

    public bool isFacingRight = true;
    public float damage = 1f;

    Vector2 movement;

    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement.x != 0 || movement.y != 0) {
            animator.SetBool("isRunning", true);
        } else {
            animator.SetBool("isRunning", false);
        }

        Vector2 mousePos = MainCamera.ScreenToWorldPoint(Input.mousePosition);

        if(transform.position.x > mousePos.x) {
            spriteRenderer.flipX = true;
            isFacingRight = false;
        } else if(transform.position.x < mousePos.x) {
            spriteRenderer.flipX = false;
            isFacingRight = true;
        }
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + (movement * moveSpeed * Time.fixedDeltaTime));
    }
}
