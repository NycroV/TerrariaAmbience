using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerrariaAmbience.Content.Players;
using Terraria.Audio;

namespace TerrariaAmbience.Content
{
    public class CraftSounds : GlobalItem
    {
        public override bool InstancePerEntity => true;
        /// <summary>
        /// A list containing all ANVILS. Add to this if you wish, mods out there.
        /// </summary>
        public static List<int> anvils = new List<int>
        {
            TileID.Anvils,
            TileID.MythrilAnvil
        };
        /// <summary>
        /// A list containing all WORK BENCHES. Add to this if you wish, mods out there.
        /// </summary>
        public static List<int> workBenches = new List<int>
        {
            TileID.WorkBenches,
            TileID.HeavyWorkBench,
            TileID.TinkerersWorkbench
        }; // Are good
        /// <summary>
        /// A list containing all FURNACES. Add to this if you wish, mods out there. (By default, no sounds connected)
        /// </summary>
        public static List<int> furnaces = new List<int>
        {
            TileID.Furnaces,
            TileID.LihzahrdFurnace
        };
        /// <summary>
        /// A list containing all BOOK RELATED THINGS. Add to this if you wish, mods out there. (By default, no sounds connected)
        /// </summary>
        public static List<int> books = new List<int>
        {
            TileID.Bookcases,
            TileID.Books
        };
        [Obsolete("Do not use for the time being- it is being finalized.")]
        public static string WorkBenchesSoundDir { get => $"{Ambience.AmbientPath}/player/crafting_workbenches"; }
        public static string AnvilsSoundDir { get => $"{Ambience.AmbientPath}/player/crafting_anvils"; }
        public static string BooksSoundDir { get => $"{Ambience.AmbientPath}/player/crafting_bookrelated"; }
        /*public override void OnCreate(Item item, ItemCreationContext context)
        {
            Player player = Main.player[Main.myPlayer].GetModPlayer<FootstepsPlayer>().Player;
            FootstepsPlayer aPlayer = Main.player[Main.myPlayer].GetModPlayer<FootstepsPlayer>();
            // var pket = mod.GetPacket();
            bool craftWithAnvil = anvils.Intersect(recipe.requiredTile).Any();
            bool craftWithWB = workBenches.Intersect(recipe.requiredTile).Any();
            bool craftWithFurnace = furnaces.Intersect(recipe.requiredTile).Any();
            bool craftWithBook = books.Intersect(recipe.requiredTile).Any();

            if (craftWithAnvil)
            {
                aPlayer.playerCraftType = 1;
                SoundEngine.PlaySound(new ModSoundStyle(AnvilsSoundDir), player.Center).Volume *= .8f;
            }
            if (craftWithWB)
            {
                aPlayer.playerCraftType = 2;
                SoundEngine.PlaySound(new ModSoundStyle(WorkBenchesSoundDir), player.Center).Volume *= .8f;
            }
            /*if (craftWithFurnace)
            {
                aPlayer.playerCraftType = 3;
                if (FurnaceSoundDir != default)
                {
                    Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, FurnaceSoundDir), player.Center).Volume *= .8f;
                }
            }
            if (craftWithBook)
            {
                aPlayer.playerCraftType = 4;
                SoundEngine.PlaySound(new ModSoundStyle(BooksSoundDir), player.Center).Volume *= .8f;
            }
            if (recipe.needWater || recipe.needHoney)
            {
                SoundEngine.PlaySound(SoundID.Splash, player.Center);
            }
        }*/
        public static void AddCraftingStationsToList(List<int> stationType, params int[] stations)
        {
            foreach (int station in stations)
            {
                stationType.Add(station);
            }
        }
    }
}
