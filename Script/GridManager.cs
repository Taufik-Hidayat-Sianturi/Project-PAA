using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    private int rows = 25;
    [SerializeField]
    private int cols = 25;
    [SerializeField]
    private float tileSize = 1 ;
 
    void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        GameObject referenceTile = (GameObject)Instantiate(Resources.Load("Tiles")); 
        for (int row = 0; row < rows; row++) 
        {
            for (int col = 0; col < cols; col++) 
            {
                GameObject tile = (GameObject)Instantiate(referenceTile, transform);

                float posX = col * tileSize;    
                float posY = row * -tileSize;

                 tile.transform.position = new Vector2(posX, posY);

                
            
            }

        
        }
        
        Destroy(referenceTile );
        float gridW = cols * tileSize;
        float gridH = rows * -tileSize;
        transform.position = new Vector2(-gridW / 100 + tileSize / 100, gridH / 100 - tileSize / 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
