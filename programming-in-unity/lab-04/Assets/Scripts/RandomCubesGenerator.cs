using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

public class RandomCubesGenerator : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    public int maxObjectsNumber = 10;
    int objectCounter = 0;
    // obiekt do generowania
    public GameObject block;
    // plaszczyzna na ktora generujemy obiekty
    public Transform plane;

    private float planeXsize;
    private float planeZsize;

    public Material[] materials;

    bool AreCoordinatesCanBeInDictionary(Dictionary<float, float> dictionary, KeyValuePair<float, float> cords)
    {
        foreach (KeyValuePair<float, float> pair in dictionary)
        {
            if (Math.Abs(pair.Key - cords.Key) <= 1)
            {
                if (Math.Abs(pair.Value - cords.Value) <= 1)
                    return false;
            }
        }

        return true;
    }

    void Start()
    {
        Dictionary<float, float> coordinates = new Dictionary<float, float>();
        // pobieramy rozmiar Plane korzystajac z mesh
        Mesh mesh = plane.transform.GetComponent<MeshFilter>().mesh;
        planeXsize = mesh.bounds.size.x * plane.localScale.x;
        planeZsize = mesh.bounds.size.z * plane.localScale.z;

        // w momecie uruchomienia generuje 10 kostek w losowych miejscach

        int i = 0;
        while (i < maxObjectsNumber)
        {
            // losujemy punkty x i y na podstawie rozmiaru plaszczyzny
            float positionX = Random.Range(-planeXsize / 2f, planeXsize / 2f);
            float positionZ = Random.Range(-planeZsize / 2f, planeZsize / 2f);
            KeyValuePair<float,float>newCoordinates = new KeyValuePair<float, float>(positionX, positionZ);
            // sprawdzamy czy wylosowane punkty nie sa zbyt bliskie tym, ktore juz mamy
            if (AreCoordinatesCanBeInDictionary(coordinates, newCoordinates))
            {
                coordinates.Add(positionX, positionZ);
                this.positions.Add(new Vector3(positionX, 5, positionZ));
                i++;
            }
        }

        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {

    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywołano coroutine");
        foreach (Vector3 pos in positions)
        {
            Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            this.block.GetComponent<Renderer>().material = materials[Random.Range(0, materials.Length)];
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}
