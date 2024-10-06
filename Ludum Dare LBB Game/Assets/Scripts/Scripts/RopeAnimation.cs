using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeAnimation : MonoBehaviour
{
	[SerializeField] private Animator animator;

	private const string IS_TIERING = "isTiering";

	public void ExecuteAnimation()
	{
		animator.SetTrigger(IS_TIERING);
		SoundManager.Instance.PlayRopeTieringSound();
	}
}
