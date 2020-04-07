using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarScript : MonoBehaviour
{
    
    Image healthBar;
    float maxHealth = 100f;
    public static float health;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        health = maxHealth;
        //GetComponent<PlayerControl>().health
    }

    // Update is called once per frame
    void Update()
    {
        //health = GetComponent<PlayerControl>().health;
        health = Player.gameObject.GetComponent<PlayerControl>().health;
        healthBar.fillAmount = health / maxHealth; 
    }
}
