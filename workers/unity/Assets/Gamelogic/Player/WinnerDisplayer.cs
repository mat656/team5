using UnityEngine.UI;
using Improbable.Player;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using UnityEngine;
using Improbable.Worker;
using Improbable;

[WorkerType(WorkerPlatform.UnityClient)]

public class WinnerDisplayer : MonoBehaviour {

	[Require] private PlayerInput.Writer PlayerInputWriter;

	private PlayersCounter counter;
	private int playersCount;
	private Text winText;

	void OnEnable () {

		winText = GameObject.FindGameObjectWithTag ("WinText").GetComponent<Text> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		playersCount = counter.GetPlayerCount();

		if (playersCount == 1) {
			winText.text = "YOU WIN!";	
		}
	}

}
