using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            DontDestroyOnLoad(gameObject);
        }
        else if (mSingleton != this)
        {
            Destroy(gameObject);
        }
    }



    #endregion

    

    #region Spawning

    public enum Prefabs
    {
        WaterParticle,
        GasParticle,
        LastOne
    };

    [SerializeField]
    private GameObject[] SpawnablePrefabs;
    private static GameObject mPlayer;

    public static GameObject SpawnPrefab(Prefabs vPrefab, Vector2 vPosition, Quaternion vRotation) //Spawns the requested prefab at the specified position and rotation
    {
        int tIndex = (int)vPrefab;
        if (mSingleton.SpawnablePrefabs != null && tIndex < mSingleton.SpawnablePrefabs.Length)
        {
            {
                if (mPlayer = null)
                    mPlayer = Instantiate(mSingleton.SpawnablePrefabs[tIndex], vPosition, vRotation);
                else
                    return Instantiate(mSingleton.SpawnablePrefabs[tIndex], vPosition, vRotation);
            }
        }

        return null;
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



    #region GameStates

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
        if (Time.time > lastTime)
        {
            mLevel++;
            lastTime += waitTime;
        }
    }


    #endregion

    #region Time

    private bool gameOver = false;

    float currentTime = 30.0f;
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

    private void Update()
    {

        IncreaseLevel();
        CountTime();
        if (gameOver)
        {
            print("GameOver Score: " + Score);
        }
    }

}
