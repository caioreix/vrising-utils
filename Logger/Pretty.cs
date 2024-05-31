// using System;
// using System.Collections.Generic;
// using System.Text.RegularExpressions;
// using Unity.Entities;
// using Stunlock.Core;
// using FMOD.Studio;

namespace Utils.VRising.Logger;

public static class PrettyLog {
    // NativeArray logs
    // public static void NativeArray<T>(Unity.Collections.NativeArray<T> data, string prefix = "") where T : new() {
    //     if (Settings.ENV.EnableTraceLogs) {
    //         var lines = new List<string>();
    //         foreach (var d in data) {
    //             lines.Add($"\"{d}\"");
    //         }

    //         if (prefix == "") { prefix = data.GetType().ToString(); }

    //         var msg = $"\"{prefix}\": " + "[" + String.Join(", ", lines) + "]";
    //         Utils.Logger.Config.logFile(msg, "List:   ");
    //     }
    // }

    // public static void ComponentTypes(EntityManager em, Entity target, Entity entity) {
    //     var data = em.GetComponentTypes(target);
    //     NativeArray(data, getPrefabNameIfExist(em, entity));
    // }

    // Struct logs
    // public static void Struct<T>(T data) {
    //     if (Settings.ENV.EnableTraceLogs) {
    //         var msg = structToString(data);

    //         Utils.Logger.Config.logger.LogDebug(msg);
    //         Utils.Logger.Config.logFile(msg, "Struct: ");
    //     }
    // }

    // private static string getPrefabNameIfExist(EntityManager em, Entity entity) {
    //     if (em.HasComponent<PrefabGUID>(entity)) {
    //         var prefab = em.GetComponentData<PrefabGUID>(entity);
    //         return getPrefabName(prefab);
    //     }
    //     return "";
    // }

    // private static string getPrefabName(PrefabGUID prefab) {
    //     return Utils.VRising.Systems.PrefabCollectionSystem.GetPrefabName(prefab);
    // }

    // private static string structToString<T>(T data) {
    //     var type = data.GetType();
    //     var fields = type.GetFields();
    //     var properties = type.GetProperties();

    //     var values = new Dictionary<string, object>();
    //     Array.ForEach(fields, (field) => {
    //         var value = getValue(field.GetValue(data));
    //         values.TryAdd(field.Name, value);
    //     });
    //     var lines = new List<string>();
    //     foreach (var value in values) {
    //         lines.Add($"\"{value.Key}\":\"{value.Value}\"");
    //     }

    //     return $"\"{type.ToString()}\": " + "{" + String.Join(",", lines) + "}";
    // }

    // private static string getValue(object value) {
    //     var valueStr = value.ToString();
    //     var type = value.GetType().ToString();

    //     if (type == "ProjectM.PrefabGUID") {
    //         var match = Regex.Match(valueStr, @"PrefabGuid\((.*)\)");
    //         if (match.Success) {
    //             var groupMatch = match.Groups[1].ToString();
    //             if (Int32.TryParse(groupMatch, out int j)) {
    //                 var prefab = new PrefabGUID(j);
    //                 valueStr = $"PrefabGuid({groupMatch}:{getPrefabName(prefab)})";
    //             }
    //         }
    //     }

    //     return valueStr;
    // }
}
