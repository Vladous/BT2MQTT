using System.Text.Json;
using BT2MQTT.Models;

namespace BT2MQTT.Services;

public static class SettingsService
{
	private const string SavedDevicesKey = "saved_bluetooth_devices";

	public static List<SavedBluetoothDevice> LoadSavedDevices()
	{
		var json = Preferences.Default.Get(SavedDevicesKey, string.Empty);

		if (string.IsNullOrWhiteSpace(json))
		{
			return [];
		}

		try
		{
			return JsonSerializer.Deserialize<List<SavedBluetoothDevice>>(json) ?? [];
		}
		catch
		{
			return [];
		}
	}

	public static void SaveSavedDevices(List<SavedBluetoothDevice> devices)
	{
		var json = JsonSerializer.Serialize(devices);
		Preferences.Default.Set(SavedDevicesKey, json);
	}
}