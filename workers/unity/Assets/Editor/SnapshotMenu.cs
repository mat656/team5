using Assets.Gamelogic.Core;
using Assets.Gamelogic.EntityTemplates;
using Improbable;
using Improbable.Worker;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor 
{
	public class SnapshotMenu : MonoBehaviour
	{
		[MenuItem("Improbable/Snapshots/Generate Default Snapshot")]
		private static void GenerateDefaultSnapshot()
		{
			var snapshotEntities = new Dictionary<EntityId, Entity>();
			var currentEntityId = 1;

			snapshotEntities.Add(new EntityId(currentEntityId++), EntityTemplateFactory.CreatePlayerCreatorTemplate());
			PopulateSnapshotWithWeaponBoxContainerEntities (ref snapshotEntities, ref currentEntityId);
			PopulateSnapshotWithSpeedBoostBoxContainerEntities (ref snapshotEntities, ref currentEntityId);
			PopulateSnapshotWithHPBoxContainerEntities (ref snapshotEntities, ref currentEntityId);
			SaveSnapshot(snapshotEntities);
		}

		private static void SaveSnapshot(IDictionary<EntityId, Entity> snapshotEntities)
		{
			File.Delete(SimulationSettings.DefaultSnapshotPath);
			var maybeError = Snapshot.Save(SimulationSettings.DefaultSnapshotPath, snapshotEntities);

			if (maybeError.HasValue)
			{
				Debug.LogErrorFormat("Failed to generate initial world snapshot: {0}", maybeError.Value);
			}
			else
			{
				Debug.LogFormat("Successfully generated initial world snapshot at {0}", SimulationSettings.DefaultSnapshotPath);
			}
		}

		public static void PopulateSnapshotWithWeaponBoxContainerEntities(ref Dictionary<EntityId,Entity> snapshotEntities,ref int nextavailableId)
		{
			for (var i = 0; i < 10; i++) {
				var Weaponcoors = new Vector3 ((Random.Range(-1f,1f) * 0.5f)*Random.Range(-200f,200f),-5f,(Random.Range(-1f,1f)*0.5f)*Random.Range(-200f,200f));
				snapshotEntities.Add(new EntityId(nextavailableId++), EntityTemplateFactory.CreateWeaponBoxContainerTemplate(Weaponcoors));
			}
		}

		public static void PopulateSnapshotWithSpeedBoostBoxContainerEntities(ref Dictionary<EntityId,Entity> snapshotEntities,ref int nextavailableId)
		{
			for (var i = 0; i < 10; i++) {
				var SpeedBoostBoxcoors = new Vector3 ((Random.Range(-1f,1f) * 0.5f)*Random.Range(-200f,200f),-5f,(Random.Range(-1f,1f)*0.5f)*Random.Range(-200f,200f));
				snapshotEntities.Add(new EntityId(nextavailableId++), EntityTemplateFactory.CreateSpeedBoostBoxContainerTemplate(SpeedBoostBoxcoors));
			}
		}

		public static void PopulateSnapshotWithHPBoxContainerEntities(ref Dictionary<EntityId,Entity> snapshotEntities,ref int nextavailableId)
		{
			for (var i = 0; i < 5; i++) {
				var HPBoxcoors = new Vector3 ((Random.Range(-1f,1f) * 0.5f)*Random.Range(-200f,200f),-5f,(Random.Range(-1f,1f)*0.5f)*Random.Range(-200f,200f));
				snapshotEntities.Add(new EntityId(nextavailableId++), EntityTemplateFactory.CreateHPBoxContainerTemplate(HPBoxcoors));
			}
		}
	}
}
