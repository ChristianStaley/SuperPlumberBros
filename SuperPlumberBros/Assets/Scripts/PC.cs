using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GM.GameOver)
        {
            if (Input.mouseScrollDelta.y < 0) // Rolled Down
            {
                GM.ChangeTool(1);
            }
            if (Input.mouseScrollDelta.y > 0) // Rolled Up
            {
                GM.ChangeTool(-1);
            }
        }


    }
}
