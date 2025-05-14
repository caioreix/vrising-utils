



using System.Security.Cryptography;
using System.Text;
using Stunlock.Localization;


namespace Utils.VRising.Systems;

public class AssetGuid {
    public static Stunlock.Core.AssetGuid GetAssetGuid(string textString) {
        using SHA256 sha256 = SHA256.Create();
        byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(textString));

        Il2CppSystem.Guid uniqueGuid = new(hashBytes[..16]);
        return Stunlock.Core.AssetGuid.FromGuid(uniqueGuid);
    }

    private static AssetGuid FromGuid(Il2CppSystem.Guid uniqueGuid) {
        throw new System.NotImplementedException();
    }

    public static LocalizationKey LocalizeString(string text) {
        Stunlock.Core.AssetGuid assetGuid = GetAssetGuid(text);

        if (Localization.Initialized) {
            Localization._LocalizedStrings.TryAdd(assetGuid, text);
            return new(assetGuid);
        }

        return LocalizationKey.Empty;
    }
}
