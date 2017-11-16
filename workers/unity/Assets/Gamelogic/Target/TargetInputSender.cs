using UnityEngine;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using Improbable.Core;

[WorkerType(WorkerPlatform.UnityWorker)]
public class TargetInputSender : MonoBehaviour
{

	[Require] private TargetInput.Writer PlayerInputWriter;



	private void OnEnable()
	{
		// Change steering decisions every five seconds
		InvokeRepeating("RandomizeMoving", 0, 0.7f);
	}

	private void OnDisable()
	{
		CancelInvoke("RandomizeMoving");
	}


	void RandomizeMoving ()
	{
		var xAxis = Random.Range (-1.0f, 1.0f);
		var yAxis = Random.Range (0f, 1.0f);

		var update = new TargetInput.Update();
		update.SetCommands(new Commands(xAxis, yAxis));
		PlayerInputWriter.Send(update);
	}
}