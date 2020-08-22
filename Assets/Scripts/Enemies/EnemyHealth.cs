using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currhealth;
    public SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        currhealth = maxHealth;
        soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currhealth <= 0) {
            Die();
        }
    }

    public void takeDamage(int damage){
        if(currhealth > damage){
            currhealth -= damage;
            soundManager.PlayImpactSound();
        }
        else{
            currhealth = 0;
        }

    }
    void Die()
    {
        // soundManager.PlayDamageSound();
        Destroy(gameObject);
    }
}
