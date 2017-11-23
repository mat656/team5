using UnityEngine.UI;
using Improbable.Player;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using UnityEngine;
using Improbable.Worker;
using Improbable;


[WorkerType(WorkerPlatform.UnityClient)]
	public class Muori : MonoBehaviour
	{
		[Require] private PlayerInput.Writer PlayerInputWriter;
		[Require] private Health.Reader HealthReader;

		
		int die;	
		
		private PlayersCounter counter; 
		private Text loseText;
		private Slider HealthBar;
		private Text[] TextBar;
		private Text healthText;

		public bool dead = false;

		private void OnEnable()
		{
			loseText = GameObject.FindGameObjectWithTag ("LoseText").GetComponent<Text> ();
			dead = false;
			HealthReader.CurrentHealthUpdated.Add(OnCurrentHealthUpdated);
			counter = GameObject.FindGameObjectWithTag ("WinText").GetComponent<PlayersCounter>();
		}

		private void OnDisable()
		{
			HealthReader.CurrentHealthUpdated.Remove(OnCurrentHealthUpdated);
		}

		private void OnCurrentHealthUpdated(int currentHealth)
		{
		if (HealthReader.Authority == Authority.NotAuthoritative) {
			HealthBar = GameObject.Find ("Slider").GetComponent<Slider> ();
			TextBar = GameObject.Find ("Slider").GetComponentsInChildren<Text> ();
			foreach (Text text in TextBar)
				healthText = text;
				HealthBar.value = currentHealth;
				healthText.text = currentHealth.ToString ();
		}

		//Display LOSE
		if (currentHealth <= 0 && !dead) {
				dead = true;
				loseText.text = "YOU LOSE!";
				counter.SetPlayerCount(-1);

			}
		}

		// if currentHealth <= 0 fai qualcosa (animazione di morte)
		public bool IsDied (){
			return dead;
		}

	}



