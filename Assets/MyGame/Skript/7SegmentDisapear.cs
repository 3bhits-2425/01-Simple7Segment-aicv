using UnityEngine;

public class SevenSegmentDisapear : MonoBehaviour
{
    private Transform[] segments;
    private int currentNumber = 0;

    private readonly int[][] segmentStates = new int[][]
    {
        new int[] { 1, 1, 1, 1, 1, 1, 0 },  // 0
        new int[] { 0, 1, 1, 0, 0, 0, 0 },  // 1
        new int[] { 1, 1, 0, 1, 1, 0, 1 },  // 2
        new int[] { 1, 1, 1, 1, 0, 0, 1 },  // 3
        new int[] { 0, 1, 1, 0, 0, 1, 1 },  // 4
        new int[] { 1, 0, 1, 1, 0, 1, 1 },  // 5
        new int[] { 1, 0, 1, 1, 1, 1, 1 },  // 6
        new int[] { 1, 1, 1, 0, 0, 0, 0 },  // 7
        new int[] { 1, 1, 1, 1, 1, 1, 1 },  // 8
        new int[] { 1, 1, 1, 1, 0, 1, 1 }   // 9
    };

    void Start()
    {
        segments = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            segments[i] = transform.GetChild(i);
            Debug.Log($"Segment {i}: {segments[i].name}");
        }

        SetInitialRotation();
        UpdateDisplay();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform. rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentNumber = (currentNumber + 1) % 10;
            UpdateDisplay();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentNumber = (currentNumber + 9) % 10;
            UpdateDisplay();
        }

        for (int i = 0; i <= 9; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i) || Input.GetKeyDown(KeyCode.Keypad0 + i))
            {
                currentNumber = i;
                UpdateDisplay();
            }
        }
    }

    void UpdateDisplay()
    {
        for (int i = 0; i < segments.Length; i++)
        {
            segments[i].gameObject.SetActive(segmentStates[currentNumber][i] == 1);
        }
    }

    void SetInitialRotation()
    {
        foreach (Transform segment in segments)
        {
            if (segment.name == "top" || segment.name == "middle" || segment.name == "bottom")
            {
                segment.localRotation = Quaternion.Euler(0, -90, 90);  // Waagrechte Segmente
            }
            else
            {
                segment.localRotation = Quaternion.Euler(-90, -90, 90); // Vertikale Segmente
            }
        }
    }
}
