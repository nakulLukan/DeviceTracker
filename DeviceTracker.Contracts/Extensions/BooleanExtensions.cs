namespace DeviceTracker.Shared.Extensions;

public static class BooleanExtensions
{
    public static string ToOnOffText(this bool val)
    {
        return val ? "ON" : "OFF";
    }
    public static string ToYesNoText(this bool val)
    {
        return val ? "Yes" : "No";
    }
}
