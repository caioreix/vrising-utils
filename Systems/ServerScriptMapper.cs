namespace Utils.VRising.Systems;

public static class ServerScriptMapper {
    public static ProjectM.Scripting.ServerScriptMapper Get() {
        return Entities.World.world.GetExistingSystemManaged<ProjectM.Scripting.ServerScriptMapper>();
    }
}
