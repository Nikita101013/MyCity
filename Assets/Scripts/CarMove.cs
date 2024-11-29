using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public int apples; // public ��� ����������� �������, �� ������ ��� ���������� ��������� � ���������� � �� ������ ��������
    private float scale = 10.5f; // private ������ ���������� ��������� ������ ������ ����� �������
    private bool isAcctive = true; //bool ��� ���������� ��� ������, ��������� �������� true ��� false
    public float speed = 0f;
    public float horizontal;
    public float vertical;
    public float rotationSpeed = 50f;
    public float acceleration = 20f;// ���������
    public float deceleration = 10f;// ����������
    public float maxrevercespeed = -20f; // ������������ �������� ������������ �����
    public float maxspeed = 30f;// ������������ �������� �����
    public GameMananger gameMananger;
    void Start()
    {
        apples += 10;
        Debug.Log("� ��� � �������" + apples + "�����");
        // Debug.Log("������ �� ������ �����");
        if (isAcctive == false)
        {
            scale *= 2;
            Debug.Log("������ ������� ����" + scale);
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            apples += 1;
            Debug.Log("������ � ���" + apples);
        }
        // Debug.Log("������ �� ������ ������");
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.Translate(Vector3.forward * speed * Time.deltaTime );

        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.Translate(Vector3.back * speed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Translate(Vector3.right * speed * Time.deltaTime);

        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Translate(Vector3.left * speed * Time.deltaTime);
        //}
        vertical = Input.GetAxis("Vertical"); // ������������ ��� ����� � ����,��� ������� �� ���������� ��� ������� W � S
                                              // ��������� �������� �� -1 �� 1 ���� ������ �� ������, �� ����� 0
        horizontal = Input.GetAxis("Horizontal"); // �������������� ��� ������ ��� �����, ��� �� ������� ��� �� ������� A � D
                                                  // ��������� �������� �� -1 �� 1 ���� ������ �� ������, �� ����� 0
        if (vertical > 0)
        {
            speed = Mathf.MoveTowards(speed, maxspeed, acceleration * Time.deltaTime);
        }
        else if (vertical < 0)
        {
            speed = Mathf.MoveTowards(speed, maxrevercespeed, acceleration * Time.deltaTime);
        }
        else
        {
            speed = Mathf.MoveTowards(speed, 0, deceleration * Time.deltaTime);
        }
        transform.Translate(Vector3.forward * speed * vertical * Time.deltaTime);// ������� ������ ����� � �����
        transform.Rotate(Vector3.up * horizontal * rotationSpeed * Time.deltaTime);// ������������ ������ ����� � ������

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chek"))
        {
            gameMananger.Chektouch(other.gameObject); // �������� ������� Chektouch �� ������� �������
            Debug.Log("ChekPoint");


        }

        if (other.CompareTag("Finish"))
        {
            gameMananger.FinishTouch(other.gameObject); // �������� ������� Chektouch �� ������� �������
            Debug.Log("Finish");

        }
    }
}
