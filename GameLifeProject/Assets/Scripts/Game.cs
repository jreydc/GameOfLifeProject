using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private static int SCREEN_WIDTH;
    private static int SCREEN_HEIGHT;
    // Start is called before the first frame update
    Cell[,] grid = new Cell[SCREEN_WIDTH, SCREEN_HEIGHT];

    void Start()
    {
        SCREEN_WIDTH = 64;
        SCREEN_HEIGHT = 48;

        PlaceCells();
    }

    void PlaceCells(){
        for(int y = 0; y < SCREEN_HEIGHT; y++){
            for(int x = 0; x < SCREEN_WIDTH; x++){
                Cell cell_instance = Instantiate(Resources.Load("Prefavs/Cell", typeof(Cell)), new Vector2(x, y), Quaternion.identity) as Cell;
            }
        }
    }    
}
