using Assets.Gamelogic.Core;
using Assets.Gamelogic.Utils;
using Improbable;
using Improbable.Core;
using Improbable.Player;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


[WorkerType(WorkerPlatform.UnityWorker)]
public class PlayerMover : MonoBehaviour {

	[Require] private Position.Writer PositionWriter;
	[Require] private Rotation.Writer RotationWriter;
	[Require] private PlayerInput.Reader PlayerInputReader;


	private float m_Speed;

	public int m_PlayerNumber = 1;              
	public float m_TurnSpeed = 180f;  
	public float m_SpeedBoost;
	public int m_WaitSeconds;


	private Rigidbody m_rigidbody;

	void OnEnable ()
	{
		m_rigidbody = GetComponent<Rigidbody>();
		m_Speed = 4;

	}
		
	void FixedUpdate (){
	
		var joystick = PlayerInputReader.Data.joystick;
		float m_Speed1 = m_Speed;
		Move (joystick, m_Speed1);
		Turn (joystick);
	
	}

	private void Move(Joystick joystick, float speed){
		Vector3 movement = transform.forward * joystick.yAxis * speed * Time.deltaTime;
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

	private void OnTriggerEnter(Collider other)
	{
		if (other != null && other.gameObject.tag == "SpeedBox") {

			StartCoroutine(WaitForStopSpeed());

		}

	}

	IEnumerator WaitForStopSpeed()
	{
		m_Speed = m_SpeedBoost * m_Speed;
		yield return new WaitForSeconds(m_WaitSeconds);
		m_Speed = m_Speed / m_SpeedBoost;
	}
		
}