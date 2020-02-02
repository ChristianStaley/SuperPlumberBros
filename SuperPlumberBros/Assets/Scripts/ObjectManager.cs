using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private GameObject[] repairTargets;
    private float lastSpawnTime;
    
    private float waitTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        repairTargets = GameObject.FindGameObjectsWithTag("Repairable");
        foreach (GameObject go in repairTargets)
        {
            //print(go);
            go.SetActive(false);
        }


        lastSpawnTime = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= GM.Level;
        if (waitTime < 1.5f)
        {
            waitTime = 1.5f;
        }


        if (Time.time > lastSpawnTime)
        {
            int newTarget = Random.Range(0, repairTargets.Length);
            repairTargets[newTarget].SetActive(true);
            //print("ACIVATING NEW REPAIR");
            lastSpawnTime += waitTime;
        }
    }
}
