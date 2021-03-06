﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SpellFire.Well.Controller;
using SpellFire.Well.Net;

namespace SpellFire.Primer.Solutions
{
	public class PacketManip : Solution
	{
		public PacketManip(Client client) : base(client)
		{

			SpellPacket spellPacket = new SpellPacket
			{
				castCount = 0,
				spellID = 20589, // 20589 - escape artist
				castFlags = 0
			};


			client.ControlInterface.remoteControl.SendPacket(spellPacket);

			this.Active = false;
		}

		public override void Tick()
		{
		}

		public override void Dispose()
		{
		}
	}
}
