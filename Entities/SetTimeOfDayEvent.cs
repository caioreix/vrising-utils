using Unity.Entities;

namespace Utils.VRising.Entities;

public static class SetTimeOfDayEvent {
    public static void Add(int hour = 0, int day = 0) {
        create(hour, day, ProjectM.Network.SetTimeOfDayEvent.SetTimeType.Add);
    }

    public static void Set(int hour = 0, int day = 0) {
        create(hour, day, ProjectM.Network.SetTimeOfDayEvent.SetTimeType.Set);
    }

    private static void create(int hour, int day, ProjectM.Network.SetTimeOfDayEvent.SetTimeType type) {
        var setTimeEntity = World.em.CreateEntity(
            ComponentType.ReadOnly<ProjectM.Network.SetTimeOfDayEvent>()
        );
        World.em.SetComponentData<ProjectM.Network.SetTimeOfDayEvent>(
            setTimeEntity,
            new ProjectM.Network.SetTimeOfDayEvent() { Hour = hour, Day = day, Type = type }
        );
    }
}
