using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;  // 主角的 Transform
    public float followSpeed = 5f;  // 跟随速度

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();  // 获取 Rigidbody2D 组件
    }

    private void FixedUpdate()
    {
        // 计算目标位置
        Vector2 targetPosition = new Vector2(player.position.x, player.position.y);

        // 计算与目标的方向
        Vector2 direction = (targetPosition - rb.position).normalized;

        // 移动 Rigidbody2D
        rb.velocity = direction * followSpeed;
    }
}
