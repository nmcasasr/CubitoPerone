using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public float offset;
    public GameObject projectile;
    public Transform shootPoint;
    public SpriteRenderer sprite;

    public bool canShoot;
    
    void Start() {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        sprite.flipX = !(rotZ <=90 && rotZ >=-90);
        if (GameManager.IsInputEnabled)
        {
            if (canShoot)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Instantiate(projectile, shootPoint.position, transform.rotation);
                    canShoot = false;
                    sprite.enabled = false;
                }
            }
        }
    }
    public void setCanShoot(bool value)
    {
        canShoot = value;
        sprite.enabled = value;
    }
}
