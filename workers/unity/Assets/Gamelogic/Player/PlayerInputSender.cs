using UnityEngine;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using Improbable.Player;

[WorkerType(WorkerPlatform.UnityClient)]
public class PlayerInputSender : MonoBehaviour
{

	[Require] private PlayerInput.Writer PlayerInputWriter;
	bool isdead;
	Muori muori;

	void OnEnable(){

		muori = gameObject.GetComponent<Muori>();
		isdead = false;
	
	}

	void Update (){

		isdead = muori.IsDied ();

		if (!isdead) {
			InputSender ();
		}
	}
		
	 private void InputSender(){
		
		var xAxis = Input.GetAxis("Horizontal");
		var yAxis = Input.GetAxis("Vertical");

		var update = new PlayerInput.Update();
		update.SetJoystick(new Joystick(xAxis, yAxis));
		PlayerInputWriter.Send(update);

		if (Input.GetKeyDown (KeyCode.Space)) {
			PlayerInputWriter.Send (new PlayerInput.Update ().AddFire (new Fire ()));
	
		}

  	}
}
