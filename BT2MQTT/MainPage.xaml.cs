using BT2MQTT.Permissions;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using System.Text;

namespace BT2MQTT;

public partial class MainPage : ContentPage
{
	private readonly IBluetoothLE _ble;
	private readonly IAdapter _adapter;

	public MainPage()
	{
		InitializeComponent();

		_ble = CrossBluetoothLE.Current;
		_adapter = _ble.Adapter;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();

		var status = await Microsoft.Maui.ApplicationModel.Permissions.CheckStatusAsync<BluetoothPermissions>();

		if (status != PermissionStatus.Granted)
		{
			status = await Microsoft.Maui.ApplicationModel.Permissions.RequestAsync<BluetoothPermissions>();
		}

		StatusLabel.Text = $"BLE permission: {status}, adapter: {_ble.State}";
	}

	private async void OnScanBleClicked(object? sender, EventArgs e)
	{
		try
		{
			DevicesLabel.Text = string.Empty;
			StatusLabel.Text = "Skenuji BLE...";

			_adapter.DeviceDiscovered -= OnDeviceDiscovered;
			_adapter.DeviceDiscovered += OnDeviceDiscovered;

			if (_adapter.IsScanning)
			{
				await _adapter.StopScanningForDevicesAsync();
			}

			await _adapter.StartScanningForDevicesAsync();

			StatusLabel.Text = "Scan dokončen";
			if (string.IsNullOrWhiteSpace(DevicesLabel.Text))
			{
				DevicesLabel.Text = "Nic nenalezeno";
			}
		}
		catch (Exception ex)
		{
			StatusLabel.Text = $"Chyba scan: {ex.Message}";
		}
	}

	private void OnDeviceDiscovered(object? sender, Plugin.BLE.Abstractions.EventArgs.DeviceEventArgs e)
	{
		MainThread.BeginInvokeOnMainThread(() =>
		{
			var name = string.IsNullOrWhiteSpace(e.Device.Name) ? "(bez názvu)" : e.Device.Name;
			DevicesLabel.Text += $"{name} | {e.Device.Id}{Environment.NewLine}";
		});
	}
}