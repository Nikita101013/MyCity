using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMananger : MonoBehaviour
{
    public List<GameObject> chekpoints; // ������ ����������
    public int nextchekindex = 0; // ������ ���������� ���������
    public int circles = 0; // ���������� ���������� ������
    public TextMeshProUGUI circlesText;
    public GameObject winScrin;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Chektouch(GameObject chekpoint) // �������� ����� ��� ��������, �������� �� ���������
    {
        if (chekpoint == chekpoints[nextchekindex]) {
            chekpoint.GetComponent<Renderer>().material.color = Color.black;
            nextchekindex++; // ���� ����� ��� � += 1 ������ �� ����������� ������ �� �������
            Debug.Log(nextchekindex);
        }
    }
      
    public void FinishTouch (GameObject finish )
    {
        if (nextchekindex == chekpoints.Count)
        {
            finish.GetComponent<Renderer>().material.color = Color.yellow;
            circles++; // ��������� �����
            circlesText.text = "Circles: " + circles.ToString();
            Debug.Log("circles =" + circles);
            ResetChek(finish);
            if (circles >= 3)
            {
                Debug.Log("�� ��������!");
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

