using UnityEngine;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using Improbable.Player;
using UnityEngine.UI;
using Improbable.Core;
using System.Collections.Generic;


[WorkerType(WorkerPlatform.UnityClient)]

public class Winner : MonoBehaviour {

	[Require] private PlayerInput.Writer PlayerInputWriter;

	PlayersCounter counter;
	private int m_PlayersCount=0;
	private bool firstconnected=false;
	bool firsttime = true;


	bool isdead;


	void OnEnable(){

		counter = gameObject.GetComponent<PlayersCounter> ();
		isdead = false;
		
	}

	void Update () {
		m_PlayersCount = counter.GetPlayerCount();

		if(m_PlayersCount == 0)
			firstconnected=true;
		if(m_PlayersCount == 1 && firstconnected == true)
			return;
		else if(m_PlayersCount>1)
			firstconnected=false;
		else if(m_PlayersCount==1 && firstconnected==false){
			 Text wintext = gameObject.GetComponent<Text> ();
			 wintext.text = "You Win!";	
		}



		if (isdead && firsttime)
		{
			Text losetext = gameObject.GetComponent<Text> ();
			firsttime = false;
			losetext.text = "You Lose!";
		}
	}

	public void SetIsDead(){
	
		isdead = true;
	
	}
		
}