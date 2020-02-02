using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    #region Singleton
    static GM mSingleton = null;


    public GM Singleton
    {
        get
        {
            return mSingleton;
        }
    }


    private void Awake()
    {
        if (mSingleton == null)
        {
            mSingleton = this;
            //DontDestroyOnLoad(gameObject);
        }
        else if (mSingleton != this)
        {
            Destroy(gameObject);
        }
    }



    #endregion

    #region Scoring

    int mScore = 0;
    static public int Score
    {
        get
        {
            return mSingleton.mScore;
        }
        set
        {
            mSingleton.mScore += value;
            if (mSingleton.mScore < 0)
                mSingleton.mScore = 0;
        }

    }

    #endregion

    #region Tool

    private string[] toolList = new string[2]
    {
        "Hammer", "Wrench"
    };

    private static int toolMaxRange = 1;
    private static int toolMinRange = 0;
    


    private int currentTool = 0;
    public static string tool
    {
        get
        {

           return mSingleton.toolList[mSingleton.currentTool];
        }

    }

    public static void ChangeTool(int n)
    {
        mSingleton.currentTool += n;
        if (mSingleton.currentTool < 0)
        {
            mSingleton.currentTool = toolMaxRange;
        }
        else if (mSingleton.currentTool > 1)
        {
            mSingleton.currentTool = toolMinRange;
        }
    }

    #endregion



    #region Level

    int mLevel = 1;
    float waitTime = 10.0f;
    float lastTime = 10.0f;

    public static int Level
    {
        get
        {
            return mSingleton.mLevel;
        }
        set
        {
            mSingleton.mLevel = value;
        }
    }

    private void IncreaseLevel()
    {
        if (Time.time > lastTime && !GM.GameOver)
        {
            mLevel++;
            lastTime += waitTime;
        }
    }


    #endregion

    #region Time

    

    float currentTime = 10.0f;
    public static float Timer
    {
        get
        {
            return mSingleton.currentTime;
        }
        set
        {
            mSingleton.currentTime = value;
            if (mSingleton.currentTime < 0)
                mSingleton.currentTime = 0;
        }
    }

    public static void AddTime(float time)
    {
        mSingleton.currentTime += time;
    }

    private static void CountTime()
    {
        if (mSingleton.currentTime >= 0.0f)
        {
            mSingleton.currentTime -= Time.deltaTime;
        }
        else
            mSingleton.gameOver = true;
            

    }

    #endregion
    private bool gameOver = false;
    public GameObject objectPC;

    public static bool GameOver
    {
        get
        {
            return mSingleton.gameOver;
        }
        set
        {
            mSingleton.gameOver = value;
        }
    }


    public static void StartTime()
    {
        mSingleton.startTime = true;
    }


    private float gameOverTime = 0.0f;
    private float gameOverWaitTime = 5.0f;
    private bool startTime = false;

    private void Update()
    {

        IncreaseLevel();
        CountTime();
        if (gameOver)
        {
            if(!startTime)
            {
                gameOverTime = Time.time + gameOverWaitTime;
            }

            if(startTime)
            {
                if (Time.time > gameOverTime)
                {
                    SceneManager.LoadScene("Menu");
                }
            }

        }
    }

}
