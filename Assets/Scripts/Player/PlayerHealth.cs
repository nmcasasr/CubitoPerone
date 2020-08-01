using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currhealth;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Start is called before the first frame update
    void Start()
    {
        currhealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < hearts.Length; i++){
            if(i < currhealth){
                hearts[i].sprite = fullHeart;
            }else{
                hearts[i].sprite = emptyHeart;
            }

            if(i < maxHealth){
                hearts[i].enabled = true;
            }else{
                hearts[i].enabled = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.K)){
            this.takeDamage(1);
        }
    }

    public void takeDamage(int damage){
        if(currhealth > damage){
            currhealth -= damage;
        }else{
            currhealth = 0;
        }

    }
}
