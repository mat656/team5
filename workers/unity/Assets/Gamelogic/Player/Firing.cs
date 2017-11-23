using UnityEngine;
using UnityEngine.UI;
using UnityEngine;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using Improbable.Player;

namespace Assets.Gamelogic.Player
{	
	
	public class Firing : MonoBehaviour
	{

		[Require] private PlayerInput.Reader PlayerInputReader;

		[SerializeField]
		public GameObject m_Weapon1;
		[SerializeField]
		public GameObject m_Weapon2;
		[SerializeField]
		public GameObject m_Weapon3;
		[SerializeField]
		public GameObject m_Weapon4;

		public Transform m_WeaponTransform;
		public GameObject m_WeaponTransformUp;

		TouchBox m_touch;
		public int m_selectedWeapon;



		private void OnEnable()
		{
			m_touch = gameObject.GetComponent<TouchBox>();
			PlayerInputReader.FireTriggered.Add (FireWeapon);
		
		
		}

		private void OnDisable(){
			PlayerInputReader.FireTriggered.Remove (FireWeapon);
		}

	
		private void FixedUpdate ()
		{
			m_selectedWeapon = m_touch.GetSelectedWeapon();
		}

		private void FireWeapon (Fire fire)
		{
			if (m_selectedWeapon > 0) {
				if (m_selectedWeapon == 1) {
					//Vector3 weapon_pos = new Vector3 (transform.position.x, transform.position.y + 0.5f,transform.position.z + 1.5f);
					Instantiate (m_Weapon1, m_WeaponTransform.position,m_WeaponTransform.rotation);

				}
				if (m_selectedWeapon == 2) {
					//Vector3 weapon_pos = new Vector3 (transform.position.x, transform.position.y + 0.5f,transform.position.z + 1.5f);
					Instantiate (m_Weapon2,  m_WeaponTransform.position,m_WeaponTransform.rotation);

				}
				if (m_selectedWeapon == 3) {
					//Vector3 weapon_pos = new Vector3 (transform.position.x, transform.position.y + 0.5f,transform.position.z + 1.5f);
					Instantiate (m_Weapon3,  m_WeaponTransform.position,m_WeaponTransform.rotation);

				}
				if (m_selectedWeapon == 4) {
					//Vector3 weapon_pos = new Vector3 (transform.position.x, transform.position.y + 0.5f,transform.position.z + 1.5f);
					Instantiate (m_Weapon4,  m_WeaponTransform.position,m_WeaponTransform.rotation);
				}

				GameObject iconToDisable = m_WeaponTransformUp.transform.GetChild (0).gameObject;
				Destroy (iconToDisable);

			}

	}
	}
}