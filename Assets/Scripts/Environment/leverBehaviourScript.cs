using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leverBehaviourScript : MonoBehaviour
{
    public Sprite offLever;
    public Sprite onLever;
    
    public GameObject trigger;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Head")){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = onLever;
            trigger.GetComponent<Platform>().Activate();
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
       if(other.gameObject.CompareTag("Head")){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = offLever;
            trigger.GetComponent<Platform>().Activate();
        } 
    }
}
