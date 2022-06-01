using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class ShapeData : ScriptableObject
{
    [System.Serializable]
    //Kế thừa : Cha
    public class Row
    {
        public bool[] column;
        private int _size = 0;
        public Row() { }
        //Gọi điểm y = size = false
        public Row(int size)
        {
            CreateRow(size);
        }
        //Gán Điểm y(true/false) = Size (false)
        public void CreateRow(int size)
        {
            _size = size;
            column = new bool[_size];
            ClearRow();
        }
        //Tạo mảng y(true/false) < _size và gán = false
        public void ClearRow()
        {
            for (int i = 0; i < _size; i++)
            {
                column[i] = false;
            }
        }
    }
    //tạo biến hàng ngang, dọc và một mảng bảng(true/false) 
    public int columns = 0;
    public int rows = 0;
    public Row[] board;// bảng
    //Tạo hàng ngang True/false[i] = false = size
    //Tạo điểm X tai đây
    public void Clear()
    {
        for (var i = 0;  i < rows; i++)
        {
            board[i].ClearRow();
        }
    }
    //Tạo hàng ngang và giá trị theo từng Điểm
    public void CreateNewBoard()
    {
        board = new Row[rows];
        for (var i = 0; i < rows; i++)
        {
            board[i] = new Row(columns);
        }
    }
}
