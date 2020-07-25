using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyController parent;

    void Start()
    {
        parent = GetComponentInParent<EnemyController>();    
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        parent.setShoot(true);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
            parent.setShoot(false);
    }
}
