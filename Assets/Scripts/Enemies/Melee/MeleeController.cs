using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeController : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyMeleeController meleeParent;

    void Start()
    {
        meleeParent = GetComponentInParent<EnemyMeleeController>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        meleeParent.setMelee(true);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
            meleeParent.setMelee(false);
    }
}
