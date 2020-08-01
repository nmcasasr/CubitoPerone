using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDetection : MonoBehaviour
{
    public Transform transformL;
    public int floor;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitL = Physics2D.Raycast(transformL.position, Vector2.down, 2f, floor);

        //print(transformL.position);
        //print(Vector2.down);

        Debug.DrawRay(transformL.position, Vector2.down, Color.red);

        if (hitL.collider == null)
        {
            print("can't move");
            gameObject.GetComponent<EnemyMeleeController>().setMove(false);
        }
        else
        {
            print("movin'");
            gameObject.GetComponent<EnemyMeleeController>().setMove(true);
        }
    }
}
