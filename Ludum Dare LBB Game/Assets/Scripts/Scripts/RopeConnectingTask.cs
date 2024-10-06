using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeConnectingTask : Task
{
	[SerializeField] private List<SpriteRenderer> ropePositionList;

	[SerializeField] private Color redColor;
	[SerializeField] private Color greenColor;
	[SerializeField] private Color blueColor;
	[SerializeField] private Color yellowColor;

	[SerializeField] private float taskTime;

	private List<string> ropeTags;

	private int connectedRopes = 0;

	private void Awake()
	{
		ropeTags = new List<string>
		{
			"RopeRed",
			"RopeGreen",
			"RopeBlue",
			"RopeYellow"
		};
	}

	private void Start()
	{
		GameManager.Instance.IsCompletingTask = true;

		for (int i = 0; i < ropePositionList.Count; i++)
		{
			int randomNumber = Random.Range(0, ropeTags.Count);

			ropePositionList[i].gameObject.tag = ropeTags[randomNumber];
			ropeTags.Remove(ropeTags[randomNumber]);

			switch (ropePositionList[i].gameObject.tag)
			{
				case "RopeRed":
					ropePositionList[i].color = redColor;
					break;
				case "RopeGreen":
					ropePositionList[i].color = greenColor;
					break;
				case "RopeBlue":
					ropePositionList[i].color = blueColor;
					break;
				case "RopeYellow":
					ropePositionList[i].color = yellowColor;
					break;
			}
		}
	}

	public override float GetTaskTime()
	{
		return taskTime;
	}

	public void UpdateConnectedRopesScore()
	{
		connectedRopes++;

		if (connectedRopes >= 4)
		{
			CompleteTask();
		}
	}

	private void CompleteTask()
	{
		GameManager.Instance.CompletedTasksCount++;
		GameManager.Instance.IsCompletingTask = false;
		Destroy(gameObject);
	}
}
