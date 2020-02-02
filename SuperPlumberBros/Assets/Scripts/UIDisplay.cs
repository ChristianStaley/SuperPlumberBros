using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    public Text textScore;
    public Text textTool;
    public Text textLevel;
    public Text textTime;
    public Image imageHammer;
    public Image imageWrench;
    public GameObject objectGameOver;
    public Camera cameraGameOver;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GM.GameOver)
        {
            
            if (imageHammer != null && GM.tool == "Hammer")
            {
                imageHammer.enabled = true;
                imageWrench.enabled = false;
            }
            if (imageWrench != null && GM.tool == "Wrench")
            {
                imageWrench.enabled = true;
                imageHammer.enabled = false;
            }

            if (textTime != null)
                textTime.text = "Time Left: " + Mathf.Round(GM.Timer);


            if (textScore!=null)
                textScore.text = "Score " + GM.Score;
            if(textTool!=null)
                textTool.text = "Tool: " + GM.tool;
            if (textLevel != null)
                textLevel.text = "Level: " + GM.Level;

            if(objectGameOver != null)
            {
                objectGameOver.SetActive(false);
            } 


            if(cameraGameOver!=null)
                cameraGameOver.enabled = false;
        }

        if (objectGameOver != null && GM.GameOver)
        {
            objectGameOver.SetActive(true);
            cameraGameOver.enabled = true;
            GM.StartTime();

        }
    }
}
