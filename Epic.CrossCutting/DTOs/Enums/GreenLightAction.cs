namespace Epic.CrossCutting.DTOs.Enums;

public enum GreenLightAction
{
    CanStartCiSensitiveCheck,
    CanProvideCiGreenlight,
    CanStartPubSensitiveCheck,
    CanProvidePubGreenlight,
    CanMarkSensitiveCi,
    CanMarkSensitivePub
}