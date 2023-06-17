using UnityEngine;

public class AddDroid : MonoBehaviour
{
    public GameObject redDroidPrefab;
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

    public void AddRedDroid()
    {
        Vector2 randomPosition = GetValidRandomPosition();
        GameObject newRedDroid = Instantiate(redDroidPrefab, randomPosition, Quaternion.identity);
        newRedDroid.GetComponent<DroidMerahG>().greenDroid = greenDroid.transform;
    }

    private Vector2 GetValidRandomPosition()
    {
        Vector2 position;
        int maxAttempts = 100;
        int attempt = 0;

        do
        {
            int x = Random.Range(0, mazeWidth);  
            int y = Random.Range(0, mazeHeight); 
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
       
        int x = Mathf.RoundToInt(position.x);
        int y = Mathf.RoundToInt(position.y);

        
        return x >= 1 && x <= mazeWidth && y >= 1 && y <= mazeHeight;
    }
}
