using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HealthBar : MonoBehaviour
{
    //When you draw the health bar, just draw 10 hearts, it is set up that way currently 

    [SerializeField] private Health playerHealth;

    [SerializeField] private Image totalHealthBar;

    [SerializeField] private Image currentHealthBar;
    // Start is called before the first frame update
    void Start()
    {
        //totalHealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

    // Update is called once per frame
    void Update()
    {
        //currentHealthBar.fillAmount = playerHealth.currentHealth /10; 
    }
}
