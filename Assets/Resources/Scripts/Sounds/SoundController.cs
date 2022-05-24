using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource wallSound;
    public AudioSource playerSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool isPlayer = collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2";
        if (isPlayer)  
            this.playerSound.Play();
        else 
            this.wallSound.Play();
    }
}
