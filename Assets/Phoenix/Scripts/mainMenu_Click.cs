using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class mainMenu_Click : MonoBehaviour
{

    public GameObject Hud;

    public GameObject StartOBJ;
    public GameObject Options;
    public GameObject Quit;

    AudioSource aSource;
    public AudioClip aClip;

    

    private void Start()
    {
        aSource = GetComponent<AudioSource>();
    }


    private void OnMouseDown()
    {
        SceneManager.LoadScene("StartingArea");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100f))
        {

            if (hit.collider.gameObject.tag == "Start" )
            {                
                TextGlow(StartOBJ);
            }
            else TextNormal(StartOBJ);

            if (hit.collider.gameObject.tag == "Quit" )
            {
                TextGlow(Quit);
            }
            else TextNormal(Quit);

            if (hit.collider.gameObject.tag == "Options")
            {
                TextGlow(Options);
            }
            else TextNormal(Options);

            if (hit.collider.gameObject.tag == "WhatIsGround")
            {
                TextNormal(StartOBJ);
                TextNormal(Options);
                TextNormal(Quit);
            }

        }

        if (Input.GetMouseButtonDown(0))
        {
            

            if (Physics.Raycast(ray, out hit, 100f))
            {
                //Click on gameobject with "Start" tag
                if (hit.collider.gameObject.tag == "Start")
                {
                    Debug.Log("Start");
                    if (PlayerData.TutorialCompleted == false)
                        SceneManager.LoadScene(3);
                    else
                        StartTutorial();
                }

                if (hit.collider.gameObject.tag == "Quit")
                {
                    Application.Quit();
                }

                if (hit.collider.gameObject.tag == "Options")
                {
                    Hud.SetActive(true);
                    

                }
            }
        }
    }

    public void StartTutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    void TextGlow(GameObject obj)
    {
        obj.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.white); 
    }

    void TextNormal(GameObject obj)
    {
        obj.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.black);
    }


}