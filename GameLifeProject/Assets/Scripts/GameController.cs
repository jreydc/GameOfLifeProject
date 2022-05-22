using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GridSystem _gridManaged;  

    private void Start(){
        _gridManaged.CellManagement();
    }


}
