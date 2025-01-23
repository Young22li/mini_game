using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public Collider2D detectedObjs;
    public float viewRadius;
    public LayerMask playerLayerMask;
    public GameObject promptPanel;
    public string restartSceneName = "SampleScene";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Collider2D collider = Physics2D.OverlapCircle(transform.position, viewRadius, playerLayerMask);

        
        if (collider != null ){
             Debug.Log("I see");
             if (promptPanel != null)
            {
                //Debug.Log("I see pan");
                promptPanel.SetActive(true);
            }
             
        } 
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(restartSceneName);
    }

    public void QuitGame()
    {
        
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
