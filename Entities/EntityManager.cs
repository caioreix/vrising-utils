
using Unity.Entities;

namespace Utils.VRising.Entities;


public static class EntityManager {
    public static Unity.Entities.EntityManager Get() {
        // This method returns the entity manager
        return World.EntityManager;
    }
}
