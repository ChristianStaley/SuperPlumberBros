using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{


    private string level;

    void Start()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string newLevel)
    {
        SceneManager.LoadScene(newLevel);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
