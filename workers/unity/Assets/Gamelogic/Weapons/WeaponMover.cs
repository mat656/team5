using Assets.Gamelogic.Core;
using Assets.Gamelogic.Utils;
using Improbable;
using Improbable.Core;
using Improbable.Player;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using UnityEngine;
using UnityEngine.UI;

public class WeaponMover : MonoBehaviour {


	public float m_Speed = 12f;    
	private Rigidbody m_rigidbody;

	// Use this for initialization
	void OnEnable () {
		m_rigidbody = GetComponent<Rigidbody>();
		Destroy (gameObject, 10);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Move ();
	}

	private void Move(){

		Vector3 movement = transform.forward * m_Speed * Time.deltaTime;
		Debug.Log (movement.x+""+movement.y+""+movement.z);
		m_rigidbody.MovePosition (m_rigidbody.position + movement);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other != null && other.gameObject.tag == "Player")
		{
			
			Destroy (gameObject);
		}
	}
}
