﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;

namespace TerrariaAmbience
{
    public class Ambience
    {
        // I really wished that using a list or an array for these values could affect them, through experimentation, I realized..
        // No, it's not gonna work. :/

        // In hindsight, I realize that this code could be ultra-optimised, but I'll do that when I have the time to, since I am/was on
        // spring break as of writing this code.
        
        // If someone wants to PR to this repository, it is welcome as long as you don't ruin anything :)

        #region Forest SFX

        public SoundEffect DayCrickets { get; set; }
        public SoundEffectInstance DayCricketsInstance { get; set; }
        public SoundEffect EveningCrickets { get; set; }
        public SoundEffectInstance EveningCricketsInstance { get; set; }
        public SoundEffect NightCrickets { get; set; }
        public SoundEffectInstance NightCricketsInstance { get; set; }

        #endregion
        #region Jungle SFX

        public SoundEffect DayJungle { get; set; }
        public SoundEffectInstance DaytimeJungleInstance { get; set; }
        public SoundEffect NightJungle { get; set; }
        public SoundEffectInstance NightJungleInstance { get; set; }

        #endregion
        #region Beach SFX

        public SoundEffect BeachWaves { get; set; }
        public SoundEffectInstance BeachWavesInstance { get; set; }

        #endregion
        #region Desert SFX

        public SoundEffect DesertAmbience { get; set; }
        public SoundEffectInstance DesertAmbienceInstance { get; set; }

        #endregion
        #region Caves/Underground SFX

        public SoundEffect CavesAmbience { get; set; }
        public SoundEffectInstance CavesAmbienceInstance { get; set; }

        #endregion
        #region Snow SFX

        public SoundEffect SnowBreezeDay { get; set; }
        public SoundEffectInstance SnowBreezeDayInstance { get; set; }
        public SoundEffect SnowBreezeNight { get; set; }
        public SoundEffectInstance SnowBreezeNightInstance { get; set; }

        #endregion
        #region Hell SFX

        public SoundEffect HellRumble { get; set; }
        public SoundEffectInstance HellRumbleInstance { get; set; }

        #endregion
        #region World Evils SFX

        public SoundEffect CrimsonRumbles { get; set; }
        public SoundEffectInstance CrimsonRumblesInstance { get; set; }
        public SoundEffect CorruptionRoars { get; set; }
        public SoundEffectInstance CorruptionRoarsInstance { get; set; }

        #endregion

        #region Other Ambience

        public SoundEffect CampfireCrackle { get; set; }
        public SoundEffectInstance CampfireCrackleInstance { get; set; }

        public SoundEffect Drip1 { get; set; }
        public SoundEffect Drip2 { get; set; }
        public SoundEffect Drip3 { get; set; }
        public SoundEffectInstance Drip1Instance { get; set; }
        public SoundEffectInstance Drip2Instance { get; set; }
        public SoundEffectInstance Drip3Instance { get; set; }

        public SoundEffect LavaStream { get; set; }
        public SoundEffect WaterStream { get; set; }
        public SoundEffectInstance LavaStreamInstance { get; set; }
        public SoundEffectInstance WaterStreamInstance { get; set; }

        public SoundEffect Rain { get; set; }
        public SoundEffectInstance RainInstance { get; set; }

        #endregion

        public float dayCricketsVolume;
        public float eveningCricketsVolume;
        public float nightCricketsVolume;
        public float crackleVolume;
        public float desertCricketsVolume;
        public float ugAmbienceVolume;
        public float snowDayVolume;
        public float snowNightVolume;
        public float crimsonRumblesVolume;
        public float corruptionRoarsVolume;
        public float dayJungleVolume;
        public float nightJungleVolume;
        public float beachWavesVolume;
        public float hellRumbleVolume;
        public float rainVolume;

        public static Ambience Instance
        {
            get
            {
                return ModContent.GetInstance<Ambience>();
            }
        }
        private SoundEffect runSFX_Cashe;
        private SoundEffect[] drip_Cashe = new SoundEffect[] { };
        private SoundEffect[] liquid_Cashe = new SoundEffect[] { };

        private SoundEffectInstance[] dripInstance_Cashe = new SoundEffectInstance[] { };
        private SoundEffectInstance[] liquidInstance_Cashe = new SoundEffectInstance[] { };

