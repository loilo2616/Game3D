using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.UI;

public class ShapeSquare : MonoBehaviour
{
    //public Image occupiedImage;
    [SerializeField] GameObject My_GameObject;

    private void Awake()
    {
        My_GameObject = GetComponent<GameObject>();
    }
    private void Start()
    {
       // occupiedImage.gameObject.SetActive(false);
        My_GameObject.SetActive(false);
    }
}
