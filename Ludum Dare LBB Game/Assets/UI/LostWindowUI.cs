using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LostWindowUI : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI scoreText;
	[SerializeField] private Button restartButton;
	[SerializeField] private Button menuButton;

	private void Start()
	{
		restartButton.onClick.AddListener(() =>
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		});

		menuButton.onClick.AddListener(() =>
		{
			SceneManager.LoadScene(0);
		});
	}

	public void UpdateScore()
	{
		scoreText.text = "You tied back " + GameManager.Instance.completedTasksCount + " ropes!";
	}
}
