using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveInput;
    public float moveSpeed;

    Animator animator;
    SpriteRenderer spriteRenderer;
    public LayerMask playerLayerMask;

    public GameObject gamePanel;

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
         
    }

    private void OnMove(InputValue value){
        // 获取输入值
        moveInput = value.Get<Vector2>();
    }

    void OnFire(){
        animator.SetTrigger("swordAtt");
        
    }

    void ShowGameOverPanel(){
        
        if (gamePanel != null)
        {
            
            gamePanel.SetActive(true);  // 激活 gamepanel
        }
        
    }

    void OnDamage(){
        animator.SetTrigger("isDamage");
       
    }

    void OnDie(){
         
        animator.SetTrigger("isDead");
        ShowGameOverPanel();
    }

    public void OnAnimationEnd() 
    {
        animator.SetTrigger("back");
            
    }

    private void FixedUpdate(){
        
        // 应用输入的物理力
        rb.velocity = moveInput * moveSpeed;  // 使用 velocity 代替 AddForce，这样能更平滑控制物理移动
        
        // 动画切换
        if (moveInput == Vector2.zero)
        {
            
            animator.SetBool("IsWalk", false);
        }
        else
        {
            animator.SetBool("IsWalk", true);
            if(moveInput.x > 0){
                spriteRenderer.flipX = false;
                gameObject.BroadcastMessage("IsFacingRight", true);

            } 
            if(moveInput.x < 0){
                spriteRenderer.flipX = true;
                gameObject.BroadcastMessage("IsFacingRight", false);

            } 
        }
    }
}
