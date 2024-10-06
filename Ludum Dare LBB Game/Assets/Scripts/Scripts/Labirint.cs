using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Labirint : MonoBehaviour
{
    public Transform playerLab;
    private Vector3 offset;

    void Start()
    {
        offset = playerLab.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseDrag()
    {
        Vector3 mousePozition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePozition.z = 0;
        playerLab.position = mousePozition;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            GameManager.Instance.HandleLose();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
			GameManager.Instance.HandleLose();
		}
        else if (other.CompareTag("Finish"))
        {
            CompleteTask();
        }
    }

    private void CompleteTask()
	{
		GameManager.Instance.completedTasksCount++;
        Destroy(gameObject.transform.parent.gameObject);
	}
}
