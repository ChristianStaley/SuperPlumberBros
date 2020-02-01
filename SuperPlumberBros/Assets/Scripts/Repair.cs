using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : MonoBehaviour
{
    [SerializeField]
    private string repairType;


    private BoxCollider bc;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print(gameObject + " " + isEnabled);
    }


    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown("e") && GM.tool == repairType && Vector3.Distance(transform.position, other.transform.position) <= 2)
        {
            GM.Score = 100;
            gameObject.SetActive(false);
        }
    }

}
