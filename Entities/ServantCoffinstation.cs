using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;

namespace Utils.VRising.Entities;

public static class ServantCoffinstation {
    public static NativeArray<Entity> GetAll() {
        var query = World.em.CreateEntityQuery(
            ComponentType.ReadWrite<ProjectM.ServantCoffinstation>()
        );
        return query.ToEntityArray(Allocator.Temp);
    }

    public static ProjectM.ServantCoffinstation GetComponentData(Entity servantCoffinStation) {
        return World.em.GetComponentData<ProjectM.ServantCoffinstation>(servantCoffinStation);
    }

    public static Dictionary<Entity, ProjectM.ServantCoffinstation> GetAllComponentData() {
        var components = new Dictionary<Entity, ProjectM.ServantCoffinstation>();
        var entities = ServantCoffinstation.GetAll();
        foreach (var entity in entities) {
            components.Add(entity, ServantCoffinstation.GetComponentData(entity));
        }
        return components;
    }

    public static bool IsConverting(ProjectM.ServantCoffinstation servantCoffinStation) {
        return servantCoffinStation.State == ProjectM.ServantCoffinState.Converting;
    }

    public static float GetConvertionProgress(ProjectM.ServantCoffinstation servantCoffinStation) {
        return servantCoffinStation.ConvertionProgress;
    }

    public static void SetConvertionProgress(ref ProjectM.ServantCoffinstation servantCoffinStation, float seconds) {
        servantCoffinStation.ConvertionProgress = seconds;
    }

    public static void SetComponentData(Entity coffinStationEntity, ProjectM.ServantCoffinstation coffinStation) {
        World.em.SetComponentData<ProjectM.ServantCoffinstation>(coffinStationEntity, coffinStation);
    }
}
