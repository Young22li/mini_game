using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public Collider2D detectedObjs;
    public float viewRadius;
    public LayerMask playerLayerMask;
    public GameObject promptPanel;

    void Start(){}

    void Update(){
        
        
        Collider2D collider = Physics2D.OverlapCircle(transform.position, viewRadius, playerLayerMask);

        
        if (collider != null ){
             //Debug.Log("I see");
             if (promptPanel != null)
            {
                //Debug.Log("I see pan");
                promptPanel.SetActive(true);
            }
             
        } 
        
    }

}
