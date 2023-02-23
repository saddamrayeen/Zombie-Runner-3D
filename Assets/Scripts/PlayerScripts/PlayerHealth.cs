using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int playerHealth = 100;
    private Slider healthSlider;
    GameObject UIHolder;
    // Start is called before the first frame update
    void Start()
    {
        healthSlider = GameObject.Find("Health Bar").GetComponent<Slider>();
        healthSlider.value = playerHealth;
        UIHolder = GameObject.Find("UI Holder");
    }

public void ApplyDamage(int damageAmount)
{
playerHealth-=damageAmount;
if(playerHealth<0)
{
playerHealth=0;
}
healthSlider.value = playerHealth;

if(playerHealth==0)
{
    UIHolder.SetActive(false);
    FindObjectOfType<GamePlayController>().GameOver();
}
}//apply damage










}//class
