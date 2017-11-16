using Improbable.Unity;
using Improbable.Unity.Visualizer;
using UnityEngine;
using Improbable.Core;
using System.Collections;

namespace Assets.Gamelogic.Target
{
	// Add this MonoBehaviour on UnityWorker (server-side) workers only
	[WorkerType(WorkerPlatform.UnityWorker)]
	public class TargetTouch : MonoBehaviour
	{

		[Require] private Touching.Writer TouchingWriter;

		private void OnTriggerEnter(Collider other)
		{
			if (other != null && other.gameObject.tag == "Dragon")
			{
				int playerid = (int)other.gameObject.EntityId ().Id;
				var TouchUpdate = new Touching.Update ().SetIstouched (playerid);
				TouchingWriter.Send(TouchUpdate);

				Debug.LogWarning("Collision detected with " + gameObject.EntityId());

				StartCoroutine(Waiting());
			}
		}

		IEnumerator Waiting()
		{

			yield return new WaitForSeconds(10);
			var TouchUpdate = new Touching.Update ().SetIstouched (0);
			TouchingWriter.Send(TouchUpdate);

		}
	}

}
