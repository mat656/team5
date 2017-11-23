using UnityEngine;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using Improbable.Player;
using UnityEngine.UI;
using Improbable.Core;
using System.Collections.Generic;


[WorkerType(WorkerPlatform.UnityClient)]

public class PlayersCounter : MonoBehaviour {


	private int m_PlayersCount=0;

	public int GetPlayerCount(){

		return m_PlayersCount;
	}

	public void SetPlayerCount(int increment){

		m_PlayersCount += increment;

	}
}
