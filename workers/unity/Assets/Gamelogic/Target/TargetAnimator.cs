using Improbable;
using Improbable.Core;
using Improbable.Player;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using UnityEngine;

public class TargetAnimator : MonoBehaviour {

	[Require] private TargetInput.Reader TargetInputReader;

	public Animation anim;


	void OnEnable ()
	{
		anim = GetComponent<Animation>();
	}


	void Update ()
	{

		var commands = TargetInputReader.Data.commands;
		Animations (commands);

	}

	private void Animations(Commands commands)
	{
		if (Mathf.Abs (commands.xAxis) + Mathf.Abs (commands.yAxis) < 0.1f) {
			anim.Play ("Idle");
		} 
		else if ((Mathf.Abs(commands.xAxis) > 0.1f && (Mathf.Abs(commands.yAxis) < 0.1f))){
			anim.Play("Walk");
		}
		else
		{  
			anim.Play ("Walk");
		}

	}
}
