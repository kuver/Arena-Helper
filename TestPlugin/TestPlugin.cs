﻿using AHPlugins;
using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.Hearthstone;
using System;
using System.Collections.Generic;

// A test plugin that does something when cards are detected
// Reference ArenaHelper.dll and Hearthstone Deck Tracker
// Place the dll in ArenaHelper/plugins/ in the HDT plugins directory
// Only one plugin can be activated at a time
namespace TestPlugin
{
    public class TestPlugin : AHPlugin
    {
        public override string Name
        {
            get { return "TestPlugin"; }
        }

        public override string Author
        {
            get { return "Rembound.com"; }
        }

        public override Version Version
        {
            get { return new Version("0.0.1"); }
        }

        public TestPlugin()
        {
            // Plugin constructor
            // Setup stuff
            Logger.WriteLine("TestPlugin constructor");
        }

        // Called when three new cards are detected
        // arenadata: The previously detected cards, picked cards and heroes
        // newcards: List of 3 detected cards
        // defaultvalues: List of 3 tier values for the detected cards
        // Return a list of 3 card values and an optional 4th advice value
        public override List<string> GetCardValues(ArenaHelper.Plugin.ArenaData arenadata, List<Card> newcards, List<string> defaultvalues)
        {
            List<string> values = new List<string>();

            // Add the three card values
            for (int i = 0; i < 3; i++)
            {
                values.Add("p" + i.ToString() + " " + defaultvalues[i]);
            }

            // Optionally add an advice as a 4th list element
            values.Add("I don't know, pick one!");

            return values;
        }

        // Called when a new arena is started
        // arendata: As before
        public override void NewArena(ArenaHelper.Plugin.ArenaData arenadata)
        {
            // Do something with the information
            Logger.WriteLine("New Arena: " + arenadata.deckname);
        }

        // Called when the heroes are detected
        // arendata: As before
        // heroname0: name of hero 0
        // heroname1: name of hero 1
        // heroname2: name of hero 2
        public override void HeroesDetected(ArenaHelper.Plugin.ArenaData arenadata, string heroname0, string heroname1, string heroname2)
        {
            // Do something with the information
            Logger.WriteLine("Heroes Detected: " + heroname0 + ", " + heroname1 + ", " + heroname2);
        }

        // Called when a hero is picked
        // arendata: As before
        // heroname: name of the hero
        public override void HeroPicked(ArenaHelper.Plugin.ArenaData arenadata, string heroname)
        {
            // Do something with the information
            Logger.WriteLine("Hero Picked: " + heroname);
        }

        // Called when a card is picked
        // arendata: As before
        // pickindex: index of the picked card in the range -1 to 2, if -1, no valid pick was detected
        // cardid: id of the card like "CS2_029"
        public override void CardPicked(ArenaHelper.Plugin.ArenaData arenadata, int pickindex, string cardid)
        {
            // Do something with the information
            Logger.WriteLine("Card Picked: " + cardid);
        }

        // Called when all cards are picked
        // arendata: As before
        public override void Done(ArenaHelper.Plugin.ArenaData arenadata)
        {
            // Do something with the information
            Logger.WriteLine("Done");
        }
    }
}