using Assets.Gamelogic.Core;
using Improbable;
using Improbable.Core;
using Improbable.Player;
using Improbable.Unity.Core.Acls;
using Improbable.Worker;
using Quaternion = UnityEngine.Quaternion;
using UnityEngine;
using Improbable.Unity.Entity;

namespace Assets.Gamelogic.EntityTemplates
{
    public class EntityTemplateFactory : MonoBehaviour
    {
        public static Entity CreatePlayerCreatorTemplate()
        {
            var playerCreatorEntityTemplate = EntityBuilder.Begin()
                .AddPositionComponent(Improbable.Coordinates.ZERO.ToUnityVector(), CommonRequirementSets.PhysicsOnly)
                .AddMetadataComponent(entityType: SimulationSettings.PlayerCreatorPrefabName)
                .SetPersistence(true)
                .SetReadAcl(CommonRequirementSets.PhysicsOrVisual)
                .AddComponent(new Rotation.Data(Quaternion.identity.ToNativeQuaternion()), CommonRequirementSets.PhysicsOnly)
                .AddComponent(new PlayerCreation.Data(), CommonRequirementSets.PhysicsOnly)
                .Build();

            return playerCreatorEntityTemplate;
        }

		public static Entity CreateWeaponBoxContainerTemplate(Vector3 initialPosition)
		{
			var WeaponBoxContainerTemplate = EntityBuilder.Begin()
				.AddPositionComponent(initialPosition, CommonRequirementSets.PhysicsOnly)
				.AddMetadataComponent("WeaponBoxContainer")
				.SetPersistence(true)
				.SetReadAcl(CommonRequirementSets.PhysicsOrVisual)
				.AddComponent(new Rotation.Data(Quaternion.identity.ToNativeQuaternion()), CommonRequirementSets.PhysicsOnly)
				.Build();		

			return WeaponBoxContainerTemplate;
		}

		public static Entity CreateSpeedBoostBoxContainerTemplate(Vector3 initialPosition)
		{
			var SpeedBoostBoxContainerTemplate = EntityBuilder.Begin()
				.AddPositionComponent(initialPosition, CommonRequirementSets.PhysicsOnly)
				.AddMetadataComponent("SpeedBoostBoxContainer")
				.SetPersistence(true)
				.SetReadAcl(CommonRequirementSets.PhysicsOrVisual)
				.AddComponent(new Rotation.Data(Quaternion.identity.ToNativeQuaternion()), CommonRequirementSets.PhysicsOnly)
				.Build();		

			return SpeedBoostBoxContainerTemplate;
		}

		public static Entity CreateHPBoxContainerTemplate(Vector3 initialPosition)
		{
			var HPBoxContainerTemplate = EntityBuilder.Begin()
				.AddPositionComponent(initialPosition, CommonRequirementSets.PhysicsOnly)
				.AddMetadataComponent("HPBoxContainer")
				.SetPersistence(true)
				.SetReadAcl(CommonRequirementSets.PhysicsOrVisual)
				.AddComponent(new Rotation.Data(Quaternion.identity.ToNativeQuaternion()), CommonRequirementSets.PhysicsOnly)
				.Build();		

			return HPBoxContainerTemplate;
		}


		public static Entity CreatePlayerTemplate(string clientId, Vector3 initialPosition)
        {
            var playerTemplate = EntityBuilder.Begin()
				.AddPositionComponent(initialPosition, CommonRequirementSets.PhysicsOnly)                
				.AddMetadataComponent(entityType: SimulationSettings.PlayerPrefabName)
                .SetPersistence(false)
                .SetReadAcl(CommonRequirementSets.PhysicsOrVisual)
                .AddComponent(new Rotation.Data(Quaternion.identity.ToNativeQuaternion()), CommonRequirementSets.PhysicsOnly)
                .AddComponent(new ClientAuthorityCheck.Data(), CommonRequirementSets.SpecificClientOnly(clientId))
                .AddComponent(new ClientConnection.Data(SimulationSettings.TotalHeartbeatsBeforeTimeout), CommonRequirementSets.PhysicsOnly)
				.AddComponent(new PlayerInput.Data(new Joystick(xAxis: 0, yAxis: 0)), CommonRequirementSets.SpecificClientOnly(clientId))
				.AddComponent(new Touching.Data(), CommonRequirementSets.PhysicsOnly)
				.AddComponent(new Health.Data(100), CommonRequirementSets.PhysicsOnly)
				.Build();

            return playerTemplate;
        }

        public static Entity CreateCubeTemplate()
        {
            var cubeTemplate = EntityBuilder.Begin()
                .AddPositionComponent(Improbable.Coordinates.ZERO.ToUnityVector(), CommonRequirementSets.PhysicsOnly)
                .AddMetadataComponent(entityType: SimulationSettings.CubePrefabName)
                .SetPersistence(true)
                .SetReadAcl(CommonRequirementSets.PhysicsOrVisual)
                .AddComponent(new Rotation.Data(Quaternion.identity.ToNativeQuaternion()), CommonRequirementSets.PhysicsOnly)
                .Build();

            return cubeTemplate;
        }
			
    }
}
