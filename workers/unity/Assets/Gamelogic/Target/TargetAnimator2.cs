using Improbable;
using Improbable.Core;
using Improbable.Player;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using UnityEngine;

public class TargetAnimator2 : MonoBehaviour {

	[Require] private TargetInput.Reader TargetInputReader;

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

		var commands = TargetInputReader.Data.commands;
		Animations (commands);

	}

	private void Animations(Commands commands)
	{
		if (Mathf.Abs (commands.xAxis) + Mathf.Abs (commands.yAxis) < 0.1f) {
			anim.Play (idle02);
		} 
		else if ((Mathf.Abs(commands.xAxis) > 0.1f && (Mathf.Abs(commands.yAxis) < 0.1f))){
			anim.Play(walk);
		}
		else
		{  
			anim.Play (run);
		}

	}
}

