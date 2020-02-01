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



    private void Start()
    {
        
    }


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
            Debug.Assert(value > 0, "Adding negative score error");
            mSingleton.mScore += value;
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

    public static int Level
    {
        get
        {
            return mSingleton.mLevel;
        }
    }

    //[SerializeField]
    //private GameObject GameOverText;    //Set in IDE

    //[SerializeField]
    //private GameObject PressPlayText;    //Set in IDE

    //[SerializeField]
    //private GameObject NextLevelText;    //Set in IDE

    public enum GameStates
    {
        None,
        Init,
        Startup,
        PressPlay,
        Play,
        Playing,
        NextLevel,
        GameOver,
    }

    GameStates mCurrentState = GameStates.None;

    static public GameStates GameState
    {
        private set
        {
            if (value != mSingleton.mCurrentState)
            {
                mSingleton.ExitState(mSingleton.mCurrentState);
                GameStates tNextState = mSingleton.EnterState(value);
                if (value == tNextState)
                {
                    mSingleton.mCurrentState = tNextState;
                }
                else
                {
                    mSingleton.mCurrentState = value;
                    GameState = tNextState;
                }
            }
        }
        get
        {
            return mSingleton.mCurrentState;
        }
    }


    private GameStates EnterState(GameStates vState)
    {
        Debug.LogFormat("Enter State {0}", vState);
        switch (vState)
        {
            case GameStates.Init:

                GameClear();
                return GameStates.PressPlay;

            case GameStates.PressPlay:

                break;

            case GameStates.Play:
                
                return GameStates.Playing;

            case GameStates.NextLevel:
                mLevel++;
                return GameStates.Playing;

            case GameStates.GameOver:

                break;

            default:
                break;
        }
        return vState;
    }

    private void ExitState(GameStates vState)
    {
        Debug.LogFormat("Exit State {0}", vState);
        switch (vState)
        {
            case GameStates.PressPlay:

                break;
            default:    //No Action
                break;
        }
    }

    IEnumerator GameStateCoRoutine()
    {
        do
        {
            switch (GameState)
            {

                case GameStates.PressPlay:
                    if (Input.GetKey(KeyCode.Space))
                    {
                        GameState = GameStates.Play;    //Go to new state
                    }
                    break;

                case GameStates.Playing:
                    {

                    }
                    break;

                case GameStates.GameOver:
                    if (Input.GetKey(KeyCode.Space))
                    {
                        GameState = GameStates.Init;    //Go to new state
                    }
                    break;

                default:    //No Action
                    break;
            }
            yield return new WaitForSeconds(0.1f);  //Wait for a 10th of a second before runnign again, lets other stuff process
        } while (true); //Never End
    }


    static public void InitGame()
    {
        mSingleton.mScore = 0;  //Reset Score
        mSingleton.mLevel = 1;  //Start at Level 1
        GameState = GameStates.Init;
    }

    public static void StartGame()
    {


    }

    public static void GameClear()
    {
        //FakePhysicsBase[] tFFObjects = FindObjectsOfType<FakePhysicsBase>();
        //foreach (var tFF in tFFObjects)
        //{
        //    Destroy(tFF.gameObject);
        //}
    }

    #endregion

    #region Debug


    private void Update()
    {
        print(GM.tool);
        print(GM.Score);

    }

    #endregion
}
