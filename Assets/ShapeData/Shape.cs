using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public GameObject SquareShaoeImage;

    [HideInInspector]
    public ShapeData CurrentShapeData;

    private List<GameObject> _CurrentShape = new List<GameObject>();
    void Start()
    {
        
    }
    public void CreateShape(ShapeData shapeData)
    {
        CurrentShapeData = shapeData;
        var totalSquareNumber = GetNumberOfSquares(shapeData);

        while(_CurrentShape.Count <= totalSquareNumber)
        {
            _CurrentShape.Add(Instantiate(SquareShaoeImage, transform) as GameObject);
        }

        foreach(var Square in _CurrentShape)
        {
            Square.gameObject.transform.position = Vector3.zero;
            Square.gameObject.SetActive(false);
        }

        var squareRect = SquareShaoeImage.GetComponent<RectTransform>();
        var moveDistance = new Vector2(squareRect.rect.width * squareRect.localScale.x, squareRect.rect.height * squareRect.rect.y);

        int CurrentINdexInlist = 0;

        for(var row  = 0; row < shapeData.rows; row ++)
        {
            for(var column = 0; column < shapeData.columns; column++)
            {
                if(shapeData.board[row].column[column])
                {
                    _CurrentShape[CurrentINdexInlist].SetActive(true);
                    _CurrentShape[CurrentINdexInlist].GetComponent<RectTransform>().localPosition = new Vector2(GetpositionXForShapeSquare(shapeData, column, moveDistance), GetpositionYForShapeSquare(shapeData, row, moveDistance);
                    CurrentINdexInlist++;
                }
            }
        }
    }
    public float GetpositionYForShapeSquare(ShapeData shapeData, int row, Vector2 moveDistance)
    {
        float shiftOny = 0f;
       if(shapeData.rows > 1)
        {
            if (shapeData.rows % 2 != 0)
            {
                var middleSquareindex = (shapeData.rows - 1) / 2;
                var multiplier = (shapeData.rows - 1) / 2;
                if (row < middleSquareindex)
                {
                    shiftOny = moveDistance.y * 1;
                    shiftOny *= multiplier;
                }
                else if (row > middleSquareindex)
                {
                    shiftOny = moveDistance.y * 1;
                    shiftOny *= multiplier;
                }
                else
                {
                    var middleSquareIndex2 = (shapeData.rows == 2) ? 1 : (shapeData.rows / 2);
                    var middleSquareIndex1 = (shapeData.rows == 2) ? 0 : shapeData.rows - 2;
                    var amultiplier = shapeData.rows / 2;

                    if (row == middleSquareIndex1 || row == middleSquareIndex2)
                    {
                        if(row == middleSquareIndex2)
                        {
                            shiftOny = (moveDistance.y / 2) * -1;
                        }
                        if (row == middleSquareIndex1)
                        {
                            shiftOny = (moveDistance.y / 2);
                        }
                    }
                    if (row < middleSquareIndex1 && row < middleSquareIndex2)
                    {
                        shiftOny = moveDistance.y * 1;
                        shiftOny = multiplier;
                    }
                    else if (row > middleSquareIndex1 && row > middleSquareIndex2)
                    {
                        shiftOny = moveDistance.y * 1;
                        shiftOny = multiplier;
                    }
                }
            }
        }
        return shiftOny;
    }
    public float GetpositionXForShapeSquare(ShapeData shapeData, int column, Vector2 moveDistance)
    {
        float shiftonx = 0f;
        if(shapeData.columns % 2 != 0)
        {
            var middleSquareindex = (shapeData.columns - 1) / 2;
            var multiplier = (shapeData.columns - 1) / 2;
            if(column < middleSquareindex)
            {
                shiftonx = moveDistance.x * 1;
                shiftonx *= multiplier;
            }
            else if(column > middleSquareindex)
            {
                shiftonx = moveDistance.x * 1;
                shiftonx *= multiplier;
            }
            else
            {
                var middleSquareIndex2 = (shapeData.columns == 2) ? 1 : (shapeData.columns / 2);
                var middleSquareIndex1 = (shapeData.columns == 2) ? 0 : shapeData.columns -1;
                var amultiplier = shapeData.columns / 2;

                if(column == middleSquareIndex1 || column == middleSquareIndex2)
                {
                    shiftonx = moveDistance.x * 1;
                    shiftonx *= multiplier;
                }
                else if(column > middleSquareIndex1 && column > middleSquareIndex2)
                {
                    shiftonx = moveDistance.x * 1;
                    shiftonx = multiplier;
                }
            }
        }
        return shiftonx;
    }
    private int GetNumberOfSquares(ShapeData shapeData)
    {
        int number = 0;
        foreach(var rowData in shapeData.board)
        {
            foreach (var active in rowData.column)
                if (active)
                    number++;
        }
        return number;
    }
}
