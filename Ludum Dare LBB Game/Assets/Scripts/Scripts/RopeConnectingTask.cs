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

	private List<string> ropeTags;

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
}
