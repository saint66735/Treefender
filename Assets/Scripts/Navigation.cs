using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;
using UnityTemplateProjects;

public class Navigation : MonoBehaviour
{
    [SerializeField] private GameObject treeRoot;
    [SerializeField] private GameObject rootEnd;
    [SerializeField] private GameObject turnLeft;
    [SerializeField] private GameObject turnRight;

    private Vector3 _currentPosition;
    private GameObject _currentObject;

    private void Start()
    {
        _currentPosition = new Vector3(0.5f, -0.5f, 0);
        _currentObject = Instantiate(rootEnd, _currentPosition, Quaternion.identity);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100))
            {
                GameObject clickedObject = hit.transform.GameObject();
                Vector3 newPosition = clickedObject.transform.position;

                if (MinePower.CanMine() && !clickedObject.CompareTag("Root") && Vector3.Distance(_currentPosition, newPosition) == 1)
                {   
                    MinePower.Mine();
                    clickedObject.GetComponent<Value>().Liquidate();
                    Destroy(clickedObject);
                    Destroy(_currentObject);
                    Instantiate(treeRoot, _currentPosition, Quaternion.identity);
                    _currentPosition = newPosition;
                    _currentObject = Instantiate(rootEnd, _currentPosition, Quaternion.identity);
                    /*Debug.Log(Currency.GetCurrency());*/
                }
            }
        }
    }
}
