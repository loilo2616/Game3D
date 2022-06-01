using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Unity.Collections;

public class Shape : MonoBehaviour
{
    //Block
    public GameObject SquareShaoeImage;

    //sinh Shapeblock
    [HideInInspector]
    public ShapeData CurrentShapeData;

    //Mảng GameObject
    private List<GameObject> _CurrentShape = new List<GameObject>();

    void Start()
    {
        RequestNewShape(CurrentShapeData);
    }
    public void RequestNewShape(ShapeData shapeData)
    {
        CreateShape(shapeData);
    }
    //
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
        //khoảng cách Block
        var squareRect = SquareShaoeImage.GetComponent<Transform>();
        var moveDistance = new Vector2(squareRect.localScale.x * squareRect.localScale.x * 1.14f, squareRect.localScale.y * squareRect.localScale.x * 1.14f);

        int CurrentINdexInlist = 0;

        for(var row  = 0; row < shapeData.rows; row ++)
        {
            for(var column = 0; column < shapeData.columns; column++)
            {
                if(shapeData.board[row].column[column])
                {
                    _CurrentShape[CurrentINdexInlist].SetActive(true);
                    _CurrentShape[CurrentINdexInlist].GetComponent<Transform>().localPosition = new Vector2(GetXPositionForShapeSquare(shapeData, column, moveDistance), 
                    GetYPositionForShapeSquare(shapeData, row, moveDistance));
                   CurrentINdexInlist++;
                }
            }
        }
    }

    //Tạo mảng đa chiều + Ô vuông,check tòa độ x,y 
    #region
    //Gán vị trí điểm X trên tòa độ(x,y)
    private float GetXPositionForShapeSquare(ShapeData shapeData, int column, Vector2 moveDistance)
    {
        float shiftOnX = 0f;
        if (shapeData.columns > 1)
        {
            float startXPos;
            if (shapeData.columns % 2 != 0)
                startXPos = (shapeData.columns / 2) * moveDistance.x * -1;
            else
                startXPos = ((shapeData.columns / 2) - 1) * moveDistance.x * -1 - moveDistance.x / 2;
            shiftOnX = startXPos + column * moveDistance.x;

        }
        return shiftOnX;
    }
    //Gán vị trí điểm y trên tòa độ(x,y)
    private float GetYPositionForShapeSquare(ShapeData shapeData, int row, Vector2 moveDistance)
    {
        float shiftOnY = 0f;
        if (shapeData.rows > 1)
        {
            float startYPos;
            if (shapeData.rows % 2 != 0)
                startYPos = (shapeData.rows / 2) * moveDistance.y;
            else
                startYPos = ((shapeData.rows / 2) - 1) * moveDistance.y + moveDistance.y / 2;
            shiftOnY = startYPos - row * moveDistance.y;
        }
        return shiftOnY;
    }
    //Tạo ô vuông = Board trên tòa độ(x,y)
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
    #endregion
   //// void ClickMouseSprite()
   //// {
   ////     RaycastHit2D Hit = Physics2D.Raycast(transform.position, My_Transform.position, layerMask);
   //// }    
   ////public  void OnSprite()
   ////{

   ////}    
}
