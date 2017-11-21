using Assets.Gamelogic.Utils;
using Improbable;
using Improbable.Core;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using UnityEngine;

[WorkerType(WorkerPlatform.UnityWorker)]
public class TargetTransformSender : MonoBehaviour
{

	[Require] private Position.Writer PositionWriter;
	[Require] private Rotation.Writer RotationWriter;

	void FixedUpdate ()
	{
		var pos = transform.position;
		var positionUpdate = new Position.Update()
			.SetCoords(new Coordinates(pos.x, pos.y, pos.z));
		PositionWriter.Send(positionUpdate);

		transform.eulerAngles= new Vector3(0, transform.rotation.eulerAngles.y,0);
		var rotationUpdate = new Rotation.Update()
			.SetRotation(MathUtils.ToNativeQuaternion(transform.rotation));
		RotationWriter.Send(rotationUpdate);
	}
}
