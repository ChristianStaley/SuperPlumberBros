using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : MonoBehaviour
{
    [SerializeField]
    private string repairType;

    private float lastReset;
    private float timeTillReset = 5.0f;

    public bool isActive = false;

    private void Start()
    {
        lastReset = Time.time + timeTillReset;
    }

    private void OnEnable()
    {
        lastReset = Time.time + timeTillReset;
    }


    private void Update()
    {
        if(Time.time > lastReset && !GM.GameOver)
        {
            GM.Score = -(10 * GM.Level);
            lastReset += timeTillReset;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown("e") && GM.tool == repairType) // && Vector3.Distance(transform.position, other.transform.position) <= 3
        {
            GM.Score = 100 * GM.Level / 2;
            GM.AddTime(3.0f/GM.Level + 0.5f);
            lastReset += timeTillReset;
            gameObject.SetActive(false);
        }
    }

}
