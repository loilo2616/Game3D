using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float X_Start = 2.62f, Y_Start = 2.451f, Ratio;

    [SerializeField] private GameObject EmptyBlock;
    [SerializeField] private Vector2 vector2;
    private string NameBlock;

    public enum StateBlock { };
    public StateBlock State;
    void Start()
    {
        _Container();
    }

    public void _Container()
    {
        for (int i = 0; i < vector2.x; i++)
        {
            for (int j = 0; j < vector2.y; j++)
            {
                GameObject node = Instantiate(EmptyBlock, new Vector2(i * Ratio - X_Start, j * Ratio - Y_Start), Quaternion.identity);
                Debug.Log("(" + i + " : " + j + ")");
            }
        }
    }

}

#region


#endregion
