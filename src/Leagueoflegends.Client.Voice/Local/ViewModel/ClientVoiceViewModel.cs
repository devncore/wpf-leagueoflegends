﻿using Leagueoflegends.Data.Codes;
using Leagueoflegends.Data.Config;
using Leagueoflegends.Data.Setting.Clients;
using Leagueoflegends.DBEntity.Local.Api;
using Leagueoflegends.DBEntity.Local.Entities.Extend;
using Leagueoflegends.ExampleData.Setting;
using Leagueoflegends.Foundation.Mvvm;
using Leagueoflegends.Foundation.Riotbase;
using System.Collections.Generic;

namespace Leagueoflegends.Client.Voice.Local.ViewModel
{
	public class ClientVoiceViewModel : ObservableObject
	{
		private List<AudioDevice> _deviceList;
		private List<UsualCodes> _inputMode;

		public ClientVoiceModel Model { get; set; }

		#region DeviceList

		public List<AudioDevice> DeviceList
		{
			get => _deviceList;
			set { _deviceList = value; OnPropertyChanged(); }
		}
		#endregion

		#region InputMode

		public List<UsualCodes> InputMode
		{
			get => _inputMode;
			set { _inputMode = value; OnPropertyChanged(); }
		}
		#endregion

		#region Constructor

		public ClientVoiceViewModel()
		{
			DeviceList = ExamSettings.GetAudioDeviceList();
			InputMode = new GetCodeItems().Run("000001");

			ConfigModel config = RiotConfig.LoadConfig();
			Model = config.Settings.ClientVoice;
		}
		#endregion
	}
}
