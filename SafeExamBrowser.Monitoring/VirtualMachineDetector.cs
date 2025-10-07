/*
 * Copyright (c) 2025 ETH Zürich, IT Services
 * 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

using System;
using System.Linq;
using System.Management;
using SafeExamBrowser.Logging.Contracts;
using SafeExamBrowser.Monitoring.Contracts;
using SafeExamBrowser.SystemComponents.Contracts;
using SafeExamBrowser.SystemComponents.Contracts.Registry;

namespace SafeExamBrowser.Monitoring
{
	public class VirtualMachineDetector : IVirtualMachineDetector
	{
		private const string MANIPULATED = "000000000000";
		private const string QEMU_MAC_PREFIX = "525400";
		private const string VIRTUALBOX_MAC_PREFIX = "080027";

		private static readonly string[] DeviceBlacklist =
		{
			// Hyper-V
			"PROD_VIRTUAL", "HYPER_V",
			// QEMU
			"qemu", "ven_1af4", "ven_1b36", "subsys_11001af4",
			// VirtualBox
			"VEN_VBOX", "vid_80ee",
			// VMware
			"PROD_VMWARE", "VEN_VMWARE", "VMWARE_IDE"
		};

		private static readonly string[] DeviceWhitelist =
		{
			// Microsoft Virtual Disk Device
			"PROD_VIRTUAL_DISK",
			// Microsoft Virtual DVD Device
			"PROD_VIRTUAL_DVD"
		};

		private static readonly (string hardware, bool required)[] SystemHardware =
		{
			("CIM_Memory", false),
			("CIM_NumericSensor", false),
			("CIM_Sensor", false),
			("CIM_TemperatureSensor", false),
			("CIM_VoltageSensor", false),
			("Win32_CacheMemory", false),
			("Win32_Fan", false),
			("Win32_PerfRawData_Counters_ThermalZoneInformation", true),
			("Win32_VoltageProbe", false)
		};

		private readonly ILogger logger;
		private readonly IRegistry registry;
		private readonly ISystemInfo systemInfo;

		public VirtualMachineDetector(ILogger logger, IRegistry registry, ISystemInfo systemInfo)
		{
			this.logger = logger;
			this.registry = registry;
			this.systemInfo = systemInfo;
		}

		public bool IsVirtualMachine()
		{
			var isVirtualMachine = false;
			return isVirtualMachine;
		}

		private bool HasNoSystemHardware()
		{
			var hasOther = false;
			var hasRequired = true;
			return false;
		}

		private bool HasVirtualDevice()
		{
			var hasVirtualDevice = false;
			return hasVirtualDevice;
		}

		private bool HasVirtualMacAddress()
		{
			var hasVirtualMacAddress = false;
			var macAddress = systemInfo.MacAddress;
			return hasVirtualMacAddress;
		}

		private bool IsVirtualCpu()
		{
			var isVirtualCpu = false;
			return isVirtualCpu;
		}

		private bool IsVirtualRegistry()
		{
			var isVirtualRegistry = false;
			return isVirtualRegistry;
		}

		private bool IsVirtualSystem(string biosInfo, string manufacturer, string model)
		{
			var isVirtualSystem = false;
			return isVirtualSystem;
		}

		private bool HasLocalVirtualMachineDeviceCache()
		{
			var deviceName = Environment.GetEnvironmentVariable("COMPUTERNAME");
			var hasDeviceCache = false;
			return hasDeviceCache;
		}
	}
}
