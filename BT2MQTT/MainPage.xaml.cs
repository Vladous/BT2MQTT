using BT2MQTT.Models;
using BT2MQTT.Permissions;
using BT2MQTT.Resources.Strings;
using BT2MQTT.Services;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;

namespace BT2MQTT;

public partial class MainPage : ContentPage
{
	private readonly IBluetoothLE _ble;
	private readonly IAdapter _adapter;

	private readonly List<DiscoveredBluetoothDevice> _discoveredDevices = [];
	private List<SavedBluetoothDevice> _savedDevices = [];

	public MainPage()
	{
		InitializeComponent();

		_ble = CrossBluetoothLE.Current;
		_adapter = _ble.Adapter;

		LoadSavedDevicesToUi();
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();

		var status = await Microsoft.Maui.ApplicationModel.Permissions.CheckStatusAsync<BluetoothPermissions>();

		if (status != PermissionStatus.Granted)
		{
			status = await Microsoft.Maui.ApplicationModel.Permissions.RequestAsync<BluetoothPermissions>();
		}

		StatusLabel.Text = $"{AppStrings.BlePermission}: {status}, {AppStrings.BleState}: {_ble.State}";
	}

	private async void OnScanBleClicked(object? sender, EventArgs e)
	{
		try
		{
			_discoveredDevices.Clear();
			DiscoveredDevicesView.ItemsSource = null;
			StatusLabel.Text = AppStrings.ScanningBle;

			_adapter.DeviceDiscovered -= OnDeviceDiscovered;
			_adapter.DeviceDiscovered += OnDeviceDiscovered;

			if (_adapter.IsScanning)
			{
				await _adapter.StopScanningForDevicesAsync();
			}

			await _adapter.StartScanningForDevicesAsync();

			StatusLabel.Text = AppStrings.ScanCompleted;
			if (_discoveredDevices.Count == 0)
			{
				StatusLabel.Text = AppStrings.NoDevicesFound;
			}
		}
		catch (Exception ex)
		{
			StatusLabel.Text = $"{AppStrings.ScanError}: {ex.Message}";
		}
	}

	private void OnDeviceDiscovered(object? sender, Plugin.BLE.Abstractions.EventArgs.DeviceEventArgs e)
	{
		MainThread.BeginInvokeOnMainThread(() =>
		{
			var name = string.IsNullOrWhiteSpace(e.Device.Name)
				? AppStrings.UnnamedDevice
				: e.Device.Name;

			var macAddress = e.Device.Id.ToString();

			var alreadyExists = _discoveredDevices.Any(d => d.MacAddress == macAddress);
			if (alreadyExists)
			{
				return;
			}

			_discoveredDevices.Add(new DiscoveredBluetoothDevice
			{
				Name = name,
				MacAddress = macAddress
			});

			DiscoveredDevicesView.ItemsSource = null;
			DiscoveredDevicesView.ItemsSource = _discoveredDevices;
		});
	}

	private void OnSaveDiscoveredDeviceClicked(object? sender, EventArgs e)
	{
		if (sender is not Button button || button.CommandParameter is not string macAddress)
		{
			return;
		}

		var device = _discoveredDevices.FirstOrDefault(d => d.MacAddress == macAddress);
		if (device is null)
		{
			return;
		}

		var alreadySaved = _savedDevices.Any(d => d.MacAddress == macAddress);
		if (alreadySaved)
		{
			StatusLabel.Text = AppStrings.DeviceAlreadySaved;
			return;
		}

		_savedDevices.Add(new SavedBluetoothDevice
		{
			Name = device.Name,
			MacAddress = device.MacAddress,
			IsFavorite = true,
			IsAutoConnect = false
		});

		SettingsService.SaveSavedDevices(_savedDevices);
		LoadSavedDevicesToUi();

		StatusLabel.Text = AppStrings.DeviceSaved;
	}

	private void LoadSavedDevicesToUi()
	{
		_savedDevices = SettingsService.LoadSavedDevices();
		SavedDevicesView.ItemsSource = null;
		SavedDevicesView.ItemsSource = _savedDevices;
	}
}