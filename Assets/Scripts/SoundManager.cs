using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;
    public AudioClip blow;
    public AudioClip shoot;
    public AudioClip impact;
    public AudioClip damage;
    public AudioClip victory;
    public AudioClip powerUp;
    public AudioClip dialogBoss;
    public AudioClip dialogBossFinal;
    public AudioClip dialogEnemy;
    public AudioClip dead;
    public AudioClip laser;
    // Start is called before the first frame update

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayLaserSound()
    {
            if (laser != null)
            {
                audioSource.PlayOneShot(laser);
            }
            else
            {
                Debug.Log("laser Sound Missing");
            }
    }
    public void PlayShootSound()
    {
        if (shoot != null)
        {
            audioSource.PlayOneShot(shoot);
        }
        else
        {
            Debug.Log("Shoot Sound Missing");
        }
    }
    public void PlayPowerUpSound()
    {
        if (powerUp != null)
        {
            audioSource.PlayOneShot(powerUp);
        }
        else
        {
            Debug.Log("Shoot Sound Missing");
        }
    }
    public void PlayVictorySound()
    {
        if (victory != null)
        {
            audioSource.PlayOneShot(victory);
        }
        else
        {
            Debug.Log("Jump Sound Missing");
        }
    }
    public void PlayDamageSound()
    {
        if (damage != null)
        {
            audioSource.PlayOneShot(damage);
        }
        else
        {
            Debug.Log("Damage Sound Missing");
        }
    }
    public void PlayBlowSound()
    {
        if (blow != null)
        {
            audioSource.PlayOneShot(blow);
        }
        else
        {
            Debug.Log("Damage Sound Missing");
        }
    }
    public void PlayImpactSound()
    {
        if (impact != null)
        {
            audioSource.PlayOneShot(impact);
        }
        else
        {
            Debug.Log("Damage Sound Missing");
        }
    }
    public void PlayDialogSound(string type)
    {
            if (type == "boss")
            {
                if (dialogBoss)
                {
                audioSource.PlayOneShot(dialogBoss);
                }

            
            }
        if (type == "bossFinal")
        {
            if (dialogBossFinal)
            {
                audioSource.PlayOneShot(dialogBossFinal);
            }


        }
        if (type == "enemy")
            {
                if (dialogEnemy)
                {
                audioSource.PlayOneShot(dialogEnemy);
            }
            
            }
        else
        {
            Debug.Log("Dialog Sound Missing");
        }
    }
    public void PlayDeadSound()
    {
        if (dead != null)
        {
            audioSource.PlayOneShot(dead);
        }
        else
        {
            Debug.Log("Dead Sound Missing");
        }
    }
}