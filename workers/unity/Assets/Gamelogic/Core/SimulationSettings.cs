﻿using UnityEngine;

namespace Assets.Gamelogic.Core
{
    public static class SimulationSettings
    {
		public static readonly float PlayerSpawnHeight = 10;
		public static readonly float PlayerAcceleration = 15;
		public static readonly Quaternion InitialThirdPersonCameraRotation = Quaternion.Euler(45, 0, 0);
		public static readonly float InitialThirdPersonCameraDistance = 35;

        public static readonly string PlayerPrefabName = "Player";
        public static readonly string PlayerCreatorPrefabName = "PlayerCreator";
        public static readonly string CubePrefabName = "Cube";
		public static readonly string TargetPrefabName = "Target";

        public static readonly float HeartbeatCheckIntervalSecs = 3;
        public static readonly uint TotalHeartbeatsBeforeTimeout = 3;
        public static readonly float HeartbeatSendingIntervalSecs = 3;

        public static readonly int TargetClientFramerate = 60;
        public static readonly int TargetServerFramerate = 60;
        public static readonly int FixedFramerate = 20;

        public static readonly float PlayerCreatorQueryRetrySecs = 4;
        public static readonly float PlayerEntityCreationRetrySecs = 4;

        public static readonly string DefaultSnapshotPath = Application.dataPath + "/../../../snapshots/default.snapshot";
    }
}
