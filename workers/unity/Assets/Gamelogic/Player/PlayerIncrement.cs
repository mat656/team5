using UnityEngine;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using Improbable.Player;
using UnityEngine.UI;
using Improbable.Core;

[WorkerType(WorkerPlatform.UnityClient)]
public class PlayerIncrement : MonoBehaviour {

	private PlayersCounter counter; 
	private Winner winner;

	bool firsttime = true;
	Muori muori;

	// Use this for initialization
	void Start () {

		counter = GameObject.FindGameObjectWithTag ("WinText").GetComponent<PlayersCounter>();
		counter.SetPlayerCount(1);

	}


}

