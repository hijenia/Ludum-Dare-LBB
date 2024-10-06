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

    public float TimerMax = 12f;
    public float Timer;

    [SerializeField] private GameObject loseWindowUI;
    [SerializeField] private LostWindowUI LostWindowUI;

	private GameManager() { }

    public static GameManager Instance { get; private set; }

    public int CompletedTasksCount { get; set; }

    public float DifficultyMultiplier
    {
        get
        {
            return CompletedTasksCount / 10f + 1f;
        }

        set { }
    }

	public bool IsCompletingTask { get; set; }

	private void Awake()
	{
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("На сцене больше одного GameManager");
            Destroy(this);
        }

        loseWindowUI.SetActive(false);
        CompletedTasksCount = 0;
        IsCompletingTask = false;
    }

	private void Update()
    {
        if (!IsCompletingTask)
        {
            Timer += Time.deltaTime;

            if (Timer >= TimerMax)
            {
                SpawnQuestionMark(QuestionMark);
                Timer = 0;
            } 
        }
    }

    public void HandleLose()
    {
		loseWindowUI.SetActive(true);
        LostWindowUI.UpdateScore();
	}

    private void SpawnQuestionMark(GameObject questionMark)
    {
        int RandomNumber = Random.Range(1, 5);
        Vector3 RandomPosition = Vector2.zero;

        switch (RandomNumber) 
        { 
            case 1:
                RandomPosition = Rope1.transform.position;
                Rope1.GetComponent<RopeAnimation>().ExecuteAnimation();
                break;
            case 2:
                RandomPosition = Rope2.transform.position;
				Rope2.GetComponent<RopeAnimation>().ExecuteAnimation();
				break;
            case 3:
                RandomPosition = Rope3.transform.position;
				Rope3.GetComponent<RopeAnimation>().ExecuteAnimation();
				break;
            case 4:
                RandomPosition = Rope4.transform.position;
				Rope4.GetComponent<RopeAnimation>().ExecuteAnimation();
				break; 
        }

        Instantiate(questionMark, RandomPosition, Quaternion.identity);
    }    
}
