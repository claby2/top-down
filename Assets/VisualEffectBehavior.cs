using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualEffectBehavior : MonoBehaviour {
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public GameObject Player;
    public LayerMask enemyLayer;
    public Camera MainCamera;
    
    public float attackRange = 0.5f;
    public bool isAttacking = false;

    private const float offsetDistance = 1f;
    private float offsetX = 0f;
    private float offsetY = 0f;

    Vector2 mousePos;

    void Start() {
        spriteRenderer.enabled = false;
    }

    void Update() {
        if(Input.GetMouseButtonDown(0) && !isAttacking) {
            MainCamera.GetComponent<CameraScreenShake>().StartShake(.1f, .1f);
            isAttacking = true;
            spriteRenderer.enabled = true;
            animator.SetBool("Attack", true);

            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);

            for(int i = 0; i < enemiesToDamage.Length; i++) {
                enemiesToDamage[i].GetComponent<EnemyBehavior>().takeDamage();
            }
        }

        mousePos = MainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    void EndSlash() {
        isAttacking = false;
        spriteRenderer.enabled = false;
        animator.SetBool("Attack", false);
    }

    void FixedUpdate() {
        if(!isAttacking) {
            Vector2 lookDir = mousePos - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            rb.rotation = angle;

            float hypotenuse = Mathf.Sqrt((lookDir.x * lookDir.x) + (lookDir.y * lookDir.y));

            if(hypotenuse == 0) {
                hypotenuse = 1;
            }

            offsetX = (lookDir.x / hypotenuse) * offsetDistance;
            offsetY = (lookDir.y / hypotenuse) * offsetDistance;

            Vector3 tempPosition = transform.position;
            tempPosition.x = Player.transform.position.x + offsetX;
            tempPosition.y = Player.transform.position.y + offsetY;
            
            transform.position = tempPosition;
        }
    }
}
