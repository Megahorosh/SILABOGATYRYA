using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f; // �������� �������� ���������
    private Rigidbody rb;

    public GameObject cam_holder;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // �������� �������� �� ��� X (�����-������) � Z (�����-�����)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // ������� ������ ��������
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // ���������� ��������� � �������������� ������
        rb.MovePosition(transform.position + movement * speed * Time.deltaTime);
    }
}
