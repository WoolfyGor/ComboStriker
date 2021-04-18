using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBackground : MonoBehaviour
{
    public GameObject UpperPart,MainMapObj;
    public MapMover MM;
    string PlateName;
    GameObject CurrentChild;
 
    // Start is called before the first frame update
    void Start()
    {
        PlateName = gameObject.name; 
        MM = GameObject.FindGameObjectWithTag("MainMap").GetComponent<MapMover>();
       

      
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
   
        if (collision.tag.Equals("LowerPoint")) {
            transform.position = UpperPart.transform.position;
            
            MM.RespawnMobs(PlateName);
        }
    }
}
