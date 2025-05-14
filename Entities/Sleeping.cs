using Unity.Collections;
using Unity.Entities;

namespace Utils.VRising.Entities;

public static class Sleeping {
    public static NativeArray<Entity> GetAll() {
        var query = World.EntityManager.CreateEntityQuery(
            ComponentType.ReadOnly<ProjectM.Buff>(),
            ComponentType.ReadOnly<ProjectM.SpawnSleepingBuff>(),
            ComponentType.ReadOnly<ProjectM.InsideBuff>()
        );
        return query.ToEntityArray(Allocator.Temp);
    }

    public static bool HasTarget(NativeArray<Entity> sleepingEntities, Entity target) {
        foreach (var sleepingEntity in sleepingEntities) {
            var buff = World.EntityManager.GetComponentData<ProjectM.Buff>(sleepingEntity);
            if (buff.Target == target) {
                return true;
            }
        }
        return false;
    }
}
