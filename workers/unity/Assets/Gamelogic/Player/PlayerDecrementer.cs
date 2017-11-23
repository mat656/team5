using UnityEngine;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using Improbable.Player;
using UnityEngine.UI;
using Improbable.Core;

[WorkerType(WorkerPlatform.UnityClient)]
public class PlayerDecrement : MonoBehaviour {

	[Require] private Health.Reader HealthReader;

	private PlayersCounter counter; 
	private Winner winner;

	// Use this for initialization
	void OnEnable () {

		counter = GameObject.FindGameObjectWithTag ("WinText").GetComponent<PlayersCounter>();
		HealthReader.CurrentHealthUpdated.Add(OnCurrentHealthUpdated);
	}

	private void OnCurrentHealthUpdated(int currentHealth)
	{
		if (currentHealth <= 0) {
			
			counter.SetPlayerCount (-1);
		}
	}

}
