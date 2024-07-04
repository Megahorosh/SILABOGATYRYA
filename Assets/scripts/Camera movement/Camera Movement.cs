using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject camHolder;

    public Transform player; // Ссылка на объект игрока
    public float distance = 2.0f; // Расстояние от камеры до игрока
    public float height = 1.0f; // Высота камеры над игроком
    public float rotationSpeedX = 5.0f; // Скорость вращения камеры
    public float rotationSpeedY = 3.0f; // Скорость вращения камеры

    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float yMinLimit = -20f;
    private float yMaxLimit = 80f;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        currentX = angles.y;
        currentY = angles.x;
    }

    void LateUpdate()
    {
        currentX += Input.GetAxis("Mouse X") * rotationSpeedX;
        currentY -= Input.GetAxis("Mouse Y") * rotationSpeedY;

        currentY = Mathf.Clamp(currentY, yMinLimit, yMaxLimit);


        Quaternion rotationH = Quaternion.Euler(currentY, 0, 0);
        Quaternion rotation = Quaternion.Euler(0, currentX, 0);
        Vector3 position = player.position - (rotationH * Vector3.forward * distance + new Vector3(0, -height, 0));


        transform.rotation = rotation;
        camHolder.transform.rotation = rotationH;
        camHolder.transform.position = position;
    }
}
