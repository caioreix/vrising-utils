using Unity.Collections;
using Unity.Entities;

namespace Utils.VRising.Entities;

public static class PlayerCharacter {
    public static NativeArray<Entity> GetAll() {
        var query = World.EntityManager.CreateEntityQuery(
            ComponentType.ReadOnly<ProjectM.PlayerCharacter>()
        );
        return query.ToEntityArray(Allocator.Temp);
    }

    // IsOffline check if an user is offline based on passed player entity.
    public static bool IsOnline(Entity playerCharacter) {
        var player = World.EntityManager.GetComponentData<ProjectM.PlayerCharacter>(playerCharacter);
        var user = World.EntityManager.GetComponentData<ProjectM.Network.User>(player.UserEntity);
        return user.IsConnected;
    }

    public static Entity GetCharacterByUserEntity(Entity userEntity) {
        var query = World.EntityManager.CreateEntityQuery(
            ComponentType.ReadOnly<ProjectM.PlayerCharacter>()
        );
        NativeArray<Entity> entities = query.ToEntityArray(Allocator.Temp);

        // foreach (var entity in entities) {
        //     var player = entity.Read<ProjectM.PlayerCharacter>();
        //     if (player.UserEntity.Read<ProjectM.Network.User>().LocalCharacter == userEntity) {
        //         return entity;
        //     }
        // }
        return Entity.Null;
    }

    public static Entity GetLocalCharacter() {
        var query = World.EntityManager.CreateEntityQuery(
            ComponentType.ReadOnly<ProjectM.Network.LocalCharacter>()
        );
        NativeArray<Entity> entities = query.ToEntityArray(Allocator.Temp);

        return entities.Length > 0 ? entities[0] : Entity.Null;
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
