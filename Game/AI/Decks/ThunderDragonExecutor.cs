using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;

namespace WindBot.Game.AI.Decks
{
    [Deck("ThunderDragon", "AI_ThunderDragon", "Normal")]
    public class ThunderDragonExecutor : DefaultExecutor
    {
        public class CardId
        {
            public const int AeonThunderDragon = 55591586;
            public const int BeastialThunderDragon = 29596581;
            public const int AviaonThunderDragon = 83107873;
            public const int ThunderDragon = 31786629;
            public const int BoltThunderDragon = 56713174;
            public const int BatterymanSolar = 44586426;
            public const int Batteryman9Volt = 60549248;
            public const int AshBlossom = 14558127;
            public const int Rabbit = 59438930;
            public const int MaxxC = 23434538;
            public const int GlowUpBulb = 67441435;
            public const int OriginThunderDragon = 20318029;
            public const int EffectVeiler = 97268402;
            public const int Sauravis = 4810828;

            public const int InstantFusion = 1845204;
            public const int GoldSarcophagus = 75500286;
            public const int ThunderDragonFusion = 95238394;
            public const int Scapegoat = 73915051;
            public const int InfiniteImpermanence = 10045474;            

            public const int ThunderDragonLord = 41685633;
            public const int SuperboltThunderDragon = 15291624;
            public const int KaminariAttack = 9653271;
            public const int ThousandEyesRestrict = 63519819;
            public const int BorrelswordDragon = 85289965;
            public const int KnightmareUnicorn = 38342335;
            public const int KnightmarePhoenix = 2857636;
            public const int KaminariSummerVacation = 38406364;
            public const int KnightmareCerberus = 75452921;
            public const int CrystronNeedlefiber = 50588353;
            public const int LinkSpider = 98978921;
            public const int Linduriboh = 41999284;

            public const int ThunderDragonStreamer = 18444733;
        }

        public ThunderDragonExecutor(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            //counter

            AddExecutor(ExecutorType.Activate, CardId.EffectVeiler, DefaultEffectVeiler);
            AddExecutor(ExecutorType.Activate, CardId.InfiniteImpermanence, DefaultInfiniteImpermanence);
            AddExecutor(ExecutorType.Activate, CardId.AshBlossom, DefaultAshBlossomAndJoyousSpring);
            AddExecutor(ExecutorType.Activate, CardId.MaxxC, MaxxCeff);
            AddExecutor(ExecutorType.Activate, CardId.Rabbit, DefaultGhostOgreAndSnowRabbit);           

            AddExecutor(ExecutorType.Repos, MonsterRepos);
        }

        private bool MaxxCeff()
        {
            return Duel.Player == 1;
        }
        
        private bool MonsterRepos()
        {            
            return DefaultMonsterRepos();
        }
        public override bool OnSelectHand()
        {
            return true;
        }

    }
}