using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;
    public Boolean active = true;

    Vector3 nextPos;

    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == pos1.position)
        {
            nextPos = pos2.position;
        }
        if(transform.position == pos2.position)
        {
            nextPos = pos1.position;
        }


        if (active)
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    public void Activate()
    {
        active = !active;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}
