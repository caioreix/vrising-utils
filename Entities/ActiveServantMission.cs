using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;

namespace Utils.VRising.Entities;

public static class ActiveServantMission {
    // Get the entities of component type ActiveServantMission.
    public static NativeArray<Entity> GetAll() {
        var servantMissionsQuery = World.em.CreateEntityQuery(
                ComponentType.ReadWrite<ProjectM.CastleBuilding.ActiveServantMission>()
            );
        return servantMissionsQuery.ToEntityArray(Allocator.Temp);
    }

    public static DynamicBuffer<ProjectM.CastleBuilding.ActiveServantMission> GetBuffer(Entity mission) {
        return World.em.GetBuffer<ProjectM.CastleBuilding.ActiveServantMission>(mission);
    }

    public static List<DynamicBuffer<ProjectM.CastleBuilding.ActiveServantMission>> GetAllBuffers() {
        var buffers = new List<DynamicBuffer<ProjectM.CastleBuilding.ActiveServantMission>>();
        var entities = GetAll();
        foreach (var entity in entities) {
            buffers.Add(GetBuffer(entity));
        }
        return buffers;
    }

    public static List<string> GetAllBuffersMissionUIDs() {
        var missionUIDs = new List<string>();
        var missions = GetAllBuffers();

        foreach (var missionBuffers in missions) {
            foreach (var buffer in missionBuffers) {
                missionUIDs.Add(GetMissionUID(buffer));
            }
        }
        return missionUIDs;
    }

    public static List<string> GetBufferMissionUIDs(Entity mission) {
        var missionUIDs = new List<string>();
        var missionBuffers = GetBuffer(mission);
        foreach (var buffer in missionBuffers) {
            missionUIDs.Add(GetMissionUID(buffer));
        }
        return missionUIDs;
    }

    public static string GetMissionUID(ProjectM.CastleBuilding.ActiveServantMission mission) {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(
            $"{GetMissiontDataId(mission)}-{GetMissionStartTime(mission)}-{GetMissionName(mission)}"
        );
        return System.Convert.ToBase64String(plainTextBytes);
    }

    public static string GetMissionName(ProjectM.CastleBuilding.ActiveServantMission mission) {
        return Systems.PrefabCollectionSystem.GetPrefabName(mission.MissionID);
    }

    public static float GetMissionLength(ProjectM.CastleBuilding.ActiveServantMission mission) {
        return mission.MissionLengthSeconds;
    }

    public static long GetMissionLengthTimestamp(ProjectM.CastleBuilding.ActiveServantMission mission) {
        return DateTimeOffset.Now.AddSeconds(GetMissionLength(mission)).ToUnixTimeSeconds();
    }

    public static void SetMissionLength(ref ProjectM.CastleBuilding.ActiveServantMission mission, float seconds) {
        mission.MissionLengthSeconds = seconds;
    }

    public static double GetMissionStartTime(ProjectM.CastleBuilding.ActiveServantMission mission) {
        return mission.MissionLengthSeconds;
    }

    public static int GetMissiontDataId(ProjectM.CastleBuilding.ActiveServantMission mission) {
        return mission.MissiontDataId;
    }
}
