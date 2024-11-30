using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMove : MonoBehaviour
{
    public List<Transform> botPoints;
    public float speed = 10f;
    public float turnspeed = 5f;
    private int botIndex = 0;


    void Update()
    {
        MoveToNextPoint();
        TurnToNextPoint();
    }

    void MoveToNextPoint()
    {
        if (botIndex < botPoints.Count)
        {
            Transform targetPoint = botPoints[botIndex];
            Vector3 targetPosition = targetPoint.position;
            Vector3 moveFrame = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            transform.position = moveFrame;
            if (transform.position == targetPosition) {
                botIndex++;
                if (botIndex >= botPoints.Count) { 
                botIndex = 0;
                }
            }
        }
    }
    
    void TurnToNextPoint()
    {
        if (botIndex < botPoints.Count)
        {
            Vector3 directionToTarget = botPoints[botIndex].position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnspeed * Time.deltaTime);
        }
    }
}
