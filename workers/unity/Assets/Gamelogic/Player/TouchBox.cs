using Improbable.Unity;
using Improbable.Unity.Visualizer;
using UnityEngine;
using Improbable.Player;
using System.Collections;
using UnityEngine.UI;


namespace Assets.Gamelogic.Player
{
	// Add this MonoBehaviour on UnityWorker (server-side) workers only
	//[WorkerType(WorkerPlatform.UnityWorker)]
	public class TouchBox : MonoBehaviour
	{
		[Require] private PlayerInput.Reader PlayerInputReader;

		private int m_WeaponNumber = 2;
		private int m_WeaponSelected = 0;


		[SerializeField]
		private GameObject m_Weapon1Icon;
		[SerializeField]
		private GameObject m_Weapon2Icon;
		[SerializeField]
		private GameObject m_Weapon3Icon;
		[SerializeField]
		private GameObject m_Weapon4Icon;
		public Transform m_WeaponTransformUp;



		//[Require] private Touching.Writer TouchingWriter
		private void OnEnable()
		{


			PlayerInputReader.FireTriggered.Add (FireButton);

		}

		private void OnTriggerEnter(Collider other)
		{
			if (other != null && other.gameObject.tag == "WeaponBox") {



				if (m_WeaponTransformUp.childCount > 0) {
					Destroy (m_WeaponTransformUp.GetChild (0).gameObject);
				}

				m_WeaponSelected = Random.Range (1, m_WeaponNumber);


				if (m_WeaponSelected == 1) {
					GameObject weaponInst = Instantiate (m_Weapon1Icon, m_WeaponTransformUp.position, m_WeaponTransformUp.rotation);
					weaponInst.transform.parent = m_WeaponTransformUp;
				}
				if (m_WeaponSelected == 2) {
					GameObject weaponInst = Instantiate (m_Weapon2Icon, m_WeaponTransformUp.position, m_WeaponTransformUp.rotation);
					weaponInst.transform.parent = m_WeaponTransformUp;
				}
				if (m_WeaponSelected == 3) {
					GameObject weaponInst = Instantiate (m_Weapon3Icon, m_WeaponTransformUp.position, m_WeaponTransformUp.rotation);
					weaponInst.transform.parent = m_WeaponTransformUp;
				}
				if (m_WeaponSelected == 4) {
					GameObject weaponInst = Instantiate (m_Weapon4Icon, m_WeaponTransformUp.position, m_WeaponTransformUp.rotation);
					weaponInst.transform.parent = m_WeaponTransformUp;
				}
			} 
				
		}

		public int GetSelectedWeapon(){

			return m_WeaponSelected;

		}
		private void FireButton (Fire fire){
		
			m_WeaponSelected = 0;
		}
	

			
	}

}
