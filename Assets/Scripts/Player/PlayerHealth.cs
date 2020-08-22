using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currhealth;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public ParticleSystem system;
    public GameObject Canvas;
    public SoundManager soundManager;
    bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        currhealth = maxHealth;
        Canvas = GameObject.Find("DeadCanvas");
        Canvas.SetActive(false);
        soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < hearts.Length; i++){
            if(i < currhealth){
                hearts[i].sprite = fullHeart;
            }else{
                hearts[i].sprite = emptyHeart;
            }

            if(i < maxHealth){
                hearts[i].enabled = true;
            }else{
                hearts[i].enabled = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.K)){
            this.takeDamage(1);
        }
        if (currhealth <= 0)
        {
            Die();
        }
    }

    public void takeDamage(int damage){
        GetComponent<AnimationsController>().animator.SetTrigger("isDamage");

        if(currhealth > damage){
            soundManager.PlayDamageSound();
            currhealth -= damage;
        }else{
            currhealth = 0;
        }

    }
    void Die()
    {
        // Destroy(gameObject);
        if (!isDead)
        {
            soundManager.PlayDeadSound();
            isDead = true;
            GetComponent<SpriteRenderer>().enabled = false;
            Instantiate(system, transform.position, Quaternion.identity);
            // system.Play();
            // GetComponent<SpriteRenderer>().enabled = false;
            // GameObject.Find("DeadCanvas").SetActive(true);
            GameManager.PlayerDead();
            Canvas.SetActive(true);
            StartCoroutine(LoadLevel());

        }
    }
    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
