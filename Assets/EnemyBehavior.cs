using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
    public float moveSpeed = 2f;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public GameObject Player;
    public GameObject PlayerVisualEffect;

    public float health;

    public void takeDamage() {
        health -= Player.GetComponent<PlayerBehavior>().damage;
        if(health <= 0) {
            Destroy(gameObject);
        }
    }

    void Update() {
        // if(PlayerVisualEffect.GetComponent<VisualEffectBehavior>().isAttacking && Vector3.Distance(transform.position, PlayerVisualEffect.transform.position) <= 1f) {
        //     health -= Player.GetComponent<PlayerBehavior>().damage;
        //     Debug.Log(health);
        //     if(health <= 0) {
        //         Destroy(gameObject);
        //     }
        // }
    }

    void FixedUpdate() {
        float distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);

        if(distanceToPlayer <= 5f) {
            animator.SetBool("isRunning", true);
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, moveSpeed * Time.fixedDeltaTime);
            if(Player.transform.position.x < transform.position.x) {
                spriteRenderer.flipX = true;
            } else if(Player.transform.position.x > transform.position.x) {
                spriteRenderer.flipX = false;
            }
        } else {
            animator.SetBool("isRunning", false);
        }
    }
}
