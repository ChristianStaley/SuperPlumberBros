using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TriggerLoadLevel : MonoBehaviour
{
    public string levelName;
    public GameObject objectText;

    private float lastTime;
    private float waitTime = 5.0f;
    private bool startTime = false;

    private void Start()
    {
        objectText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        objectText.SetActive(true);
        startTime = true;
        lastTime = Time.time + waitTime;

    }

    private void Update()
    {
        if (startTime)
        {
            print("Startime");
            if (Time.time > lastTime)
            {
                SceneManager.LoadScene(levelName);
            }
        }
    }


}
