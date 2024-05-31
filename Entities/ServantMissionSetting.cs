using Unity.Collections;
using Unity.Entities;

namespace Utils.VRising.Entities;

public static class ServantMissionSetting {
    public static NativeArray<Entity> GetAll() {
        var ServantMissionSettingQuery = World.em.CreateEntityQuery(
                ComponentType.ReadWrite<ProjectM.ServantMissionSetting>()
            );
        return ServantMissionSettingQuery.ToEntityArray(Allocator.Temp);
    }

    public static DynamicBuffer<ProjectM.ServantMissionSetting> GetBuffer() {
        var entities = GetAll();
        foreach (var MissionSetting in entities) {
            return World.em.GetBuffer<ProjectM.ServantMissionSetting>(MissionSetting);
        }

        return new DynamicBuffer<ProjectM.ServantMissionSetting>();
    }
}
