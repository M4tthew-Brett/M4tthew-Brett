using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public HUD hud;

    public AudioClip clip;



   

    private void OnTriggerEnter(Collider collidedWith)
    {
        if (collidedWith.CompareTag("Player"))
        {
           
            hud.keys = hud.keys + 1;

         
            AudioSource.PlayClipAtPoint(clip, transform.position);

           
            Destroy(gameObject);
        }
    }
}
// reference:
//https://answers.unity.com/questions/1694614/triggers-how-do-i-use-them-to-finish-a-game.html

