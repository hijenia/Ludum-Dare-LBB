using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Labirint : Task
{
    public Transform playerLab;

    [SerializeField] private AudioClip taskCompletedSound;
    [SerializeField] private float taskTime;

	private Vector3 offset;

    void Start()
    {
        offset = playerLab.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

        GameManager.Instance.IsCompletingTask = true;
    }

	public override float GetTaskTime()
	{
		return taskTime;
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

    public void PlayTaskCompletedSound()
    {
        AudioSource.PlayClipAtPoint(taskCompletedSound, Camera.main.transform.position, 1);
    }
    private void CompleteTask()
	{
		GameManager.Instance.CompletedTasksCount++;
        GameManager.Instance.IsCompletingTask = false;
        Destroy(gameObject.transform.parent.gameObject);
        PlayTaskCompletedSound();
    }
}
