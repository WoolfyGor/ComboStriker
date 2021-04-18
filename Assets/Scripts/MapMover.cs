using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class MapMover : MonoBehaviour
{
    public GameObject Part0, Part1, Part2, LowerPoint, UpperPoint,BeePrefab,TextBar, CreatedMob;
    Rigidbody2D rbP0, rbP1, rbP2;
    public Text ScoreBar;
    public float speed = 1;
    int score =0;
    bool firstPosTaken=false, secondPosTaken=false, zeroPosTaken=false;
    GameObject[] PointsArray;
    
    // Start is called before the first frame update
    void Start()
    {

        PointsArray = GameObject.FindGameObjectsWithTag("SpawnPoint");
        rbP0 = Part0.GetComponent<Rigidbody2D>();
        rbP1 = Part1.GetComponent<Rigidbody2D>();
        rbP2 = Part2.GetComponent<Rigidbody2D>();
        TextBar = GameObject.FindGameObjectWithTag("ScoreText");
        ScoreBar = TextBar.GetComponent<Text>();
        StartCoroutine("SpeedUp", 1f);

    
    }
    public void RespawnMobs(string PlateName)
    {
        Debug.Log("На платформе :"+PlateName);
        System.Random rnd = new System.Random();
        int MobCount = rnd.Next(1,4);
        Debug.Log("Монстров появится: "+MobCount);
        if (MobCount != 0) { 
        switch (PlateName)
        {
            case "TestBackground0":

                    foreach (GameObject SpawnPointObj in PointsArray)
                    {
                        if (SpawnPointObj.name.Contains("SpawnPoint0"))
                        {
                            for (int i = 0; i < MobCount; i++)
                            {
                                int SpawnPlace = rnd.Next(0, 2);

                                while (SpawnPlace == 0 && zeroPosTaken)

                                {
                                    SpawnPlace = rnd.Next(0, 2);
                                }
                                while (SpawnPlace == 1 && firstPosTaken)
                                {
                                    SpawnPlace = rnd.Next(0, 2);
                                }
                                while (SpawnPlace == 2 && secondPosTaken)
                                {
                                    SpawnPlace = rnd.Next(0, 2);
                                }
                                if (SpawnPointObj.name.Contains("SpawnPoint0" + SpawnPlace.ToString()))
                                {
                                    Debug.Log("Монстр появится на позиции : " + SpawnPlace);
                                    CreatedMob= Instantiate(BeePrefab, SpawnPointObj.transform);
                                    CreatedMob.layer = 1;
                                    switch (SpawnPlace) { case 0: zeroPosTaken = true; break; case 1: firstPosTaken = true; break; case 2: secondPosTaken = true; break; }
                                }

                            }
                        }
                    }
                    break;
                case "TestBackground1":
                    Debug.Log("Первая платформа работает");
                    foreach (GameObject SpawnPointObj in PointsArray)
                    {
                        if (SpawnPointObj.name.Contains("SpawnPoint1"))
                        {
                            for (int i = 0; i < MobCount; i++)
                            {
                                int SpawnPlace = rnd.Next(0, 3);

                                while (SpawnPlace == 0 && zeroPosTaken)

                                {
                                    SpawnPlace = rnd.Next(0, 3);
                                }
                                while (SpawnPlace == 1 && firstPosTaken)
                                {
                                    SpawnPlace = rnd.Next(0, 3);
                                }
                                while (SpawnPlace == 2 && secondPosTaken)
                                {
                                    SpawnPlace = rnd.Next(0, 3);
                                }
                                if (SpawnPointObj.name.Contains("SpawnPoint1" + SpawnPlace.ToString()))
                                {
                                    Debug.Log("Монстр появится на позиции : " + SpawnPlace);
                                    Instantiate(BeePrefab, SpawnPointObj.transform);
                                    switch (SpawnPlace) { case 0: zeroPosTaken = true; break; case 1: firstPosTaken = true; break; case 2: secondPosTaken = true; break; }
                                }

                            }
                        }
                    }
                    break;

                case "TestBackground2":
                    Debug.Log("Вторая платформа работает");
                    foreach (GameObject SpawnPointObj in PointsArray)
                    {
                        if (SpawnPointObj.name.Contains("SpawnPoint2"))
                        {
                            for (int i = 0; i < MobCount; i++)
                            {
                                int SpawnPlace = rnd.Next(0, 2);

                                while (SpawnPlace == 0 && zeroPosTaken)

                                {
                                    SpawnPlace = rnd.Next(0, 2);
                                }
                                while (SpawnPlace == 1 && firstPosTaken)
                                {
                                    SpawnPlace = rnd.Next(0, 2);
                                }
                                while (SpawnPlace == 2 && secondPosTaken)
                                {
                                    SpawnPlace = rnd.Next(0, 2);
                                }
                                if (SpawnPointObj.name.Contains("SpawnPoint2" + SpawnPlace.ToString()))
                                {
                                    Debug.Log("Монстр появится на позиции : " + SpawnPlace);
                                    Instantiate(BeePrefab, SpawnPointObj.transform);
                                    switch (SpawnPlace) { case 0: zeroPosTaken = true; break; case 1: firstPosTaken = true; break; case 2: secondPosTaken = true; break; }
                                }

                            }
                        }
                    }
                    break;
                   
        }
            firstPosTaken = false;secondPosTaken = false;zeroPosTaken = false;
        }

    }
    // Update is called once per frame
    void Update()
    {
        MovePart();
      
     
    }
    void MovePart()
    {
        rbP0.transform.Translate(-Vector2.up * Time.deltaTime * speed) ;
        rbP1.transform.Translate(-Vector2.up * Time.deltaTime * speed);
        rbP2.transform.Translate(-Vector2.up * Time.deltaTime * speed);
    }
    IEnumerator SpeedUp()
    {
        while (true) {

            ScoreBar.text = score.ToString();
            score++;
            speed += 0.1f;
        yield return new WaitForSeconds(1f);
        }
    }
}
