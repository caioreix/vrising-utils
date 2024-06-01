using Stunlock.Core;

namespace Utils.VRising.Systems;

public static class PrefabCollectionSystem {
    public static ProjectM.PrefabCollectionSystem Get() {
        return Entities.World.world.GetExistingSystemManaged<ProjectM.PrefabCollectionSystem>();
    }

    public static string GetPrefabName(PrefabGUID hashCode) {
        var pcs = Get();
        string name = "Nonexistent";
        if (hashCode.GuidHash == 0) {
            return name;
        }
        try {
            name = pcs.PrefabLookupMap[hashCode].ToString();
        } catch {
            name = "NoPrefabName";
        }
        return name;
    }
}
