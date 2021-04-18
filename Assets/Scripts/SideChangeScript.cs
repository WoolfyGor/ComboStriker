using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SideChangeScript : MonoBehaviour
{
    int Side;
    ButtonAction BA;
    public GameObject Explosion;
    // Start is called before the first frame update
    void Start()
    {
    
        BA = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ButtonAction>();
        System.Random rnd = new System.Random();
        Side = rnd.Next(0, 2);
        Debug.Log(Side);
        if (Side == 0)
        {
            this.transform.localScale=new Vector3(0.2f,0.2f,1);
            this.name = name + "Right";
        }
        else
        {
            this.name = name + "Left";
            this.transform.localScale = new Vector3(-0.2f, 0.2f, 1);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "RightArm" && this.name.Contains("Right"))
        {
            GameObject Exp = Instantiate(Explosion, transform);
            Exp.transform.parent = null;
            Destroy(this.gameObject);
        }
       
            if(collision.tag == "LeftArm" && this.name.Contains("Left"))
            {

            GameObject Exp =Instantiate(Explosion, transform);
            Exp.transform.parent = null;
            Destroy(this.gameObject);
            }
          
        if(collision.tag == "RightArm" && this.name.Contains("Left"))
        {
            BA.GameOver();
        }
        if (collision.tag == "LeftArm" && this.name.Contains("Right"))
        {
            BA.GameOver();
        }


    }


}
