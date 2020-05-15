using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
    public float moveSpeed = 2f;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Transform target;
    public GameObject PlayerVisualEffect;
    public VisualEffectBehavior visualEffectBehavior;

    void Update() {
        if(PlayerVisualEffect.GetComponent<VisualEffectBehavior>().isAttacking && Vector3.Distance(transform.position, PlayerVisualEffect.transform.position) <= 1f) {
            Destroy(gameObject);
        }
    }

    void FixedUpdate() {
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        if(distanceToPlayer <= 5f) {
            animator.SetBool("isRunning", true);
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.fixedDeltaTime);
            if(target.position.x < transform.position.x) {
                spriteRenderer.flipX = true;
            } else if(target.position.x > transform.position.x) {
                spriteRenderer.flipX = false;
            }
        } else {
            animator.SetBool("isRunning", false);
        }
    }
}
