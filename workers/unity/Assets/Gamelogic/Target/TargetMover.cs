using Assets.Gamelogic.Core;
using Assets.Gamelogic.Utils;
using Improbable;
using Improbable.Core;
using Improbable.Player;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using UnityEngine;

[WorkerType(WorkerPlatform.UnityWorker)]
public class TargetMover : MonoBehaviour {

	[Require] private Position.Writer PositionWriter;
	[Require] private Rotation.Writer RotationWriter;
	[Require] private TargetInput.Reader TargetInputReader;

	      
	public float m_Speed;            
	public float m_TurnSpeed;  

	private Rigidbody m_rigidbody;

	void OnEnable ()
	{
		m_rigidbody = GetComponent<Rigidbody>();

	}

	void FixedUpdate (){

		var commands = TargetInputReader.Data.commands;

		Move (commands);
		Turn (commands);
	}

	private void Move(Commands commands){
		Vector3 movement = transform.forward * commands.yAxis * m_Speed * Time.deltaTime;
		movement.y = 0;
		m_rigidbody.MovePosition (m_rigidbody.position + movement);

		//Update the entity's position
		/*var pos = m_rigidbody.position;
		var positionUpdate = new Position.Update()
			.SetCoords(new Coordinates(pos.x, pos.y, pos.z));
		PositionWriter.Send(positionUpdate);*/
	}

	private void Turn(Commands commands){

		float turn = commands.xAxis * m_TurnSpeed * Time.deltaTime;
		UnityEngine.Quaternion turnrotation = UnityEngine.Quaternion.Euler (0f, turn, 0f);
		m_rigidbody.MoveRotation (m_rigidbody.rotation * turnrotation);

		//Update the entity's position
		/*var rotationUpdate = new Rotation.Update()
			.SetRotation(m_rigidbody.rotation.ToNativeQuaternion());
		RotationWriter.Send(rotationUpdate);*/


	}

}
