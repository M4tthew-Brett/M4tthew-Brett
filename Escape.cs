using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
    public HUD hud;
    public AudioClip clip;

    private void OnTriggerEnter(Collider collidedWith)
    {
        if (collidedWith.CompareTag("Player"))
        {
         if (hud.keys >= hud.keysToCollect)
         AudioSource.PlayClipAtPoint(clip, transform.position);
            hud.EndGame();
        }
    }
}