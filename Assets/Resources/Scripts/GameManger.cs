using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject instructionPanel; // 在Unity编辑器中将提示面板拖到这里

    void Start()
    {
        
        Time.timeScale = 0;
        
        if (instructionPanel != null)
        {
            instructionPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("Instruction Panel reference is not set in the inspector!");
        }
    }

    public void StartGame()
    {
        
        Time.timeScale = 1;
        
        if (instructionPanel != null)
        {
            instructionPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Instruction Panel reference is not set in the inspector!");
        }
        // if (instructionPanel != null)
        // {
        //     instructionPanel.SetActive(false);
        // }
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
