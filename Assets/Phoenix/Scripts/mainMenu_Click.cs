using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu_Click : MonoBehaviour
{
    
    private void OnMouseDown()
    {
        SceneManager.LoadScene("StartingArea");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100f))
            {
                //Click on gameobject with "Start" tag
                if (hit.collider.gameObject.tag == "Start")
                {
                    Debug.Log("Start");
                    if (PlayerData.TutorialComplete == 1)
                        SceneManager.LoadScene(3);
                    else
                        StartTutorial();
                }

                if (hit.collider.gameObject.tag == "Quit")
                {
                    Application.Quit();
                }
            }
        }
    }
    public void StartTutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }
}