using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeOut : MonoBehaviour
{
    Color image;
    float CurrentAlpha;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>().color;
        CurrentAlpha = image.a;

        StartCoroutine("FadeIn");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
IEnumerator FadeIn()
    {
        while(CurrentAlpha>0)
        {
            Debug.Log(CurrentAlpha);
            CurrentAlpha -= 0.01f;
            GetComponent<Image>().color = new Color(79 / 255.0f, 165 / 255.0f, 63 / 255.0f, CurrentAlpha);
            yield return new WaitForSeconds(0.1f);
        }
        this.transform.localScale = new Vector3(transform.localScale.x, 10);
        yield return null;
    }
}
