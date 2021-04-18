using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonAction : MonoBehaviour
{
   public GameObject Hero,MenuUi,GameUi,Map,FakeMap,GameOverUi,LeftArm,RightArm,FireBallContainer,MusicContainer,SoundButton,MusicButton;
    public Animator HeroAnim;
    public Animator LeftArmPunch, RightArmPunch;
    public Sprite SoundOn, SoundOff, MusicOn, MusicOff;
  
    SpriteRenderer SoundSR, MusicSR;
    public AudioSource FireballShot,BackgroundShot;
    bool SoundOnBool = true, MusicOnBool = true;
    MapMover MM;
    // Start is called before the first frame update
    void Start()
    {
        FireballShot = FireBallContainer.GetComponent<AudioSource>();
        BackgroundShot = MusicContainer.GetComponent<AudioSource>();
        SoundSR = SoundButton.GetComponent<SpriteRenderer>();
        MusicSR = MusicButton.GetComponent<SpriteRenderer>();
      
    }

    public void onClickL()
    {
        LeftArmPunch.SetBool("Attacking", true);
        FireballShot.Play();
        Debug.Log("Левая");
        HeroAnim.SetBool("AttackingLeft", true);
        LeftArm.SetActive(true);
        StartCoroutine("UndoAction");
    }
    public void onClickExit()
    {
        Debug.Log("Выход");
        Application.Quit();
        
    }
    public void onClickMusic()
    {
        if (MusicOnBool)
        {
            MusicSR.sprite = MusicOff;
            MusicOnBool = false;
            BackgroundShot.volume = 0;
        }
        else
        {
            MusicSR.sprite = MusicOn;
            MusicOnBool = true;
            BackgroundShot.volume = 100;
        }

    }
    public void onClickSound()
    {
       

        if (SoundOnBool)
        {
            SoundSR.sprite = SoundOff;
            SoundOnBool = false;
            FireballShot.volume = 0;
        }
        else
        {
            SoundSR.sprite = SoundOn;
            SoundOnBool = true;
            FireballShot.volume = 100;
        }
    }
    public void onClickR()
    {
        RightArmPunch.SetBool("Attacking", true);
        FireballShot.Play();
        RightArm.SetActive(true);
        HeroAnim.SetBool("AttackingRight", true);
        StartCoroutine("UndoAction");
       
    }
    IEnumerator UndoAction()
    {
        yield return new WaitForSeconds(0.3f);
        Debug.Log("Отключаю");
        LeftArm.SetActive(false);
        RightArm.SetActive(false);
        LeftArmPunch.SetBool("Attacking", false);
        RightArmPunch.SetBool("Attacking", false);
        HeroAnim.SetBool("AttackingRight", false);
        HeroAnim.SetBool("AttackingLeft", false);
       

    }
    public void onClickStart()
    {
        GameUi.gameObject.SetActive(true);
        MenuUi.gameObject.SetActive(false);
        FakeMap.gameObject.SetActive(false);
        Map.gameObject.SetActive(true);
        Hero.gameObject.SetActive(true);
        GetObj();
    }
    public void onClickRestart()
    {
        SceneManager.LoadScene(0);

    }
    void GetObj()
    {
        try {
            Hero = GameObject.FindGameObjectWithTag("Player");
            HeroAnim = Hero.GetComponent<Animator>();
            MM = Map.GetComponent<MapMover>();
            LeftArmPunch = GameObject.Find("PunchAnimL").GetComponent<Animator>();
            RightArmPunch = GameObject.Find("PunchAnimR").GetComponent<Animator>();

        }
        catch {
        }
    }
    
   public void GameOver()
    {
        GameUi.gameObject.SetActive(false);
        Hero.gameObject.SetActive(false);
        MM.StopAllCoroutines();
        MM.enabled = false;
        GameOverUi.SetActive(true);

    }
}
