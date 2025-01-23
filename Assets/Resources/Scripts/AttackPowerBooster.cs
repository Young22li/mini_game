using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackPowerBooster : MonoBehaviour
{
    public GameObject promptPanel;
    public Button boostButton; 
    public PlayerSword playerSword; 

    void Start()
    {
       
        if (boostButton != null)
        {
            boostButton.onClick.AddListener(IncreaseAttackPower);
        }
    }

    public void IncreaseAttackPower()
    {
        
        if (playerSword != null)
        {
            playerSword.attackPower += 5; 
        }
    }

    public void EndPanel(){
        Debug.Log("I see");
        if (promptPanel != null)
            {
                Debug.Log($"Panel current state: {promptPanel.activeSelf}");
           Debug.Log("I see pan");
            promptPanel.SetActive(false);
           Debug.Log($"Panel new state: {promptPanel.activeSelf}");
            }
    }
}
