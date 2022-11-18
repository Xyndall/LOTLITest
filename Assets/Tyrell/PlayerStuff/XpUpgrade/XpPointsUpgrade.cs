using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class XpPointsUpgrade : MonoBehaviour
{
    public Animator _animator;

    public GameObject _canvas;
    public TextMeshProUGUI XpPoints;

    bool inTrigger;

    public GameObject Player;
    LevelSystem levelStats;

    public GameObject Info;

    AudioSource aSource;
    public AudioClip Click, open, close;

    private void Start()
    {
        aSource = GetComponent<AudioSource>();
        Player = GameObject.FindWithTag("Player");
        levelStats = Player.GetComponent<LevelSystem>();


        _canvas.SetActive(false);
    }

    private void Update()
    {
        XpPoints.text = "Lincoln Points: " + levelStats.EXPpoints ;
    }

    public void PlayClick()
    {
        aSource.PlayOneShot(Click);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            OpenCanvas();
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CloseAnimation();
        }
    }

    public void CloseAnimation()
    {
        if(_canvas.activeSelf)
            aSource.PlayOneShot(close);

        _animator.SetTrigger("UIClose");
    }

    public void OpenCanvas()
    {
        aSource.PlayOneShot(open);
        if (PlayerData.EnhancementInfoClosed == false)
        {
            Info.SetActive(true);
        }
        else
        {
            Info.SetActive(false);
        }
        _animator.SetTrigger("UIOpen");
        _canvas.SetActive(true);
    }

    public void CloseCanvas()
    {
        
        _canvas.SetActive(false);
        GameManager.instance.DestroyItemInfo();
    }

    public void CloseInfo()
    {
        aSource.PlayOneShot(Click);
        Info.SetActive(false);
        PlayerData.EnhancementInfoClosed = true;
        ES3.Save("EnhancementInfoClosed", true);
    }

}
