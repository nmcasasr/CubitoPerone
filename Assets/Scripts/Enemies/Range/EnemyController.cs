using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    private bool movingRight, isLeft;
    private bool canShoot;
    private GameObject player;
    public Transform firePoint;
    public GameObject projectilePrefab;
    public float timeBetweenShots, pastTime;
    void Start()
    {
        canShoot = false;
        timeBetweenShots = 1f;
        pastTime = 0f;
        movingRight = false;
        isLeft = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void Update()
    {
        pastTime += Time.deltaTime;
        //Debug.Log(canShoot);
        //Debug.Log(Time.deltaTime);

        isLeft = player.transform.localPosition.x > transform.localPosition.x;

        if (isLeft && !movingRight)
        {
            Flip();
        }
        else if (!isLeft && movingRight)
        {
            Flip();
        }

        if (canShoot && pastTime >= timeBetweenShots)
        {
            Shoot();
        }
        
    }

    public void setShoot(bool val)
    {
        canShoot = val;
    }

    void Shoot()
    {   
        Instantiate(projectilePrefab,firePoint.position,firePoint.rotation);
        pastTime = 0f;
        //timeBetweenShots += Time.deltaTime;
    }

    private void Flip()
    {
        movingRight = !movingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
