using Microsoft.Xna.Framework;
using Terraria.Audio;
using Terraria.ModLoader;

namespace EndlessContinuum.Common.Utilities;

abstract class QuickNPC
{
    public static void QuickCritterNPC(ModNPC npc, Vector2 size, int life, int damage, int defense, float kbresist, SoundStyle hit, SoundStyle death, int aiStyle, int slot, bool gravity, int catchItem)
    {
		npc.NPC.Size = size;
		npc.NPC.lifeMax = life;
		npc.NPC.damage = damage;
		npc.NPC.defense = defense;
		npc.NPC.knockBackResist = kbresist;
		npc.NPC.HitSound = hit;
		npc.NPC.DeathSound = death;
		npc.NPC.aiStyle = aiStyle;
		npc.NPC.npcSlots = slot;
		npc.NPC.noGravity = gravity;
		npc.NPC.chaseable = false;
		npc.NPC.catchItem = (short)catchItem;
	}
	public static void QuickEnemyNPC(ModNPC npc, Vector2 size, int life, int damage, int defense, float kbresist, SoundStyle hit, SoundStyle death, int aiStyle, int slot, bool gravity, bool collide, int value)
	{
		npc.NPC.Size = size;
		npc.NPC.lifeMax = life;
		npc.NPC.damage = damage;
		npc.NPC.defense = defense;
		npc.NPC.knockBackResist = kbresist;
		npc.NPC.HitSound = hit;
		npc.NPC.DeathSound = death;
		npc.NPC.aiStyle = aiStyle;
		npc.NPC.npcSlots = slot;
		npc.NPC.noGravity = gravity;
		npc.NPC.noTileCollide = collide;
		npc.NPC.value = value;
	}
}