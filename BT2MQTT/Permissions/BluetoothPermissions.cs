namespace BT2MQTT.Permissions;

public class BluetoothPermissions : Microsoft.Maui.ApplicationModel.Permissions.BasePlatformPermission
{
#if ANDROID
	public override (string androidPermission, bool isRuntime)[] RequiredPermissions =>
			new[]
			{
						("android.permission.BLUETOOTH_SCAN", true),
						("android.permission.BLUETOOTH_CONNECT", true),
						("android.permission.ACCESS_FINE_LOCATION", true),
						("android.permission.ACCESS_COARSE_LOCATION", true)
			};
#endif
}