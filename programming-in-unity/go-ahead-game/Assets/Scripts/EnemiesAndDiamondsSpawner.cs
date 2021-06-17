using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesAndDiamondsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject neutralCube = null;
    [SerializeField] private GameObject enemyCube = null;
    [SerializeField] private GameObject diamond = null;
    [SerializeField] private GameObject rotatingArm = null;

    [SerializeField] private float minimumX = -5;
    [SerializeField] private float maximumX = 5;
    [SerializeField] private float minimumZ = 15;
    [SerializeField] private float maximumZ = 140;
    [SerializeField] private float y = 0.5f;

    [SerializeField] private float xDistance = 1.5f;
    [SerializeField] private float zDistance = 1.5f;

    [SerializeField] private int numberOfNeutralCubes = 120;
    [SerializeField] private int numberOfEnemyCubes = 40;
    [SerializeField] private int numberOfDiamonds = 20;
    [SerializeField] private int numberOfRotatingArms = 5;

    private List<Vector3> positions;

    private List<float> GetPossiblePoints(float minimum, float maximum, float distance)
    {
        List<float> xPos = new List<float>();
        float i = minimum;

        while (i <= maximum)
        {
            xPos.Add(i);
            i += distance;
        }

        return xPos;
    }
    
    private List<Vector3> CreatePossiblePositions()
    {
        List<Vector3> result = new List<Vector3>();
        List<float> possibleX = GetPossiblePoints(minimumX, maximumX, xDistance);
        List<float> possibleZ = GetPossiblePoints(minimumZ, maximumZ, zDistance);

        foreach (float x in possibleX)
        {
            foreach (float z in possibleZ)
            {
                Vector3 newVector = new Vector3(x, y, z);
                result.Add(newVector);
            }
        }

        return result;

    }

    private List<Vector3>GetPositions()
    {
        List<Vector3> result = new List<Vector3>();
        List<Vector3> allPositions = CreatePossiblePositions();
        int i = 0;
        while (i < (numberOfNeutralCubes + numberOfEnemyCubes + numberOfDiamonds + numberOfRotatingArms))
        {
            int randomIndex = Random.Range(0, allPositions.Count);
            Vector3 randomVector = allPositions[randomIndex];
            allPositions.RemoveAt(randomIndex);
            result.Add(randomVector);
            i++;
        }
        return result;
    }

    private void Start()
    {
        int i = 0;
        positions = GetPositions();

        foreach (Vector3 position in positions)
        {
            if (i<numberOfNeutralCubes)
                Instantiate(neutralCube, position, Quaternion.identity);
            else if (i >= numberOfNeutralCubes && i < (numberOfNeutralCubes + numberOfEnemyCubes))
                Instantiate(enemyCube, position, Quaternion.identity);
            else if (i >= (numberOfNeutralCubes + numberOfEnemyCubes) && i < (numberOfNeutralCubes + numberOfEnemyCubes + numberOfDiamonds))
                Instantiate(diamond, position, diamond.transform.rotation);
            else if (i >= (numberOfNeutralCubes + numberOfEnemyCubes + numberOfDiamonds) && i < (numberOfNeutralCubes + numberOfEnemyCubes + numberOfDiamonds + numberOfRotatingArms))
                Instantiate(rotatingArm, position, Quaternion.identity);
            i++;
        }
    }
}
