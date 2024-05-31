using Unity.Collections;
using Unity.Entities;

namespace Utils.VRising.Entities;

public static class PlayerCharacter {
    public static NativeArray<Entity> GetAll() {
        var query = World.em.CreateEntityQuery(
            ComponentType.ReadOnly<ProjectM.PlayerCharacter>()
        );
        return query.ToEntityArray(Allocator.Temp);
    }

    // IsOffline check if an user is offline based on passed player entity.
    public static bool IsOnline(Entity playerCharacter) {
        var player = World.em.GetComponentData<ProjectM.PlayerCharacter>(playerCharacter);
        var user = World.em.GetComponentData<ProjectM.Network.User>(player.UserEntity);
        return user.IsConnected;
    }

    public static bool IsAllOnlinePlayersSleeping() {
        var sleepingEntities = Sleeping.GetAll();
        var playerEntities = GetAll();

        foreach (var playerEntity in playerEntities) {
            // Offline players outside coffin is not considered sleeping
            if (!IsOnline(playerEntity)) {
                continue;
            }

            if (!Sleeping.HasTarget(sleepingEntities, playerEntity)) {
                return false;
            }
        }
        return true;
    }
}
