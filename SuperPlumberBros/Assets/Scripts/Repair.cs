using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : MonoBehaviour
{
    [SerializeField]
    private string repairType;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown("e") && GM.tool == repairType) // && Vector3.Distance(transform.position, other.transform.position) <= 3
        {
            GM.Score = 100;
            GM.AddTime(5.0f/GM.Level + 0.5f);
            gameObject.SetActive(false);
        }
    }

}
