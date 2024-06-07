using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // Assign the coin prefab in the Inspector

    private Vector3[] coinPositions = new Vector3[]
    {
        new Vector3(10, 0.5f, 10),
        new Vector3(20, 0.5f, 15),
        new Vector3(5, 0.5f, 30),
        new Vector3(15, 0.5f, 45),
        new Vector3(25, 0.5f, 25),
        new Vector3(35, 0.5f, 10),
        new Vector3(45, 0.5f, 35),
        new Vector3(50, 0.5f, 20),
        new Vector3(40, 0.5f, 40),
        new Vector3(30, 0.5f, 50),
        new Vector3(55, 0.5f, 55),
        new Vector3(60, 0.5f, 10),
        new Vector3(10, 0.5f, 55),
        new Vector3(20, 0.5f, 50),
        new Vector3(25, 0.5f, 5),
        new Vector3(30, 0.5f, 35),
        new Vector3(35, 0.5f, 25),
        new Vector3(50, 0.5f, 45),
        new Vector3(45, 0.5f, 15),
        new Vector3(55, 0.5f, 30)
    };

    void Start()
    {
        foreach (Vector3 position in coinPositions)
        {
            Instantiate(coinPrefab, position, Quaternion.identity);
        }
    }
}

