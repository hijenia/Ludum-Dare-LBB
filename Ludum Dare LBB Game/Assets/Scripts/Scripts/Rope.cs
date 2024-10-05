using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
	[SerializeField] private Transform ropeStartPoint;
	[SerializeField] private SpriteRenderer ropeEnd;

	private void Start()
	{
		ropeStartPoint.position = transform.position;
	}

	private void OnMouseDrag()
	{
		Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		newPosition.z = 0;

		transform.position = newPosition;

		Vector3 direction = newPosition - ropeStartPoint.position;

		float dist = Vector2.Distance(ropeStartPoint.position, newPosition);
	}
}
