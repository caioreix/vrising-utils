#pragma warning disable IDE0300 // Use 'new(...)'

using System;
using Il2CppInterop.Runtime;
using ProjectM.Network;
using Unity.Collections;
using Unity.Entities;
using Utils.Logger;

namespace Utils.VRising.Systems;

public static class Chat {
    static readonly ComponentType[] _networkChatMessageServerEventComponents = new ComponentType[] {
        ComponentType.ReadOnly(Il2CppType.Of<NetworkEventType>()),
        ComponentType.ReadOnly<SendEventToUser>(),
        ComponentType.ReadOnly(Il2CppType.Of<ChatMessageServerEvent>()),
    };

    static readonly ComponentType[] _networkChatMessageEventComponents = new ComponentType[] {
        ComponentType.ReadOnly(Il2CppType.Of<FromCharacter>()),
        ComponentType.ReadOnly(Il2CppType.Of<NetworkEventType>()),
        ComponentType.ReadOnly(Il2CppType.Of<ChatMessageEvent>())
    };

    static readonly NetworkEventType _networkChatMessageServerEventType = new() {
        IsAdminEvent = false,
        EventId = NetworkEvents.EventId_ChatMessageServerEvent,
        IsDebugEvent = false,
    };

    static readonly NetworkEventType _networkChatMessageEventType = new() {
        IsAdminEvent = false,
        EventId = NetworkEvents.EventId_ChatMessageEvent,
        IsDebugEvent = false,
    };

    public static void SendServerMessage(string message, Entity userEntity, ServerChatMessageType messageType = ServerChatMessageType.System) {
        User user = userEntity.Read<User>();

        ChatMessageServerEvent chatMessageEvent = new() {
            MessageText = new FixedString512Bytes(message),
            MessageType = messageType,
            FromUser = userEntity.Read<NetworkId>(),
            FromCharacter = user.LocalCharacter.GetEntityOnServer().Read<NetworkId>(),
            TimeUTC = DateTime.UtcNow.Ticks,
        };

        Log.Trace($"Sending server chat message '{message}' to user({user.CharacterName}:{user.Index})");

        Entity networkEntity = Entities.EntityManager.Get().CreateEntity(_networkChatMessageServerEventComponents);
        networkEntity.Write(new SendEventToUser { UserIndex = user.Index });
        networkEntity.Write(_networkChatMessageServerEventType);
        networkEntity.Write(chatMessageEvent);
    }

    public static void SendMessage(string message, Entity userEntity, Entity characterEntity, ChatMessageType messageType = ChatMessageType.Local) {
        User user = userEntity.Read<User>();

        ChatMessageEvent chatMessageEvent = new() {
            MessageText = new FixedString512Bytes(message),
            MessageType = messageType,
            ReceiverEntity = userEntity.Read<NetworkId>(),
        };

        Log.Trace($"Sending chat message '{message}' to user({user.CharacterName}:{user.Index})");

        Entity networkEntity = Entities.EntityManager.Get().CreateEntity(_networkChatMessageEventComponents);
        networkEntity.Write(new FromCharacter { User = userEntity, Character = characterEntity });
        networkEntity.Write(_networkChatMessageEventType);
        networkEntity.Write(chatMessageEvent);
    }
}
