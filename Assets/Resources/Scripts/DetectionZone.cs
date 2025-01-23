using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    public Collider2D detectedObjs;
    public float viewRadius;
    public LayerMask playerLayerMask;

    void Start(){}

    void Update(){
        
        // 使用 OverlapCircle 检测玩家是否在视野范围内
        Collider2D collider = Physics2D.OverlapCircle(transform.position, viewRadius, playerLayerMask);

        // 如果检测到玩家，更新 detectedObjs
        if (collider != null){
             
             detectedObjs = collider;
        } 
        else{
            //Debug.Log("No Player Detected");
            detectedObjs = null;
        } 
    }

    private void OnDrawGizmos(){
        // 在场景中绘制视野范围
        Gizmos.DrawWireSphere(transform.position, viewRadius);
    }
}