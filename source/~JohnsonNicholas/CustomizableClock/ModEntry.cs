﻿using System;
using System.Linq;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Menus;

namespace KN.CustomizableClock
{
    public class ClockConfig
    {
        public bool Is24hClock = false;
        public bool UseJAChar = false;
        public bool UseZHChar = false;
    }


    /// <summary>The mod entry point.</summary>
    public class ModEntry : Mod
    {
        protected ClockConfig ModConfig;

        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            ModConfig = helper.ReadConfig<ClockConfig>();
            TimeEvents.AfterDayStarted += this.TimeEvents_AfterDayStarted;
        }

        /*********
        ** Private methods
        *********/
        /// <summary>The method invoked after a new day starts.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event data.</param>
        private void TimeEvents_AfterDayStarted(object sender, EventArgs e)
        {
            if (!Game1.onScreenMenus.OfType<Clock>().Any())
            {
                DayTimeMoneyBox timeBox = Game1.onScreenMenus.OfType<DayTimeMoneyBox>().First();
                Game1.onScreenMenus.Add(new Clock(timeBox, ModConfig));
            }
        }
    }
}
