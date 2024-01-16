using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EndlessContinuum.Common.Globals.World
{
	class Pylon : ModSystem
	{
		public static bool MyrdenshawPylon = false;
		public override void LoadWorldData(TagCompound tag)
		{
			var downed = tag.GetList<string>("downed");
			MyrdenshawPylon = downed.Contains("MyrdenshawPylon");
		}
		public override void SaveWorldData(TagCompound tag)
		{
			tag["MyrdenshawPylon"] = MyrdenshawPylon;
		}
		public override void NetSend(BinaryWriter writer)
		{
			var flags = new BitsByte();
			flags[0] = MyrdenshawPylon;
			writer.Write(flags);
		}
		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			MyrdenshawPylon = flags[0];
		}
		public override void OnWorldLoad()
		{
			MyrdenshawPylon = false;
		}
		public override void OnWorldUnload()
		{
			MyrdenshawPylon = false;
		}
	}
}