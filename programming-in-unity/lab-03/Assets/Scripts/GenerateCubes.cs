using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GenerateCubes : MonoBehaviour
{
    public int numberOfObjects = 10;

    public GameObject myPrefab;

    bool AreCoordinatesCanBeInDictionary(Dictionary<float, float>dictionary, KeyValuePair<float, float>cords)
    {
        foreach (KeyValuePair<float, float> pair in dictionary)
        {
            if (Math.Abs(pair.Key-cords.Key) <= 1)
            {
                if (Math.Abs(pair.Value-cords.Value) <= 1)
                    return true;
            }
        }

        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        Dictionary<float, float>coordinates = new Dictionary<float, float>();
        int i = 0;
        while (i < numberOfObjects)
        {
            float randomX = Random.Range(-5.0f, 5.0f);
            float randomZ = Random.Range(-5.0f, 5.0f);

            KeyValuePair<float, float>newCoordinates = new KeyValuePair<float, float>(randomX, randomZ);
            if (!AreCoordinatesCanBeInDictionary(coordinates, newCoordinates))
            {
                coordinates.Add(randomX, randomZ);
                Instantiate(myPrefab, new Vector3(randomX, 0.5f, randomZ), Quaternion.identity);
                i++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
