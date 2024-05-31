namespace Utils.VRising.Entities;

public static class World {
    internal static Unity.Entities.World _world;
    internal static Unity.Entities.EntityManager em = world.EntityManager;
    public static Unity.Entities.World world {
        get {
            if (_world != null) return _world;

            foreach (var world in Unity.Entities.World.s_AllWorlds) {
                if (world.Name == "Server" || world.Name == "Client") {
                    _world = world;
                }
            }

            return _world;
        }
    }

    public static void Set(Unity.Entities.World world) {
        _world = world;
    }
}
