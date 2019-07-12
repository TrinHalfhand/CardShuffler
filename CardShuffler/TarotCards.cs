using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CardShuffler
{
    //Database
    public class TarotCards
    {
        public enum Cups
        {
            [Description("Ace of Cups: New love or closer relationship")]
            Ace,
            [Description("Two: Union of people, ideas, or talents")]
            Two,
            [Description("Three: connection")]
            Three,
            [Description("Four: opportunity that should not be missed")]
            Four,
            [Description("Five: Disturbance")]
            Five,
            [Description("Six: Harmony")]
            Six,
            [Description("Seven: Mystery")]
            Seven,
            [Description("Eight: Movement")]
            Eight,
            [Description("Nine: Growth")]
            Nine,
            [Description("Ten: Completion")]
            Ten,
            [Description("")]
            Knave,
            [Description("")]
            Queen,
            [Description("")]
            King
        }

        public enum Pentacles
        {
            [Description("")]
            Ace,
            [Description("Two: Balance")]
            Two,
            [Description("Three: Connection")]
            Three,
            [Description("Four: Stability")]
            Four,
            [Description("Five: Disturbance")]
            Five,
            [Description("Six: Harmony")]
            Six,
            [Description("Seven: Mystery")]
            Seven,
            [Description("Eight: Movement")]
            Eight,
            [Description("Nine: Growth")]
            Nine,
            [Description("Ten: Completion")]
            Ten,
            [Description("")]
            Jack,
            [Description("")]
            Queen,
            [Description("")]
            King
        }

        public enum Wands
        {
            [Description("Ace of Wands: New Inspiration and Mental Energy")]
            Ace,
            [Description("Two: Balance")]
            Two,
            [Description("Three: Connection")]
            Three,
            [Description("Four: Stability")]
            Four,
            [Description("Five: Disturbance")]
            Five,
            [Description("Six: Harmony")]
            Six,
            [Description("Seven: Mystery")]
            Seven,
            [Description("Eight: Movement")]
            Eight,
            [Description("Nine: Growth")]
            Nine,
            [Description("Ten: Completion")]
            Ten,
            [Description("")]
            Jack,
            [Description("")]
            Queen,
            [Description("")]
            King
        }

        public enum Swords
        {
            [Description("")]
            Ace,
            [Description("Two: Balance")]
            Two,
            [Description("Three: Connection")]
            Three,
            [Description("Four: Stability")]
            Four,
            [Description("Five: Disturbance")]
            Five,
            [Description("Six: Harmony")]
            Six,
            [Description("Seven: Mystery")]
            Seven,
            [Description("Eight: Movement")]
            Eight,
            [Description("Nine: Growth")]
            Nine,
            [Description("Ten: Completion")]
            Ten,
            [Description("Knave of Swords: Someone on a mission")]
            Knave,
            [Description("")]
            Queen,
            [Description("")]
            King
        }
    }
}
