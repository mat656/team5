using Assets.Gamelogic.Core;
using Assets.Gamelogic.Utils;
using Improbable;
using Improbable.Core;
using Improbable.Player;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using UnityEngine;
using UnityEngine.UI;


[WorkerType(WorkerPlatform.UnityWorker)]
public class PlayerMover : MonoBehaviour {

	[Require] private Position.Writer PositionWriter;
	[Require] private Rotation.Writer RotationWriter;
	[Require] private PlayerInput.Reader PlayerInputReader;



	public int m_PlayerNumber = 1;         
	public float m_Speed = 12f;            
	public float m_TurnSpeed = 180f;  

	private Rigidbody m_rigidbody;

	void OnEnable ()
	{
		m_rigidbody = GetComponent<Rigidbody>();

	}
		
	void FixedUpdate (){
	
		var joystick = PlayerInputReader.Data.joystick;

		Move (joystick);
		Turn (joystick);

	
	}

	private void Move(Joystick joystick){
		Vector3 movement = transform.forward * joystick.yAxis * m_Speed * Time.deltaTime;
		movement.y = 0;
		m_rigidbody.MovePosition (m_rigidbody.position + movement);

		//Update the entity's position
		/*var pos = m_rigidbody.position;
		var positionUpdate = new Position.Update()
			.SetCoords(new Coordinates(pos.x, pos.y, pos.z));
		PositionWriter.Send(positionUpdate);*/
	}

	private void Turn(Joystick joystick){

		float turn = joystick.xAxis * m_TurnSpeed * Time.deltaTime;
		UnityEngine.Quaternion turnrotation = UnityEngine.Quaternion.Euler (0f, turn, 0f);
		m_rigidbody.MoveRotation (m_rigidbody.rotation * turnrotation);

		//Update the entity's position
		/*var rotationUpdate = new Rotation.Update()
			.SetRotation(m_rigidbody.rotation.ToNativeQuaternion());
		RotationWriter.Send(rotationUpdate);*/

	}
		
}