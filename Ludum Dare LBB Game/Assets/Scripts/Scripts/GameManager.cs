using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject QuestionMark;
    public GameObject Rope1;
    public GameObject Rope2;
    public GameObject Rope3;
    public GameObject Rope4;

    public float TimerMax;
    public float Timer; 

    public void SpawnQuestionMark(GameObject questionMark)
    {
        int RandomNumber = Random.Range(1, 4);
        Vector3 RandomPosition = Vector2.zero;
        switch (RandomNumber) 
        { 
            case 1:
            RandomPosition = Rope1.transform.position;
            break;
        case 2:
            RandomPosition = Rope2.transform.position;
            break;
        case 3:
            RandomPosition = Rope3.transform.position;
            break;
        case 4:
            RandomPosition = Rope4.transform.position;
            break; 
        }
        Instantiate(questionMark, RandomPosition, Quaternion.identity);
    }   

    
    void Start()
    {
        
    }


    void Update()
    {
        Timer += Time.deltaTime;
        if(Timer >= TimerMax)
        {
            SpawnQuestionMark(QuestionMark);
            Timer = 0;
        }
    }
}
