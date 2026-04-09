using System;
using System.Collections.Generic;
using System.Text;

namespace BT2MQTT.Models
{
	public class DiscoveredBluetoothDevice
	{
		public string Name { get; set; } = string.Empty;
		public string MacAddress { get; set; } = string.Empty;
	}
}
