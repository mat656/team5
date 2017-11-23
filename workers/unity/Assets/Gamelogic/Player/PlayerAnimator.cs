using Assets.Gamelogic.Core;
using Assets.Gamelogic.Utils;
using Improbable;
using Improbable.Core;
using Improbable.Player;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using UnityEngine;

[WorkerType(WorkerPlatform.UnityClient)]

public class PlayerAnimator : MonoBehaviour {

	[Require] private PlayerInput.Reader PlayerInputReader;
	[Require] private Health.Reader HealthReader;

	public Animator anim;
	int walk;
	int idle02;
	int run;
	int die;
	int health;


	void OnEnable ()
	{
		health = 1;
		anim = GetComponent<Animator>();
		idle02 = Animator.StringToHash("Idle02");
		walk = Animator.StringToHash("Walk");
		run = Animator.StringToHash("Run");
		die =  Animator.StringToHash("Die");
		HealthReader.CurrentHealthUpdated.Add(OnCurrentHealthUpdated);
	}
		
	private void OnDisable()
	{
		HealthReader.CurrentHealthUpdated.Remove(OnCurrentHealthUpdated);
	}

	private void OnCurrentHealthUpdated(int currentHealth)
	{
		health = currentHealth;
	}

	void Update ()
	{
		var joystick = PlayerInputReader.Data.joystick;
		Animations (joystick);
	}


	private void Animations(Joystick joystick)
	{	
		
		if (Mathf.Abs (joystick.xAxis) + Mathf.Abs (joystick.yAxis) < 0.1f && health > 0) {
			anim.Play (idle02);
		} else if (Mathf.Abs (joystick.xAxis) > 0.1f && (Mathf.Abs (joystick.yAxis) < 0.1f) && health > 0) {
			anim.Play (walk);
		} else if (health > 0) {  
			anim.Play (run);
		} else if (health <=0){
			anim.Play(die);
		
		}
			
	}
}
