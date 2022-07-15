using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        
       BladeController b = other.GetComponent<BladeController>();

       if(!b) { return; }

       FindObjectOfType<GameManager>().OnBombHit();
        
        
    }
}
