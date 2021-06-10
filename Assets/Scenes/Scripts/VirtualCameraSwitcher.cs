using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VirtualCameraSwitcher : MonoBehaviour
{
    [SerializeField] float darkDelay = 0.8f;
    [SerializeField] float lightDelay = 1.6f;
    [SerializeField] GameManager gameManager;
    public CinemachineVirtualCamera[] VirCarmeras;
    public float maxDistance;
    public float currentDis;
    public GameObject white;
    public GameObject dark;


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        StartCoroutine(ExampleCoroutine());
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
    private IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(darkDelay);
        VirCarmeras[3].GetComponent<CinemachineVirtualCamera>().Priority = 5;
        yield return new WaitForSeconds(lightDelay);
        VirCarmeras[4].GetComponent<CinemachineVirtualCamera>().Priority = 5;

        if (gameManager.whiteActive)
        {
            VirCarmeras[1].GetComponent<CinemachineVirtualCamera>().Priority = 11;
            VirCarmeras[2].GetComponent<CinemachineVirtualCamera>().Priority = 10;
        }
        else
        {
            VirCarmeras[2].GetComponent<CinemachineVirtualCamera>().Priority = 11;
            VirCarmeras[1].GetComponent<CinemachineVirtualCamera>().Priority = 10;
        }
    }

}