        public static string ambienceDirectory = "Sounds/Custom/ambient";

        public static void Initialize()
        {
            var mod = ModContent.GetInstance<TerrariaAmbience>();

            ContentInstance.Register(new Ambience());

            var loader = Instance;

            loader.DayCrickets = mod.GetSound($"{ambienceDirectory}/biome/forest_day");
            loader.DayCricketsInstance = loader.DayCrickets.CreateInstance();
            loader.DayCrickets.Name = "Daytime Crickets";
            loader.EveningCrickets = mod.GetSound($"{ambienceDirectory}/biome/forest_evening");
            loader.EveningCricketsInstance = loader.DayCrickets.CreateInstance();
            loader.EveningCrickets.Name = "Evening Crickets";
            loader.NightCrickets = mod.GetSound($"{ambienceDirectory}/biome/forest_night");
            loader.NightCricketsInstance = loader.NightCrickets.CreateInstance();
            loader.NightCrickets.Name = "Night Crickets";

            loader.DesertAmbience = mod.GetSound($"{ambienceDirectory}/biome/desert_crickets");
            loader.DesertAmbienceInstance = Instance.DesertAmbience.CreateInstance();
            loader.DesertAmbience.Name = "Desert Crickets";
;
            loader.CampfireCrackle = mod.GetSound($"{ambienceDirectory}/environment/campfire_crackle");
            loader.CampfireCrackleInstance = loader.CampfireCrackle.CreateInstance();
            loader.CampfireCrackle.Name = "Campfire Embers";

            loader.CavesAmbience = mod.GetSound($"{ambienceDirectory}/biome/ug_drip");
            loader.CavesAmbienceInstance = loader.CavesAmbience.CreateInstance();
            loader.CavesAmbience.Name = "Caves/Underground Ambience";

            loader.SnowBreezeDay = mod.GetSound($"{ambienceDirectory}/biome/snowfall_day");
            loader.SnowBreezeDayInstance = loader.SnowBreezeDay.CreateInstance();
            loader.SnowBreezeDay.Name = "Daytime Snowfall";

            loader.SnowBreezeNight = mod.GetSound($"{ambienceDirectory}/biome/snowfall_night");
            loader.SnowBreezeNightInstance = loader.SnowBreezeNight.CreateInstance();
            loader.SnowBreezeNight.Name = "Night Snowfall";

            loader.CrimsonRumbles = mod.GetSound($"{ambienceDirectory}/biome/crimson_rumbles");
            loader.CrimsonRumblesInstance = loader.CrimsonRumbles.CreateInstance();
            loader.CrimsonRumbles.Name = "Crimson Rumbles";

            loader.CorruptionRoars = mod.GetSound($"{ambienceDirectory}/biome/corruption_roars");
            loader.CorruptionRoarsInstance = loader.CorruptionRoars.CreateInstance();
            loader.CorruptionRoars.Name = "Corruption Roars";

            loader.DayJungle = mod.GetSound($"{ambienceDirectory}/biome/jungle_day");
            loader.DaytimeJungleInstance = loader.DayJungle.CreateInstance();
            loader.DayJungle.Name = "Daytime Jungle";
            loader.NightJungle = mod.GetSound($"{ambienceDirectory}/biome/jungle_night");
            loader.NightJungleInstance = loader.NightJungle.CreateInstance();
            loader.NightJungle.Name = "Night Jungle";

            loader.BeachWaves = mod.GetSound($"{ambienceDirectory}/biome/beach_waves");
            loader.BeachWavesInstance = loader.BeachWaves.CreateInstance();
            loader.BeachWaves.Name = "Beach Waves";

            loader.HellRumble = mod.GetSound($"{ambienceDirectory}/biome/hell_rumble");
            loader.HellRumbleInstance = loader.HellRumble.CreateInstance();
            loader.HellRumble.Name = "Hell Rumbling";

            loader.Drip1 = mod.GetSound($"{ambienceDirectory}/environment/liquid_drip1");
            loader.Drip2 = mod.GetSound($"{ambienceDirectory}/environment/liquid_drip2");
            loader.Drip3 = mod.GetSound($"{ambienceDirectory}/environment/liquid_drip3");
            loader.Drip1Instance = loader.Drip1.CreateInstance();
            loader.Drip2Instance = loader.Drip2.CreateInstance();
            loader.Drip3Instance = loader.Drip3.CreateInstance();

            loader.LavaStream = mod.GetSound($"{ambienceDirectory}/environment/stream_lava");
            loader.WaterStream = mod.GetSound($"{ambienceDirectory}/environment/stream_water");
            loader.LavaStreamInstance = loader.LavaStream.CreateInstance();
            loader.WaterStreamInstance = loader.WaterStream.CreateInstance();

            loader.Rain = mod.GetSound($"{ambienceDirectory}/environment/rain_new");
            loader.RainInstance = loader.Rain.CreateInstance();

            loader.DayCricketsInstance.IsLooped = true;
            loader.EveningCricketsInstance.IsLooped = true;
            loader.NightCricketsInstance.IsLooped = true;
            loader.CampfireCrackleInstance.IsLooped = true;
            loader.DesertAmbienceInstance.IsLooped = true;
            loader.CavesAmbienceInstance.IsLooped = true;
            loader.SnowBreezeDayInstance.IsLooped = true;
            loader.SnowBreezeNightInstance.IsLooped = true;
            loader.CrimsonRumblesInstance.IsLooped = true;
            loader.CorruptionRoarsInstance.IsLooped = true;
            loader.DaytimeJungleInstance.IsLooped = true;
            loader.NightJungleInstance.IsLooped = true;
            loader.BeachWavesInstance.IsLooped = true;
            loader.HellRumbleInstance.IsLooped = true;
            loader.RainInstance.IsLooped = true;
            loader.LavaStreamInstance.IsLooped = true;
            loader.WaterStreamInstance.IsLooped = true;

            #region SFX Changes

            loader.runSFX_Cashe = Main.soundRun;
            loader.drip_Cashe = Main.soundDrip;
            loader.liquid_Cashe = Main.soundLiquid;

            loader.liquidInstance_Cashe = Main.soundInstanceLiquid;
            loader.dripInstance_Cashe = Main.soundInstanceDrip;

            // Now change the sound (Main.soundX = y)

            // NOTE: drip.Len = 3 (0, 1 ,2) (3 different variants)
            // NOTE: liquid.Len = 2 (0, 1) (0 == Water | 1 == Lava)

            Main.soundDrip[0] = loader.Drip1;
            Main.soundDrip[1] = loader.Drip2;
            Main.soundDrip[2] = loader.Drip3;

            Main.soundLiquid[0] = loader.WaterStream;
            Main.soundLiquid[1] = loader.LavaStream;

            Main.soundInstanceDrip[0] = loader.Drip1Instance;
            Main.soundInstanceDrip[1] = loader.Drip2Instance;
            Main.soundInstanceDrip[2] = loader.Drip3Instance;

            Main.soundInstanceLiquid[0] = loader.WaterStreamInstance;
            Main.soundInstanceLiquid[1] = loader.LavaStreamInstance;

            #endregion
        }
        public static void Unload()
        {
            Main.soundRun = Instance.runSFX_Cashe;
            Main.soundDrip = Instance.drip_Cashe;
            Main.soundLiquid = Instance.liquid_Cashe;

            Main.soundInstanceDrip = Instance.dripInstance_Cashe;
            Main.soundInstanceLiquid = Instance.liquidInstance_Cashe;
        }
        public static void PlayAllAmbience()
        {
            Instance.DayCricketsInstance?.Play();
            Instance.EveningCricketsInstance?.Play();
            Instance.NightCricketsInstance?.Play();
            Instance.CampfireCrackleInstance?.Play();
            Instance.DesertAmbienceInstance?.Play();
            Instance.CavesAmbienceInstance?.Play();
            Instance.SnowBreezeDayInstance?.Play();
            Instance.SnowBreezeNightInstance?.Play();
            Instance.CrimsonRumblesInstance?.Play();
            Instance.CorruptionRoarsInstance?.Play();
            Instance.DaytimeJungleInstance?.Play();
            Instance.NightJungleInstance?.Play();
            Instance.BeachWavesInstance?.Play();
            Instance.HellRumbleInstance?.Play();
            Instance.RainInstance?.Play();
        }
        private bool playerBehindWall;
        private bool playerInLiquid;
        public static void DoUpdate_Ambience()
        {
            Terraria.ModLoader.Audio.Music rainSFX = Main.music[Terraria.ID.MusicID.RainSoundEffect];
            if (rainSFX.IsPlaying)
            {
                rainSFX?.Pause();
                rainSFX?.SetVariable("Volume", 0f);
            }
            if (!Instance.playerBehindWall)
            {
                Instance.DayCricketsInstance.Volume = Instance.dayCricketsVolume * 0.65f * Main.ambientVolume;
                Instance.EveningCricketsInstance.Volume = Instance.eveningCricketsVolume * 0.65f * Main.ambientVolume;
                Instance.NightCricketsInstance.Volume = Instance.nightCricketsVolume * 0.65f * Main.ambientVolume;
                Instance.DesertAmbienceInstance.Volume = Instance.desertCricketsVolume * 0.65f * Main.ambientVolume;
                Instance.CavesAmbienceInstance.Volume = Instance.ugAmbienceVolume * 0.65f * Main.ambientVolume;
                Instance.CrimsonRumblesInstance.Volume = Instance.crimsonRumblesVolume * 0.5f * Main.ambientVolume;
                Instance.CorruptionRoarsInstance.Volume = Instance.corruptionRoarsVolume * 0.5f * Main.ambientVolume;

                Instance.HellRumbleInstance.Volume = Instance.hellRumbleVolume * 0.6f * Main.ambientVolume;

                Instance.BeachWavesInstance.Volume = Instance.beachWavesVolume * 0.75f * Main.ambientVolume;

                Instance.DaytimeJungleInstance.Volume = Instance.dayJungleVolume * 0.5f * Main.ambientVolume;
                Instance.NightJungleInstance.Volume = Instance.nightJungleVolume * 0.5f * Main.ambientVolume;

                Instance.SnowBreezeDayInstance.Volume = Instance.snowDayVolume * 0.7f * Main.ambientVolume;
                Instance.SnowBreezeNightInstance.Volume = Instance.snowNightVolume * 0.7f * Main.ambientVolume;

                if (Instance.crackleVolume >= 0f && Instance.crackleVolume <= 1f)
                    Instance.CampfireCrackleInstance.Volume = Instance.crackleVolume * 0.95f * Main.soundVolume;
            }
            else
            {

                Instance.DayCricketsInstance.Volume = Instance.dayCricketsVolume * 0.4f * Main.ambientVolume;
                Instance.EveningCricketsInstance.Volume = Instance.eveningCricketsVolume * 0.4f * Main.ambientVolume;
                Instance.NightCricketsInstance.Volume = Instance.nightCricketsVolume * 0.4f * Main.ambientVolume;
                Instance.DesertAmbienceInstance.Volume = Instance.desertCricketsVolume * 0.4f * Main.ambientVolume;
                Instance.CavesAmbienceInstance.Volume = Instance.ugAmbienceVolume * 0.4f * Main.ambientVolume;
                Instance.CrimsonRumblesInstance.Volume = Instance.crimsonRumblesVolume * 0.3f * Main.ambientVolume;
                Instance.CorruptionRoarsInstance.Volume = Instance.corruptionRoarsVolume * 0.3f * Main.ambientVolume;

                Instance.HellRumbleInstance.Volume = Instance.hellRumbleVolume * 0.5f * Main.ambientVolume;

                Instance.BeachWavesInstance.Volume = Instance.beachWavesVolume * 0.5f * Main.ambientVolume;

                Instance.DaytimeJungleInstance.Volume = Instance.dayJungleVolume * 0.35f * Main.ambientVolume;
                Instance.NightJungleInstance.Volume = Instance.nightJungleVolume * 0.35f * Main.ambientVolume;

                Instance.SnowBreezeDayInstance.Volume = Instance.snowDayVolume * 0.45f * Main.ambientVolume;
                Instance.SnowBreezeNightInstance.Volume = Instance.snowNightVolume * 0.45f * Main.ambientVolume;

                if (Instance.crackleVolume >= 0f && Instance.crackleVolume <= 1f)
                    Instance.CampfireCrackleInstance.Volume = Instance.crackleVolume * 0.8f * Main.soundVolume;
            }
            if (!Instance.playerBehindWall && !Instance.playerInLiquid)
            {
                Instance.RainInstance.Volume = Instance.rainVolume * 0.6f * Main.ambientVolume;
            }
            else if (Instance.playerInLiquid && !Instance.playerBehindWall)
            {
                Instance.RainInstance.Volume = Instance.rainVolume * 0.2f * Main.ambientVolume;
            }
            else if (Instance.playerBehindWall && !Instance.playerInLiquid)
            {
                Instance.RainInstance.Volume = Instance.rainVolume * 0.4f * Main.ambientVolume;
            }
            else if (Instance.playerBehindWall && Instance.playerInLiquid)
            {
                Instance.RainInstance.Volume = Instance.rainVolume * 0.05f * Main.ambientVolume;
            }

            // Main.NewText(Instance.crackleVolume * 0.95f * Main.soundVolume);

            if (Main.gameMenu) return;
            Player player = Main.player[Main.myPlayer]?.GetModPlayer<AmbiencePlayer>().player;

            if (Main.tile[(int)player.Top.X / 16, (int)(player.Top.Y - 1.25) / 16].liquid > 0)
            {
                Instance.playerInLiquid = true;
                Instance.dayCricketsVolume *= 0.85f;
                Instance.eveningCricketsVolume *= 0.85f;
                Instance.nightCricketsVolume *= 0.85f;
                Instance.desertCricketsVolume *= 0.85f;
                Instance.ugAmbienceVolume *= 0.85f;
                Instance.crackleVolume *= 0.85f;
                Instance.snowNightVolume *= 0f;
                Instance.snowDayVolume *= 0f;
                Instance.crimsonRumblesVolume *= 0.9f;
                Instance.corruptionRoarsVolume *= 0.9f;
                Instance.dayJungleVolume *= 0.9f;
                Instance.nightJungleVolume *= 0.9f;
                Instance.hellRumbleVolume *= 0.95f;
                Main.soundInstanceDrip[0].Volume = 0.5f;
                Main.soundInstanceDrip[1].Volume = 0.5f;
                Main.soundInstanceDrip[2].Volume = 0.5f;

                Instance.NightCricketsInstance.Pitch = -0.25f;
                Instance.DayCricketsInstance.Pitch = -0.25f;
                Instance.EveningCricketsInstance.Pitch = -0.25f;
                Instance.CampfireCrackleInstance.Pitch = -0.15f;
                Instance.DesertAmbienceInstance.Pitch = -0.25f;
                Instance.CavesAmbienceInstance.Pitch = -0.25f;
                Instance.CrimsonRumblesInstance.Pitch = -0.25f;
                Instance.CorruptionRoarsInstance.Pitch = -0.25f;
                Instance.DaytimeJungleInstance.Pitch = -0.25f;
                Instance.NightJungleInstance.Pitch = -0.25f;
                Instance.BeachWavesInstance.Pitch = 0.1f;
                Instance.HellRumbleInstance.Pitch = -0.3f;

                Main.soundInstanceDrip[0].Pitch = -0.25f;
                Main.soundInstanceDrip[1].Pitch = -0.25f;
                Main.soundInstanceDrip[2].Pitch = -0.25f;
            }
            else
            {
                Instance.playerInLiquid = false;
                Instance.NightCricketsInstance.Pitch = 0f;
                Instance.DayCricketsInstance.Pitch = 0f;
                Instance.EveningCricketsInstance.Pitch = 0f;
                Instance.CampfireCrackleInstance.Pitch = 0f;
                Instance.DesertAmbienceInstance.Pitch = 0f;
                Instance.CavesAmbienceInstance.Pitch = 0f;
                Instance.CrimsonRumblesInstance.Pitch = 0f;
                Instance.CorruptionRoarsInstance.Pitch = -0f;
                Instance.DaytimeJungleInstance.Pitch = 0f;
                Instance.NightJungleInstance.Pitch = 0f;
                Instance.BeachWavesInstance.Pitch = 0f;
                Instance.HellRumbleInstance.Pitch = 0f;
                Main.soundInstanceDrip[0].Pitch = 0f;
                Main.soundInstanceDrip[1].Pitch = 0f;
                Main.soundInstanceDrip[2].Pitch = 0f;
            }

            if (Main.tile[(int)player.Top.X / 16, (int)player.Top.Y / 16].wall > 0)
            {
                Instance.playerBehindWall = true;
            }
            else
            {
                Instance.playerBehindWall = false;
            }
        }
        /// <summary>
        /// Oddly enough, MathHelper.Clamp is completely useless in this case since it works every 2 frames or something akin to that.
        /// </summary>
        public static void ClampAll()
        {
            var aLoader = Instance;
            if (aLoader.rainVolume > 1)
            {
                aLoader.rainVolume = 1;
            }
            if (aLoader.rainVolume < 0)
            {
                aLoader.rainVolume = 0;
            }
            if (aLoader.dayJungleVolume > 1)
            {
                aLoader.dayJungleVolume = 1;
            }
            if (aLoader.dayJungleVolume < 0)
            {
                aLoader.dayJungleVolume = 0;
            }
            if (aLoader.nightJungleVolume > 1)
            {
                aLoader.nightJungleVolume = 1;
            }
            if (aLoader.nightJungleVolume < 0)
            {
                aLoader.nightJungleVolume = 0;
            }

            if (aLoader.dayCricketsVolume > 1)
            {
                aLoader.dayCricketsVolume = 1;
            }
            if (aLoader.dayCricketsVolume < 0)
            {
                aLoader.dayCricketsVolume = 0;
            }

            if (aLoader.eveningCricketsVolume > 1)
            {
                aLoader.eveningCricketsVolume = 1;
            }
            if (aLoader.eveningCricketsVolume < 0)
            {
                aLoader.eveningCricketsVolume = 0;
            }

            if (aLoader.nightCricketsVolume > 1)
            {
                aLoader.nightCricketsVolume = 1;
            }
            if (aLoader.nightCricketsVolume < 0)
            {
                aLoader.nightCricketsVolume = 0;
            }
            if (aLoader.crackleVolume > 1)
            {
                aLoader.crackleVolume = 1;
            }
            if (aLoader.crackleVolume < 0)
            {
                aLoader.crackleVolume = 0;
            }

            if (aLoader.desertCricketsVolume > 1)
            {
                aLoader.desertCricketsVolume = 1;
            }
            if (aLoader.desertCricketsVolume < 0)
            {
                aLoader.desertCricketsVolume = 0;
            }

            if (aLoader.ugAmbienceVolume > 1)
            {
                aLoader.ugAmbienceVolume = 1;
            }
            if (aLoader.ugAmbienceVolume < 0)
            {
                aLoader.ugAmbienceVolume = 0;
            }

            if (aLoader.snowNightVolume > 1)
            {
                aLoader.snowNightVolume = 1;
            }
            if (aLoader.snowNightVolume < 0)
            {
                aLoader.snowNightVolume = 0;
            }
            if (aLoader.snowDayVolume > 1)
            {
                aLoader.snowDayVolume = 1;
            }
            if (aLoader.snowDayVolume < 0)
            {
                aLoader.snowDayVolume = 0;
            }

            if (aLoader.crimsonRumblesVolume > 1)
            {
                aLoader.crimsonRumblesVolume = 1;
            }
            if (aLoader.crimsonRumblesVolume < 0)
            {
                aLoader.crimsonRumblesVolume = 0;
            }

            if (aLoader.corruptionRoarsVolume > 1)
            {
                aLoader.corruptionRoarsVolume = 1;
            }
            if (aLoader.corruptionRoarsVolume < 0)
            {
                aLoader.corruptionRoarsVolume = 0;
            }

            if (aLoader.beachWavesVolume > 1)
            {
                aLoader.beachWavesVolume = 1;
            }
            if (aLoader.beachWavesVolume < 0)
            {
                aLoader.beachWavesVolume = 0;
            }

            if (aLoader.hellRumbleVolume > 1)
            {
                aLoader.hellRumbleVolume = 1;
            }
            if (aLoader.hellRumbleVolume < 0)
            {
                aLoader.hellRumbleVolume = 0;
            }
        }
    }
}