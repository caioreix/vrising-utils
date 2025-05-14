
using System;
using System.Runtime.InteropServices;
using Il2CppInterop.Runtime;
using Unity.Entities;

namespace Utils.VRising;

internal static class Extensions {
    static EntityManager EntityManager => Entities.EntityManager.Get();

    public unsafe static void Destroy(this Entity entity) {
        EntityManager.DestroyEntity(entity);
    }

    public static bool Has<T>(this Entity entity) {
        return EntityManager.HasComponent(entity, new(Il2CppType.Of<T>()));
    }

    public unsafe static T Read<T>(this Entity entity) where T : struct {
        ComponentType componentType = new(Il2CppType.Of<T>());
        TypeIndex typeIndex = componentType.TypeIndex;

        void* componentData = EntityManager.GetComponentDataRawRO(entity, typeIndex);
        return Marshal.PtrToStructure<T>(new IntPtr(componentData));
    }

    public unsafe static void Write<T>(this Entity entity, T componentData) where T : struct {
        ComponentType componentType = new(Il2CppType.Of<T>());
        TypeIndex typeIndex = componentType.TypeIndex;

        byte[] byteArray = StructureToByteArray(componentData);
        int size = Marshal.SizeOf<T>();

        fixed (byte* byteData = byteArray) {
            EntityManager.SetComponentDataRaw(entity, typeIndex, byteData, size);
        }
    }

    static byte[] StructureToByteArray<T>(T structure) where T : struct {
        int size = Marshal.SizeOf(structure);
        byte[] byteArray = new byte[size];

        IntPtr ptr = Marshal.AllocHGlobal(size);
        Marshal.StructureToPtr(structure, ptr, true);

        Marshal.Copy(ptr, byteArray, 0, size);
        Marshal.FreeHGlobal(ptr);

        return byteArray;
    }
}
