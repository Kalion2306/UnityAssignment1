using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Customisation : MonoBehaviour
{

    public Color[] colors = { Color.green, Color.red, Color.blue };
    public GameObject[] Headpieces = { };
    public GameObject[] Guns = { };


    private void OnEnable()
    {
        col = PlayerPrefs.GetInt("color");
        head = PlayerPrefs.GetInt("head");
        gun = PlayerPrefs.GetInt("gun");


        GetComponent<Renderer>().material.color = colors[col];

        for (int i = 0; i < Headpieces.Length; i++)
        {
            if (i == head)
            {
                Headpieces[i].SetActive(true);
            }
            else
            {
                Headpieces[i].SetActive(false);
            }
        }

        for (int i = 0; i < Guns.Length; i++)
        {
            if (i == gun)
            {
                Guns[i].SetActive(true);
            }
            else
            {
                Guns[i].SetActive(false);
            }
        }
    }


    private void Start()
    {
        GetComponent<PlayerMovement>().speed = 0;
    }

    //values for all of the objects for referance in UI
    public int setting = 0;
    public int col = 0;
    public int head = 0;
    public int gun = 0;

    // Update is called once per frame
    void Update()
    {
        //checks to see if in customisation scene
        if (SceneManager.GetActiveScene().name == "Customisation")
        {
            GetComponent<PlayerMovement>().speed = 0;

            if(Input.GetKeyDown(KeyCode.W))
            {
                setting--;
                if (setting < 0)
                {
                    setting = 2;
                }
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                setting++;

                if (setting > 2)
                {
                    setting = 0;
                }
            }

            switch (setting)
            {
                case 0:
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        col++;

                        if (col >= colors.Length)
                        {
                            col = 0;
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        col--;

                        if (col <= 0)
                        {
                            col = colors.Length - 1;
                        }
                    }
                    GetComponent<Renderer>().material.color = colors[col];
                    break;
                
                case 1:
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        head++;

                        if (head >= Headpieces.Length)
                        {
                            head = 0;
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        head--;

                        if (head <= 0)
                        {
                            head = Headpieces.Length - 1;
                        }
                    }

                    for (int i = 0; i < Headpieces.Length; i++)
                    {
                        if (i == head)
                        {
                            Headpieces[i].SetActive(true);
                        }
                        else
                        {
                            Headpieces[i].SetActive(false);
                        }
                    }
                    break;

                case 2:
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        gun++;

                        if (gun >= Guns.Length)
                        {
                            gun = 0;
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        gun--;

                        if (gun <= 0)
                        {
                            gun = Guns.Length - 1;
                        }
                    }

                    for (int i = 0; i < Guns.Length; i++)
                    {
                        if (i == gun)
                        {
                            Guns[i].SetActive(true);
                        }
                        else
                        {
                            Guns[i].SetActive(false);
                        }
                    }
                    break;
            }



            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("MainGame");
            }
        }
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("color", col);
        PlayerPrefs.SetInt("head", head);
        PlayerPrefs.SetInt("gun", gun);
    }
}


