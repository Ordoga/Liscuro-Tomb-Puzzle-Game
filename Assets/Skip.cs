using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;



public class Skip : MonoBehaviour
{

    [SerializeField] VideoPlayer vid;

    // Start is called before the first frame update
    void Start()
    {
        vid.loopPointReached += CheckOver;

    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("Levels");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene("Levels");
        }
    }
}
