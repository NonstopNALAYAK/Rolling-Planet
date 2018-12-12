using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBallObstacle : MonoBehaviour
{
    public GameObject objectToPool;
    public int numberOfObject;
    public List<GameObject> listOfObject;
    bool ballSpawner1 = true;
    bool ballSpawner2 = false;

    // Use this for initialization
    void Start()
    {
        SpawnObjectsFirstTime();
        InvokeRepeating("BallSpawnerOne", 3f, 10f);
        InvokeRepeating("BallSpawnerTwo", 3f, 10f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObjectsFirstTime()
    {
        for (int i = 0; i < numberOfObject; i++)
        {
            GameObject aObject = Instantiate(objectToPool, transform.position, Quaternion.identity);
            aObject.transform.parent = this.transform;
            aObject.name = "Ball_" + i.ToString();
            aObject.SetActive(false);
            listOfObject.Add(aObject);
        }
    }

    void BallSpawnerOne()
    {
        if (ballSpawner1)
        {
            ballSpawner1 = !ballSpawner1;
        }
        else
        {
            ballSpawner1 = true;
        }
        for (int i = 0; i < 24; i++)
        {
            Vector3 pos = Random.onUnitSphere * 265f;
            //Instantiate(objectToPool, pos, Quaternion.identity);
            listOfObject[i].transform.position = pos;
            listOfObject[i].SetActive(ballSpawner1);
        }
    }

    void BallSpawnerTwo()
    {
        if (ballSpawner2 == false)
        {
            ballSpawner2 = true;
        }
        else
        {
            ballSpawner2 = false;
        }
        for (int i = 24; i < 50; i++)
        {
            Vector3 pos = Random.onUnitSphere * 265f;
            //Instantiate(objectToPool, pos, Quaternion.identity);
            listOfObject[i].transform.position = pos;
            listOfObject[i].SetActive(ballSpawner2);
        }
    }
}

