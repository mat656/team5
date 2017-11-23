using UnityEngine;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using Improbable.Player;
using UnityEngine.UI;
using Improbable.Core;
using System.Collections;

public class TextDisable : MonoBehaviour
{

	public Text wintext;


	void Start()
	{
		StartCoroutine(Waiting());
	}

	IEnumerator Waiting()
	{

		yield return new WaitForSeconds(7);
		wintext.text = "";
	}
}
