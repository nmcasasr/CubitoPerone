using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeView : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyMeleeController meleeParent;
    public Transform transformL;
    public int floor;

    void Start()
    {
        meleeParent = GetComponentInParent<EnemyMeleeController>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            RaycastHit2D hitL = Physics2D.Raycast(transformL.position, Vector2.down, 2f, floor);

            if(hitL.collider != null)
                meleeParent.setMove(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            meleeParent.setMove(false);
            print("Player gone");
        }
    }
}
