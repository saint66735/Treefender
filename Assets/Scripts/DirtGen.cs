using System;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;


public class DirtGen : MonoBehaviour
{
    [SerializeField] private GameObject normalDirt;
    [SerializeField] private GameObject rareDirt;
    [SerializeField] private int rowCount;
    [SerializeField] private int columnCount;

    private int[] dirtQ;
    private void Start()
    {
        int totalBlocks = rowCount * columnCount;
        Vector3 startCoords = new Vector3(-11.5f, -5.5f, 0);
        Vector3 currentCoords = new Vector3(-11.5f, -5.5f, 0);
        dirtQ = Enumerable.Repeat(0, totalBlocks).Select(i => Random.Range(0, 20)).ToArray();
        for (int i = 0; i < totalBlocks; i++)
        {
            if (Vector3.Distance(startCoords, currentCoords) == columnCount)
            {
                startCoords += Vector3.down;
                currentCoords = startCoords;
            }
            if (dirtQ[i] > 15)
            {
                Instantiate(rareDirt, currentCoords, Quaternion.identity);
            }
            else
            {
                Instantiate(normalDirt, currentCoords, Quaternion.identity);
            }
            currentCoords += Vector3.right;
        }
    }
}
