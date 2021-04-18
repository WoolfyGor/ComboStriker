using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobDeathByLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("DeadPoint"))
        {
            Destroy(this.gameObject);
        }
    }
}
