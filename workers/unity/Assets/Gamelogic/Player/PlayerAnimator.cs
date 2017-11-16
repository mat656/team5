using Assets.Gamelogic.Core;
using Assets.Gamelogic.Utils;
using Improbable;
using Improbable.Core;
using Improbable.Player;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

	[Require] private PlayerInput.Reader PlayerInputReader;

	public Animator anim;
	int walk;
	int idle02;
	int run;


	void OnEnable ()
	{
		anim = GetComponent<Animator>();
		idle02 = Animator.StringToHash("Idle02");
		walk = Animator.StringToHash("Walk");
		run = Animator.StringToHash("Run");
	}
		

	void Update ()
	{

		var joystick = PlayerInputReader.Data.joystick;
		Animations (joystick);

	}

	private void Animations(Joystick joystick)
	{
		if (Mathf.Abs (joystick.xAxis) + Mathf.Abs (joystick.yAxis) < 0.1f) {
		anim.Play (idle02);
		} 
		else if ((Mathf.Abs(joystick.xAxis) > 0.1f && (Mathf.Abs(joystick.yAxis) < 0.1f))){
			anim.Play(walk);
		}
		else
			{  
			anim.Play (run);
		}

	}
}
