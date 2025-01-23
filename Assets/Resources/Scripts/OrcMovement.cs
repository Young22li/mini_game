using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;
    DetectionZone detectionZone;

    public float speed;

    public int attackPower;
    public float knockbackForce;

    void OnDamage(){
        animator.SetTrigger("isDamage");
        animator.SetBool("isWalk", true);
    }

    void OnDie(){
        animator.SetTrigger("isDead");
    }

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        detectionZone = GetComponent<DetectionZone>();
    }

    private void FixedUpdate(){
        // 如果检测到玩家并且玩家在视野范围内
        if (detectionZone.detectedObjs != null){
            
            Vector2 direction = (detectionZone.detectedObjs.transform.position - transform.position).normalized; // 标准化方向

            // 如果怪物距离玩家在视野范围内，开始移动
            if (direction.magnitude <= detectionZone.viewRadius){
                // 直接设置物理速度来代替 AddForce，这样控制更精确
                rb.velocity = direction * speed;

                // 播放行走动画
                if(direction.x > 0) spriteRenderer.flipX = false;
                if(direction.x < 0) spriteRenderer.flipX = true;
                animator.SetBool("isWalk", true);
            }
            else{
                // 如果玩家超出视野范围，停止移动并切换动画
                rb.velocity = Vector2.zero; // 停止移动
                animator.SetBool("isWalk", false);
            }
        }
        else{
            // 如果没有检测到玩家，停止移动并切换动画
            rb.velocity = Vector2.zero;
            animator.SetBool("isWalk", false);
        }
    }

    
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        Idamageable damageable = collider.GetComponent<Idamageable>();

        if(damageable != null && collider.tag == "Player"){
            Vector2 direction = collider.transform.position - transform.position;
            Vector2 force = direction.normalized * knockbackForce;

            damageable.OnHit(attackPower, force);
        }
    }
}
