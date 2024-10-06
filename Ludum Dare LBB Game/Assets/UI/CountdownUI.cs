using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountdownUI : MonoBehaviour
{
	[SerializeField] private Task task;
	[SerializeField] private TextMeshProUGUI coundownText;

	private void Start()
	{
		StartCoroutine(StartCountdown());
	}

	private IEnumerator StartCountdown()
	{
		float timer = task.GetTaskTime() / GameManager.Instance.DifficultyMultiplier;

		while (true)
		{
			timer -= Time.deltaTime;
			Debug.Log(timer);

			if (timer > 0f)
			{
				coundownText.text = timer.ToString("F2");

				yield return null;
			}
			else
			{
				coundownText.text = "0,00";
				break;
			}
		}

		GameManager.Instance.HandleLose();
		Destroy(gameObject.transform.parent.gameObject);
	}
}
