using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currhealth;
    // Start is called before the first frame update
    void Start()
    {
        currhealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)){
            this.takeDamage(20);
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
