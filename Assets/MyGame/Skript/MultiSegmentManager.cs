using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class MultiSegmentManager : MonoBehaviour
{
    [SerializeField] private GameObject segment;
    [SerializeField] private Camera cam;
    private GameObject[,] segmentMap = new GameObject[10, 10];
    float startX = -28f;
    float startY = 30f;
    float xSpacing = 10f;
    float ySpacing = 12f;
    int activeSegment = 0;

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                // Berechne die Position für jedes Segment
                float x = startX + j * xSpacing;
                float y = startY - i * ySpacing;
                segmentMap[i, j] = Instantiate(segment, new Vector3(x, y, 0), Quaternion.Euler(0, 180, 0));
            }
        }
    }

    private int[] GetRandomPosition()
    {
        int randX = Random.Range(0, 10);
        int randY = Random.Range(0, 10);

        return new int[] { randX, randY };
    }

    private void Update()
    {
        if (activeSegment < 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                int[] pos = GetRandomPosition();
                GameObject randomSegment = segmentMap[pos[0], pos[1]];
                randomSegment.SetActive(true);
                randomSegment.transform.Rotate(0, 180, 0);
                activeSegment++;
                cam.transform.position = new Vector3(randomSegment.transform.position.x, randomSegment.transform.position.y, -30);

            }
        }  
    }
}