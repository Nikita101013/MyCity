using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public int apples; // public это модификатор доступа, он делает эту переменную доступным в инспекторе и из других скриптов
    private float scale = 10.5f; // private делает переменную доступным только внутри этого скрипта
    private bool isAcctive = true; //bool это логический тип данных, принимает значение true или false
    public float speed = 0f;
    public float horizontal;
    public float vertical;
    public float rotationSpeed = 50f;
    public float acceleration = 20f;// Ускорение
    public float deceleration = 10f;// Замедление
    public float maxrevercespeed = -20f; // Максимальная скорость передвижения назад
    public float maxspeed = 30f;// Максимальная скорость вперёд
    public GameMananger gameMananger;
    void Start()
    {
        apples += 10;
        Debug.Log("У нас в корзине" + apples + "яблок");
        // Debug.Log("Привет из метода старт");
        if (isAcctive == false)
        {
            scale *= 2;
            Debug.Log("Размер корзины стал" + scale);
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            apples += 1;
            Debug.Log("Теперь у нас" + apples);
        }
        // Debug.Log("Привет из метода апдейт");
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
        vertical = Input.GetAxis("Vertical"); // Вертикальная ось вверх и вниз,или стрелки на клавиатуре или клавиша W и S
                                              // Принимает значение от -1 до 1 если ничего не нажато, то равно 0
        horizontal = Input.GetAxis("Horizontal"); // Горизонтальная ось вправо или влево, или на стрелки или на клавиши A и D
                                                  // Принимает значение от -1 до 1 если ничего не нажато, то равно 0
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
        transform.Translate(Vector3.forward * speed * vertical * Time.deltaTime);// Двигаем обьект вперёд и назад
        transform.Rotate(Vector3.up * horizontal * rotationSpeed * Time.deltaTime);// Поворачиваем обьект влево и вправо

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chek"))
        {
            gameMananger.Chektouch(other.gameObject); // Вызываем функцию Chektouch из другого скрипта
            Debug.Log("ChekPoint");


        }

        if (other.CompareTag("Finish"))
        {
            gameMananger.FinishTouch(other.gameObject); // Вызываем функцию Chektouch из другого скрипта
            Debug.Log("Finish");

        }
    }
}
