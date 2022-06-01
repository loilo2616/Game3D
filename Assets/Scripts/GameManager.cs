using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private LayerMask layerMask;
    private Transform My_Transform;
    //Controll All Mouse 
    public enum StateMouse { ClickMouse, DrawMouse, ReleaseMouse }
    public StateMouse State;

    public float X_Start = 2.62f, Y_Start = 2.451f, Ratio;

    [SerializeField] private GameObject EmptyBlock;
    [SerializeField] private Vector2 vector2;
    private string NameBlock;
    void Start()
    {
        _Container();
        _InputMouse ();
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
    //Bắn raycart và gán tòa độ 
    Vector3 offset;
    public GameObject selectedObject;
    private void _InputMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject)
            {
                selectedObject = targetObject.transform.gameObject;
                offset = selectedObject.transform.position - mousePosition;
                Debug.Log(offset);
            }
        }
        if (selectedObject)
        {
            selectedObject.transform.position = mousePosition + offset;
        }
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            selectedObject = null;

        }
    }
}
