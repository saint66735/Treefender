using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 5;
    public Vector2 limits;
    float inputVal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputVal = Input.GetAxisRaw("Vertical");
        float move = inputVal * speed * Time.deltaTime;
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y + move, transform.position.z);
        if(newPos.y>limits.x)
        {
            newPos.y = limits.x;
        }
        else if (newPos.y < limits.y)
        {
            newPos.y = limits.y;
        }
        transform.position = newPos;
    }
}
