using UnityEngine;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using Improbable.Player;
using UnityEngine.UI;
using Improbable.Core;

public class WinnerDisplayer : MonoBehaviour
{

	[Require] private Touching.Reader TouchingReader;

	public Text wintext;
	public GameObject win;

	void OnEnable ()
	{
		win = GameObject.FindGameObjectWithTag ("WinText");
		wintext = win.GetComponent<Text>();
 		wintext.text = "";
	
	}

	void Update()
	{
		var playertouched = TouchingReader.Data;
		Win (playertouched);

	}

	private void Win(TouchingData playertouched){

		if (playertouched.istouched != 0) {
			wintext.text = "Player" + playertouched.istouched.ToString () + " WIN!";
		} 
		else {
			wintext.text = "";
		}


	}
}
