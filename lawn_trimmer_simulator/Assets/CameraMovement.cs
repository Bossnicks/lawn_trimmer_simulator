using Assets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    Transform targetPos;
    [SerializeField]
    int sensivity = 3;
    [SerializeField]
    float scrollSpeed = 10f;
    [SerializeField]
    int maxdistance = 8;
    [SerializeField]
    int mindistance = 5;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButton(1) && TaskController.currentState == TaskController.TaskControllerEnum.TrimmerIsInPreparatoryState)
        {
            float y = Input.GetAxis("Mouse X") * sensivity;
            if (y != 0)

            { transform.RotateAround(targetPos.position, Vector3.up, y); }

        }
    }

    bool ControlDistance(float distance)
    {
        if (distance > mindistance && distance < maxdistance) return true;
        return false;
    }
}
