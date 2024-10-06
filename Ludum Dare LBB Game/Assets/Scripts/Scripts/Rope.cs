using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
	[SerializeField] private Transform ropeStartPoint;
	[SerializeField] private SpriteRenderer ropeSpriteRenderer;
	[SerializeField] private SpriteRenderer ropeEnd;
	[SerializeField] private LayerMask layerMask;
	[SerializeField] private RopeConnectingTask ropeConnectingTask;

	private bool isDone = false;
	
	private void Start()
	{
		ropeStartPoint.position = transform.position;
		ropeEnd.size = new Vector2(0f, ropeEnd.size.y);
	}

	private void OnMouseDrag()
	{
		if (!isDone)
		{
			Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			newPosition.z = 0;

			Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, 1f, layerMask);
			foreach (Collider2D collider in colliders)
			{
				UpdateRope(collider.transform.position);

				if (transform.tag == collider.tag)
				{
					UpdateRope(collider.transform.position);
					Done();
					return;
				}
				
				return;
			}

			UpdateRope(newPosition); 
		}
	}

	private void OnMouseUp()
	{
		if (!isDone)
		{
			UpdateRope(ropeStartPoint.position); 
		}
	}

	private void UpdateRope(Vector3 newPosition)
	{
		transform.position = newPosition;

		Vector3 direction = newPosition - ropeStartPoint.position;
		transform.right = direction;

		//0.4 це розмір нитки, мені лень роботи її як окреме поле класса так шо похуй
		float dist = Vector2.Distance(ropeStartPoint.position, newPosition);
		ropeEnd.size = new Vector2(dist / 0.8f, ropeEnd.size.y);
	}

	private void Done()
	{
		isDone = true;

		ropeConnectingTask.UpdateConnectedRopesScore();
	}
}
