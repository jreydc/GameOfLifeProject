using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private static int SCREEN_WIDTH = 64;
    private static int SCREEN_HEIGHT = 48;
    // Start is called before the first frame update
    Cell[,] grid = new Cell[SCREEN_WIDTH, SCREEN_HEIGHT];

    void Start()
    {  
        PlaceCells();
    }

   void Update() {
        CountNeighbours();
    }

    private void PlaceCells(){
        Cell cell_instance;
        //Setting up Cells
        for(int y = 0; y < SCREEN_HEIGHT; y++){
            for(int x = 0; x < SCREEN_WIDTH; x++){
                cell_instance = Instantiate(Resources.Load("Prefab/Cell", typeof(Cell)), new Vector2(x, y), Quaternion.identity) as Cell;
                grid[x, y] = cell_instance;
                cell_instance.SetAlive(RandomAliveCell());
                Debug.Log(RandomAliveCell());
            }
        }
    }

    private void CountNeighbours(){
        for(int y = 0; y < SCREEN_HEIGHT; y++){
            for(int x = 0; x < SCREEN_WIDTH; x++){
                int numNeighbours = 0;
                //North
                if (y + 1 < SCREEN_HEIGHT){
                    if(grid[x,y + 1].IsAlive){
                        numNeighbours++;
                    }
                }
                //East
                if(x+1 < SCREEN_WIDTH){
                    if(grid[x+1, y].IsAlive){
                        numNeighbours++;
                    }
                }
                //South
                if (y-1 >= 0){
                    if(grid[x,y-1].IsAlive){
                        numNeighbours++;
                    }
                }
                //West
                if(x-1 >= 0){
                    if(grid[x-1, y].IsAlive){
                        numNeighbours++;
                    }
                }
                //NorthEast
                if(x + 1 < SCREEN_WIDTH && y + 1 < SCREEN_HEIGHT){
                    if(grid[x-1, y+1]){
                        numNeighbours++;
                    }    
                }

                //NorthWest
                if(x - 1 >= 0 && y + 1 < SCREEN_HEIGHT){
                    if(grid[x-1, y+1]){
                        numNeighbours++;
                    }    
                }
                //SouthEast
                if(x + 1 < SCREEN_WIDTH && y - 1 >= 0){
                    if(grid[x+1, y-1].IsAlive){
                        numNeighbours++;
                    }
                }

                //SouthWest
                if(x - 1 >= 0 && y - 1 >= 0){
                    if(grid[x-1, y-1].IsAlive){
                        numNeighbours++;
                    }    
                } 

                grid[x, y].numNeighbours = numNeighbours;
            }
        }
    }

    private bool RandomAliveCell(){
        int rand = UnityEngine.Random.Range(0, 100);
        if (rand > 75){
            return true;
        }

        return false;
    }

    /* private int ComputingNeighbours(int x, int y){
        Cell[,] gridNeighbours = new Cell[x,y];
        int sum = 0;
        for(int i = -1; i < x; i++){
            for(int j = -1; j < y; j++){
                if (gridNeighbours[i][j].isAlive){
                    sum++;
                }
            }
        }

        return sum;
    } */
}
