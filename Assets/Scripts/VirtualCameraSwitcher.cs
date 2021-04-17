﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VirtualCameraSwitcher : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    public CinemachineVirtualCamera[] VirCarmeras;
    public float maxDistance;
    public float currentDis;
    public GameObject white;
    public GameObject dark;


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        VirCarmeras[3].GetComponent<CinemachineVirtualCamera>().Priority = 5;
    }

    // Update is called once per frame
    void Update()
    {
        currentDis = Vector3.Distance(white.transform.position, dark.transform.position);
        if (currentDis > maxDistance) {
            if (gameManager.whiteActive)
            {

                VirCarmeras[0].GetComponent<CinemachineVirtualCamera>().Priority = 10;
                VirCarmeras[1].GetComponent<CinemachineVirtualCamera>().Priority = 11;
                VirCarmeras[2].GetComponent<CinemachineVirtualCamera>().Priority = 10;

            }
            else
            {
                VirCarmeras[0].GetComponent<CinemachineVirtualCamera>().Priority = 10;
                VirCarmeras[1].GetComponent<CinemachineVirtualCamera>().Priority = 10;
                VirCarmeras[2].GetComponent<CinemachineVirtualCamera>().Priority = 11;

            }
        }
        else
        {

            VirCarmeras[0].GetComponent<CinemachineVirtualCamera>().Priority = 11;
            VirCarmeras[1].GetComponent<CinemachineVirtualCamera>().Priority = 10;
            VirCarmeras[2].GetComponent<CinemachineVirtualCamera>().Priority = 10;
        }
    }
    }

