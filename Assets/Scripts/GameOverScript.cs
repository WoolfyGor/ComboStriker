using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    ButtonAction BA;
    private void Start()
    {
        BA = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ButtonAction>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag== "Enemy") { 
        BA.GameOver();
        Destroy(collision);
        }
    }
}
