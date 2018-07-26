using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;

namespace WindBot.Game.AI.Decks
{
    [Deck("Bujin", "AI_Bujin", "Normal")]
    public class BujinExecutor : DefaultExecutor
    {
        public class CardId
        {
            public const int BujinHiruko = 70026064;
            public const int BujinHirume = 9418365;
            public const int BujinMikazuchi = 53678698;
            public const int BujinYamato = 32339440;
            public const int BujingiTurtle = 5818294;
            public const int BujingiHare = 59251766;
            public const int BujinArasuda = 23979249;
            public const int BujingiQuilin = 69723159;
            public const int BujingiCrane = 68601507;
            public const int Honest = 37742478;
            public const int RescueRabbit = 85138716;

            public const int TiesOfTheBrethren = 40450317;
            public const int Bujincarnation = 73906480;
            public const int PotOfDuality = 98645731;
            public const int CosmicCyclone = 8267140;
            public const int KaiserCilisseum = 35059553;
            public const int FireFormationTenki = 57103969;

            public const int DrowningMirrorForce = 47475363;
            public const int SolemnStrike = 40605147;

            public const int NumberS39Utopia = 56832966;
            public const int BujinkiAmaterasu = 68618157;
            public const int BujinteiKagutsuchi = 1855932;
            public const int Number39Utopia = 84013237;
            public const int BujinteiSusanowo = 75840616;
            public const int TornadoDragon = 6983839;
            public const int Number41Bagooska = 90590303;
            public const int TheSkyblasterMusketeer = 82633039;
            public const int EvilswarmExcitonKnight = 46772449;
            public const int BujinteiTsukuyomi = 73289035;
            public const int AbyssDweller = 21044178;
            public const int CoderTalker = 53413628;
            
        }

        public BujinExecutor(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            AddExecutor(ExecutorType.SpSummon);
            AddExecutor(ExecutorType.Activate, DefaultDontChainMyself);
            AddExecutor(ExecutorType.SummonOrSet);
            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);
            AddExecutor(ExecutorType.SpellSet);
        }
        

    }
}