using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	[SerializeField] private AudioClip ropeTieringSound;
	[SerializeField] private AudioClip quetionMarkSound;

    private SoundManager() { }

	public static SoundManager Instance { get; private set; }

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Debug.LogError("На сцене больше одного SoundManager");
			Destroy(this);
		}
	}

	public void PlayRopeTieringSound()
	{
		AudioSource.PlayClipAtPoint(ropeTieringSound, Camera.main.transform.position, 1);
	}

	public void PlayQuetionMarkSound()
	{
		AudioSource.PlayClipAtPoint(quetionMarkSound, Camera.main.transform.position, 1);
	}
}
