using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform player;
    public float shootingTime = 10f;
    public float startShootingTime = 10f;
    public float waitTime1 = 5f;
    public float waitTime2 = 5f;
    public bool canShoot = true;

    public GameObject Laser_Base;
    public GameObject Laser_Body;
    public GameObject Laser_Floor;
    public GameObject Laser;

    public Rigidbody2D rb;

    public Animator animator;
    public SoundManager soundManager;

    public bool isFlipped = false;

    void Start()
    {
        Laser_Base.GetComponent<Renderer>().enabled = false;
        Laser_Body.GetComponent<Renderer>().enabled = false;
        Laser_Floor.GetComponent<Renderer>().enabled = false;
        Laser_Base.GetComponent<Animator>().enabled = false;
        Laser_Body.GetComponent<Animator>().enabled = false;
        Laser_Floor.GetComponent<Animator>().enabled = false;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void Update()
    {
        shootingTime -= Time.deltaTime;
        if (canShoot && shootingTime <= 0)
        {
            canShoot = false;
            Shoot();
        }
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    public void Shoot()
    {
        shootingTime = startShootingTime;
        animator.SetTrigger("Attack");

        rb.velocity = new Vector2(0f, 0f);
        StartCoroutine(startShootingAnimation());
    }

    IEnumerator startShootingAnimation()
    {
        soundManager.PlayLaserSound();
        yield return new WaitForSeconds(0.2f);

        animator.SetBool("isShooting", true);

        Laser_Base.GetComponent<Renderer>().enabled = true;
        Laser_Body.GetComponent<Renderer>().enabled = true;
        Laser_Floor.GetComponent<Renderer>().enabled = true;
        Laser_Base.GetComponent<Animator>().enabled = true;
        Laser_Body.GetComponent<Animator>().enabled = true;
        Laser_Floor.GetComponent<Animator>().enabled = true;


        //yield return new WaitForSeconds(waitTime1);
        Laser.GetComponent<LaserController>().isActive = true;

        yield return new WaitForSeconds(waitTime2);

        animator.SetBool("isShooting", false);

        Laser_Base.GetComponent<Renderer>().enabled = false;
        Laser_Body.GetComponent<Renderer>().enabled = false;
        Laser_Floor.GetComponent<Renderer>().enabled = false;
        Laser_Base.GetComponent<Animator>().enabled = false;
        Laser_Body.GetComponent<Animator>().enabled = false;
        Laser_Floor.GetComponent<Animator>().enabled = false;
        Laser.GetComponent<LaserController>().isActive = false;

        animator.ResetTrigger("Attack");

        canShoot = true;
    }
}
