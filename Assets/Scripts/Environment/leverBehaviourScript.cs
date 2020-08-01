using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leverBehaviourScript : MonoBehaviour
{
    public Sprite offLever;
    public Sprite onLever;
    
    public GameObject trigger;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("head")){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = onLever;
            trigger.GetComponent<Platform>().Activate();
        }
    }
}
