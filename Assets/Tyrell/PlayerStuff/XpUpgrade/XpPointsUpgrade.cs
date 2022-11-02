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

    private void Start()
    {
        
        Player = GameObject.FindWithTag("Player");
        levelStats = Player.GetComponent<LevelSystem>();


        _canvas.SetActive(false);
    }

    private void Update()
    {
        XpPoints.text = "Lincoln Points: " + levelStats.EXPpoints ;
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
            _animator.SetTrigger("UIClose");
        }
    }

    public void CloseAnimation()
    {
        _animator.SetTrigger("UIClose");
    }

    public void OpenCanvas()
    {
        if (PlayerData.EnhancementInfoClosed == 0)
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
        Info.SetActive(false);
        ES3.Save("EnhancementInfoClosed", 1);
    }

}
