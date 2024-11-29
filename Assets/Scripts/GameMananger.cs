using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMananger : MonoBehaviour
{
    public List<GameObject> chekpoints; // Список чекпоинтов
    public int nextchekindex = 0; // Индекс следующего чекпоинта
    public int circles = 0; // Количество пройденных кругов
    public TextMeshProUGUI circlesText;
    public GameObject winScrin;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Chektouch(GameObject chekpoint) // Чекпоинт будет тем обьектом, которого мы коснулись
    {
        if (chekpoint == chekpoints[nextchekindex]) {
            chekpoint.GetComponent<Renderer>().material.color = Color.black;
            nextchekindex++; // Тоже самое что и += 1 тоесть мы увеличиваем индекс на единицу
            Debug.Log(nextchekindex);
        }
    }
      
    public void FinishTouch (GameObject finish )
    {
        if (nextchekindex == chekpoints.Count)
        {
            finish.GetComponent<Renderer>().material.color = Color.yellow;
            circles++; // Добавляет круги
            circlesText.text = "Circles: " + circles.ToString();
            Debug.Log("circles =" + circles);
            ResetChek(finish);
            if (circles >= 3)
            {
                Debug.Log("Вы победили!");
                winScrin.gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
        }
        
    }

    void ResetChek (GameObject finish)
    {
        finish.GetComponent<Renderer>().material.color = new Color32(131, 250, 238, 134);
        nextchekindex = 0;
        foreach (GameObject chekpoint in chekpoints)
        {
            chekpoint.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 134);
        }
    }
}

