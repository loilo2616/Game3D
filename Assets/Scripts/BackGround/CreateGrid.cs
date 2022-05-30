using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrid : MonoBehaviour
{
    public int columns = 0;
    public int rows = 0;
    public float squaresGap = 0.1f;
    public GameObject GridSquare;
    public Vector2 StartPosition = new Vector2(0.0f, 0.0f);
    public float SquareScale = 0.5f;
    public float EverySquareOffSet = 0.0f;

    private Vector2 _OffSet = new Vector2(0.0f, 0.0f);
    private List<GameObject> _gridSquares = new List<GameObject>();
    void Start()
    {
        _CreateGrid();
    }

    private void _CreateGrid()
    {
        SpawnGirdSquares();
        SetGridSquaresPosition();
    }    
    void SpawnGirdSquares()
    {
        int Square_index = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                _gridSquares.Add(Instantiate(GridSquare) as GameObject);
                _gridSquares[_gridSquares.Count - 1].transform.SetParent(this.transform);
                _gridSquares[_gridSquares.Count - 1].transform.localScale = new Vector3(SquareScale, SquareScale, SquareScale);

            }
        }
    }
    void SetGridSquaresPosition()
    {

    }
}
