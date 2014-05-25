using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : SingletonMonoBehaviour<GameController> {

	void Start()
	{
		MonoBehaviour.DontDestroyOnLoad(gameObject);
	}

	public int score {get; set;}

	public Queue<int> oldScoreQueue = new Queue<int>();
	public const int max = 5;

	public void UpdateScore()
	{
		if( oldScoreQueue.Count > max)
		{
			oldScoreQueue.Dequeue();
		}

		oldScoreQueue.Enqueue(score);
	}
}