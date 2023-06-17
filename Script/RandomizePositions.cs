using UnityEngine;

public class RandomizePositions : MonoBehaviour
{
    public GameObject redDroid;
    public GameObject greenDroid;
    public GameObject mazeGenerator;

    private int mazeWidth;
    private int mazeHeight;

    private void Start()
    {
        MazeGenerator generator = mazeGenerator.GetComponent<MazeGenerator>();
        mazeWidth = generator.mazeRows;
        mazeHeight = generator.mazeColumns;
    }

    public void RandomizeDroidPositions()
    {
        Vector2 redPosition = GetValidRandomPosition();
        Vector2 greenPosition = GetValidRandomPosition();

        redDroid.transform.position = redPosition;
        greenDroid.transform.position = greenPosition;
    }

    private Vector2 GetValidRandomPosition()
    {
        Vector2 position;
        int maxAttempts = 100;
        int attempt = 0;

        do
        {
            int x = Random.Range(1, mazeWidth + 1);
            int y = Random.Range(1, mazeHeight + 1);
            position = new Vector2(x, y);
            attempt++;
        }
        while (!IsValidPosition(position) && attempt < maxAttempts);

        if (attempt >= maxAttempts)
        {
            Debug.LogWarning("Failed to find valid position within max attempts.");
            position = Vector2.zero;
        }

        return position;
    }

    private bool IsValidPosition(Vector2 position)
    {
        // Convert position to integer coordinates
        int x = Mathf.RoundToInt(position.x);
        int y = Mathf.RoundToInt(position.y);

        // Check if the position is within the maze boundaries
        return x >= 1 && x <= mazeWidth && y >= 1 && y <= mazeHeight;
    }
}
