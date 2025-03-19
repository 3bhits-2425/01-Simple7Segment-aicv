using UnityEngine;

public class SevenSegmentDisplay : MonoBehaviour
{
    [SerializeField] private GameObject top, rightTop, rightBottom, bottom, leftBottom, leftTop, middle;

    private GameObject[] segments;
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

    private void Start()
    {
        segments = new GameObject[] { top, rightTop, rightBottom, bottom, leftBottom, leftTop, middle };
        SetInitialRotation();
        UpdateDisplay();
    }

    private void Update()
    {
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

    private void UpdateDisplay()
    {
        for (int i = 0; i < segments.Length; i++)
        {
            if (segmentStates[currentNumber][i] == 1)
            {
                // Aktive Segmente bleiben in der ursprünglichen Rotation
                segments[i].transform.localRotation = GetInitialRotation(segments[i].name);
            }
            else
            {
                // Inaktive Segmente drehen sich weg
                segments[i].transform.localRotation = segments[i].name == "A" || segments[i].name == "G" || segments[i].name == "D" ?
                    Quaternion.Euler(0, -90, 0) :  // Waagrechte Balken
                    Quaternion.Euler(-90, 0, 90);  // Vertikale Balken
            }
        }
    }

    private void SetInitialRotation()
    {
        top.transform.localRotation = Quaternion.Euler(0, -90, 90);
        middle.transform.localRotation = Quaternion.Euler(0, 0, 0);
        bottom.transform.localRotation = Quaternion.Euler(0, -90, 90);

        rightTop.transform.localRotation = Quaternion.Euler(-90, 0, 0);
        rightBottom.transform.localRotation = Quaternion.Euler(-90, 0, 0);
        leftTop.transform.localRotation = Quaternion.Euler(-90, 0, 0);
        leftBottom.transform.localRotation = Quaternion.Euler(-90, 0, 0);
    }

    Quaternion GetInitialRotation(string segmentName)
    {
        switch (segmentName)
        {
            case "A":
            case "G":
            case "D":
                return Quaternion.Euler(0, -90, 90);
            case "B":
            case "C":
            case "F":
            case "E":
                return Quaternion.Euler(-90, 0, 0);
            default:
                return Quaternion.identity;
        }
    }
}
