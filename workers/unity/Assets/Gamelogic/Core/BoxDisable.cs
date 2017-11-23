using Improbable;
using Improbable.Core;
using Improbable.Player;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BoxDisable : MonoBehaviour {

	public float m_WaitSeconds;
	public GameObject m_BoxtoDisable;

	private void OnTriggerEnter(Collider other)
	{
		if (other != null && other.gameObject.tag == "Player")
		{
			StartCoroutine(WaitForEnable());
		}
	}

	IEnumerator WaitForEnable()
	{
		m_BoxtoDisable.SetActive(false);
		yield return new WaitForSeconds(m_WaitSeconds);
		m_BoxtoDisable.SetActive(true);

	}

}
