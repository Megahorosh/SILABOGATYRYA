using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f; // Скорость движения персонажа
    private Rigidbody rb;

    public GameObject cam_holder;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Получаем значение по оси X (влево-вправо) и Z (вперёд-назад)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Создаем вектор движения
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Перемещаем персонажа с использованием физики
        rb.MovePosition(transform.position + movement * speed * Time.deltaTime);
    }
}
