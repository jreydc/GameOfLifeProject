using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    [SerializeField]private int width = 5;
    [SerializeField]private int height = 8;
    [SerializeField]private float tileSize = 1;
    private GridData _gridData;
    private GridAttrib _gridAttrib;
    private CellData _cell;
    Cell[,] grid;
    //private Cell[,] grid = new Cell[width, height];

    private void Start() {
        CellManagement(width, height);
    }
    
    public void CellManagement(int w, int h){
        Cell referenceCell = (Cell)Instantiate(Resources.Load("Prefab/Cell"));
        grid = new Cell[w, h];
        //Setting up Cells
        for(int x = 0; x < h; x++){
            for(int y = 0; y < w; y++){
                Cell cell_instance = Instantiate(referenceCell, transform);
                float posX = h * tileSize;
                float posY = w * -tileSize;

                cell_instance.transform.position = new Vector2(posX, posY);
                cell_instance.SetAlive(RandomAliveCell());
            }
        }
        Destroy(referenceCell);

        Debug.Log(w+"-"+h);
        float gridW = width * tileSize;
        float gridH = height * -tileSize;

        transform.position = new Vector2 (-gridW / 2 + tileSize / 2, gridH / 2 - tileSize / 2);
    }

    private bool RandomAliveCell(){
    int rand = UnityEngine.Random.Range(0, 100);
        if (rand > 75){
            return true;
        }
    return false;
    }
}
