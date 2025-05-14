using Unity.Collections;
using Unity.Entities;

namespace Utils.VRising.Entities;

public static class User {
    // Get the entities of component type User.
    public static NativeArray<Entity> GetAll() {
        var query = World.EntityManager.CreateEntityQuery(
            ComponentType.ReadOnly<ProjectM.Network.User>()
        );
        return query.ToEntityArray(Allocator.Temp);
    }

    public static Entity GetFirstOnlinePlayer() {
        var userEntities = GetAll();
        foreach (var userEntity in userEntities) {
            var user = World.EntityManager.GetComponentData<ProjectM.Network.User>(userEntity);
            if (user.IsConnected) {
                return userEntity;
            }
        }
        return Entity.Null;
    }

    public static Entity GetLocalUser() {
        var query = World.EntityManager.CreateEntityQuery(
            ComponentType.ReadOnly<ProjectM.Network.LocalUser>()
        );
        NativeArray<Entity> entities = query.ToEntityArray(Allocator.Temp);

        return entities.Length > 0 ? entities[0] : Entity.Null;
    }

    // IsAllOffline check if all users are offline.
    public static bool IsAllOffline() {
        var userEntities = GetAll();
        foreach (var userEntity in userEntities) {
            var user = World.EntityManager.GetComponentData<ProjectM.Network.User>(userEntity);
            if (user.IsConnected) {
                return false;
            }
        }
        return true;
    }
}
