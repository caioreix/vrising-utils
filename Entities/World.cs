#nullable enable

using UnityEngine;

namespace Utils.VRising.Entities;

public static class World {
    internal static Unity.Entities.World? _world;
    internal static Unity.Entities.EntityManager em => world.EntityManager;
    public static Unity.Entities.World world {
        get {
            if (_world != null) return _world;

            _world = Server ?? Client;
            if (_world != null) return _world;

            throw new System.Exception("No Server or Client world found.");
        }
    }

    public static bool IsServer => Application.productName == "VRisingServer";
    public static bool IsClient => Application.productName == "VRising";

    public static Unity.Entities.World Client {
        get {
            return GetWorld("Client_0") ?? throw new System.Exception("There is no Client world (yet). Did you install a client mod on the server?");
        }
    }

    public static Unity.Entities.World Server {
        get {
            return GetWorld("Server") ?? throw new System.Exception("There is no Server world (yet). Did you install a server mod on the client?");
        }
    }

    private static Unity.Entities.World? GetWorld(string name) {
        foreach (Unity.Entities.World sAllWorld in Unity.Entities.World.s_AllWorlds) {
            if (sAllWorld.Name == name) {
                return sAllWorld;
            }
        }
        return null;
    }
}
