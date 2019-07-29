using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CardShuffler
{
    //Database
    public class TarotCards
    {
        public enum Suit
        {
            [Description("These cards are linked to the heart and to specific feelings such as love, bliss, melancholy, sorrow.")]
            Cups,
            [Description("These cards are linked to physical or external level of consciousness and thus mirror the outer situations of your health, finances, work, and creativity.")]
            Pentacles,
            [Description("These cards are linked to spirituality, inspiration, determination, strength, intuition, creativity, ambition and expansion, and original thought")]
            Wands,
            [Description("These cards are linked to the mind and intellect. Mirroring the quality of mind present in your thoughts, attitudes, and beliefs")]
            Swords
        }

        public enum Cups
        {
            [Description("Love, new relationships, compassion, creativity")]
            Ace,
            [Description("Unified love, partnership, mutual attraction")]
            Two,
            [Description("Celebration, friendship, creativity, collaborations")]
            Three,
            [Description("Mediation, contemplation, apathy, reevaluation")]
            Four,
            [Description("Regret, failure, disapppointment, pessimism")]
            Five,
            [Description("Revisiting the past, childhood memories, innocence, joy")]
            Six,
            [Description("Opportunities, choices, wishful thinking, illusion")]
            Seven,
            [Description("Disappointment, abandonment, withdrawal, escapism")]
            Eight,
            [Description("Contentment, satisfaction, gratitude, wish come true")]
            Nine,
            [Description("Divine love, blissful relationships, harmony, alignment")]
            Ten,
            [Description("Creative opportunities, intuitive messages, curiosity, possibility")]
            Page,
            [Description("Creativity, romance, charm, imagination, beauty")]
            Knave,
            [Description("Compssionate, caring, emotionally stable, intuitive, in flow")]
            Queen,
            [Description("Emotionally balanced, compassionate, diplomatic")]
            King
        }

        public enum Pentacles
        {
            [Description("A new financial or career opportunity, manifestation, abundance")]
            Ace,
            [Description("Mutiple priorities, time management, prioritisation, adaptability")]
            Two,
            [Description("Teamwork, collaboration, learning, implementation")]
            Three,
            [Description("Saving money, security, conservatism, scarcity, control")]
            Four,
            [Description("Financial loss, poverty, lack mindset, isolation, worry")]
            Five,
            [Description("Giving, receiving, sharing, wealth, generosity, charity")]
            Six,
            [Description("Long-term view, sustainable results, perserverance, investment")]
            Seven,
            [Description("Apprenticeship, repetitive tasks, mastery, skill development")]
            Eight,
            [Description("Abundance, luxury, selfsufficiency, financial independence")]
            Nine,
            [Description("Wealth, financial security, family, long-term success, contribution")]
            Ten,
            [Description("Manifestation, financial opportunity, skill development")]
            Page,
            [Description("Hard work, productivity, routine, conservatism")]
            Knave,
            [Description("Nurturing, practical, providing financially, a working parent")]
            Queen,
            [Description("Wealth, business, leadership, security, discipline, abundance")]
            King
        }

        public enum Wands
        {
            [Description("Inspiration, new opportunities, growth, potential")]
            Ace,
            [Description("Future planning, progress, decisions, discovery")]
            Two,
            [Description("Progress, expansion, forsight, overseas opportunities")]
            Three,
            [Description("Celebration, joy, harmony, relaxation, homecoming")]
            Four,
            [Description("Conflict, disagreements, competition, tension, diversity")]
            Five,
            [Description("Sucess, public recongnition, progress, self-confidence")]
            Six,
            [Description("Challenge, competition, protection, perserverance")]
            Seven,
            [Description("Movement, fast paced change, action, alignment, air travel")]
            Eight,
            [Description("Resilience, courage, persistence, test of faith, boundaries")]
            Nine,
            [Description("Burden, extra responsibility, hard work, completion")]
            Ten,
            [Description("Inspiration, ideas, discovery, limitless potential, free spirit")]
            Page,
            [Description("Energy, passion, inspired action, adventure, impulsiveness")]
            Knave,
            [Description("Courage, confidence, independence, social butterfly, determination")]
            Queen,
            [Description("Natural-born leader, vision, entrepreneur, honour")]
            King
        }

        public enum Swords
        {
            [Description("Breakthroughs, new ideas, mental clarity, success")]
            Ace,
            [Description("Difficult decisions, weighing up options, an impasse, avoidance")]
            Two,
            [Description("Heartbreak, emotional pain, sorrow, grief, hurt")]
            Three,
            [Description("Rest, relaxation, meditation, contemplation, recuperation")]
            Four,
            [Description("Conflict, disagreements, competition, defeat, winning at all costs")]
            Five,
            [Description("Transition, change, rite of passage, releasing baggage")]
            Six,
            [Description("Betrayal, deception, getting away with something, acting strategically")]
            Seven,
            [Description("Negative thoughts, selfimposed restriction, imprisonment, victim mentality")]
            Eight,
            [Description("Anxiety, worry, fear, depression, nightmares")]
            Nine,
            [Description("Painful endings, deep wounds, betrayal, loss, crisis")]
            Ten,
            [Description("New ideas, curiousity, thirst for knowledge, new ways of communicating")]
            Page,
            [Description("Ambitious, action-oriented, driven to succeed, fast-thinking")]
            Knave,
            [Description("Independent, unbiased judgement, clear boundaries, direct communication")]
            Queen,
            [Description("Mental clarity, intellectual power, authority, truth")]
            King
        }

        public class Card
        {
            public Suit CardSuit { get; set; }
            public int CardRank { get; set; }
            public Card(Suit s, int v)
            {
                CardSuit = s;
                CardRank = v;
            }
        }

        public List<Card> Cards { get; set; }

        public TarotCards()
        {
            Cards = new List<Card>();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                //loop each tarot card in the deck
                switch (suit)
                {
                    case Suit.Cups:
                        foreach(Cups cup in Enum.GetValues(typeof(Cups)))
                            Cards.Add(new Card(suit, (int)cup));
                        break;
                    case Suit.Pentacles:
                        foreach (Pentacles pentacle in Enum.GetValues(typeof(Pentacles)))
                            Cards.Add(new Card(suit, (int)pentacle));
                        break;
                    case Suit.Swords:
                        foreach (Swords sword in Enum.GetValues(typeof(Swords)))
                            Cards.Add(new Card(suit, (int)sword));
                        break;
                    case Suit.Wands:
                        foreach (Wands wand in Enum.GetValues(typeof(Wands)))
                            Cards.Add(new Card(suit, (int)wand));
                        break;
                }
            }
        }

        public static string RankMeaning(Card cardToTranslate)
        {
            string rankMeaning = "";

            switch (cardToTranslate.CardSuit)
            {
                case Suit.Cups:
                    rankMeaning = ((TarotCards.Cups)(cardToTranslate.CardRank)).GetRankDescription();
                    break;
                case Suit.Pentacles:
                    rankMeaning = ((TarotCards.Pentacles)(cardToTranslate.CardRank)).GetRankDescription();
                    break;
                case Suit.Wands:
                    rankMeaning = ((TarotCards.Wands)(cardToTranslate.CardRank)).GetRankDescription();
                    break;
                case Suit.Swords:
                    rankMeaning = ((TarotCards.Swords)(cardToTranslate.CardRank)).GetRankDescription();
                    break;
                default:
                    break;
            }

            return rankMeaning;
        }
    }
}
