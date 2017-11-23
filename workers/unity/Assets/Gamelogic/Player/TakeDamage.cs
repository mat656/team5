using Improbable;
using Improbable.Core;
using Improbable.Unity.Visualizer;
using Improbable.Worker;
using UnityEngine;
using Improbable.Player;
using Improbable.Unity;
using UnityEngine;
using UnityEngine.UI;


	[WorkerType(WorkerPlatform.UnityWorker)]

	public class TakeDamage : MonoBehaviour
	{
		[Require] private Health.Writer HealthWriter;


		private void OnTriggerEnter(Collider other)
		{
			
			if (HealthWriter == null)
				return;

			if (HealthWriter.Data.currentHealth <= 0)
				return;

			if (other != null && other.gameObject.tag == "FireBall")
			{
				
				int newHealth = HealthWriter.Data.currentHealth - 25;
				HealthWriter.Send(new Health.Update().SetCurrentHealth(newHealth));
			}
			if (other != null && other.gameObject.tag == "MagicBall")
			{
				
				int newHealth = HealthWriter.Data.currentHealth - 15;
				HealthWriter.Send(new Health.Update().SetCurrentHealth(newHealth));
			}
			if (other != null && other.gameObject.tag == "SnowBall")
			{
				
				int newHealth = HealthWriter.Data.currentHealth - 10;
				HealthWriter.Send(new Health.Update().SetCurrentHealth(newHealth));
			}
			if (other != null && other.gameObject.tag == "EnergyBall")
			{
				int newHealth = HealthWriter.Data.currentHealth - 20;
				HealthWriter.Send(new Health.Update().SetCurrentHealth(newHealth));
			}

			if (other != null && other.gameObject.tag == "HP")
			{
				int newHealth = HealthWriter.Data.currentHealth + 50;
				HealthWriter.Send(new Health.Update().SetCurrentHealth(newHealth));
			}
		}
	}
