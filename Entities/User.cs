using Unity.Collections;
using Unity.Entities;

namespace Utils.VRising.Entities;

public static class User {
    // Get the entities of component type User.
    public static NativeArray<Entity> GetAll() {
        var query = World.em.CreateEntityQuery(
            ComponentType.ReadOnly<ProjectM.Network.User>()
        );
        return query.ToEntityArray(Allocator.Temp);
    }

    public static Entity GetFirstOnlinePlayer() {
        var userEntities = GetAll();
        foreach (var userEntity in userEntities) {
            var user = World.em.GetComponentData<ProjectM.Network.User>(userEntity);
            if (user.IsConnected) {
                return userEntity;
            }
        }
        return Entity.Null;
    }

    // IsAllOffline check if all users are offline.
    public static bool IsAllOffline() {
        var userEntities = GetAll();
        foreach (var userEntity in userEntities) {
            var user = World.em.GetComponentData<ProjectM.Network.User>(userEntity);
            if (user.IsConnected) {
                return false;
            }
        }
        return true;
    }
}
