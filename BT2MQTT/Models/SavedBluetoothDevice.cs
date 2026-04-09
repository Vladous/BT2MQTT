using System;
using System.Collections.Generic;
using System.Text;

namespace BT2MQTT.Models
{
	public class SavedBluetoothDevice
	{
		public string Name { get; set; } = string.Empty;
		public string MacAddress { get; set; } = string.Empty;
		public bool IsFavorite { get; set; }
		public bool IsAutoConnect { get; set; }
	}
}
