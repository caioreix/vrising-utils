using System.Collections.Generic;
using ProjectM;

namespace Utils.VRising.Entities;

public static class DayNightCycle {
    public static ProjectM.DayNightCycle GetSingleton() {
        return Systems.ServerScriptMapper.Get()._ServerGameManager.DayNightCycle;
    }

    public static ProjectM.TimeOfDay GetTimeOfDay(ProjectM.DayNightCycle dnc = default) {
        if (emptyDNC(dnc)) { dnc = GetSingleton(); }
        return dnc.TimeOfDay;
    }

    public static double GetTime(ProjectM.DayNightCycle dnc = default) {
        if (emptyDNC(dnc)) { dnc = GetSingleton(); }
        return dnc.Time;
    }

    public static ProjectM.DayNightCycleExtensions.TimeScale GetTimeScale(ProjectM.DayNightCycle dnc = default) {
        if (emptyDNC(dnc)) { dnc = GetSingleton(); }
        return dnc.GetTimeScale();
    }

    public static float GetTimeSinceDayStart(ProjectM.DayNightCycle dnc = default) {
        if (emptyDNC(dnc)) { dnc = GetSingleton(); }
        return dnc.TimeSinceDayStart;
    }

    public static float GetDayTimeStartInSeconds(ProjectM.DayNightCycle dnc = default) {
        if (emptyDNC(dnc)) { dnc = GetSingleton(); }
        return dnc.DayTimeStartInSeconds;
    }

    public static float GetDayTimeDurationInSeconds(ProjectM.DayNightCycle dnc = default) {
        if (emptyDNC(dnc)) { dnc = GetSingleton(); }
        return dnc.DayTimeDurationInSeconds;
    }

    public static float GetDayDurationInSeconds(ProjectM.DayNightCycle dnc = default) {
        if (emptyDNC(dnc)) { dnc = GetSingleton(); }
        return dnc.DayDurationInSeconds;
    }

    public static bool IsDay(ProjectM.DayNightCycle dnc = default) {
        return (GetTimeOfDay(dnc) == ProjectM.TimeOfDay.Day);
    }

    public static bool IsBloodMoonDay(ProjectM.DayNightCycle dnc = default) {
        if (emptyDNC(dnc)) { dnc = GetSingleton(); }
        return dnc.IsBloodMoonDay();
    }

    private static bool emptyDNC(ProjectM.DayNightCycle dnc) {
        return EqualityComparer<ProjectM.DayNightCycle>.Default.Equals(dnc, default);
    }
}
