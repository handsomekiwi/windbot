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
            public const int GhostBelle = 73642296;
            public const int Rabbit = 59438930;
            public const int MaxxC = 23434538;
            public const int GlowUpBulb = 67441435;
            public const int OriginThunderDragon = 20318029;
            public const int EffectVeiler = 97268402;
            public const int Sauravis = 4810828;
            public const int JetSynchron = 9742784;

            public const int UpstartGoblin = 70368879;
            public const int InstantFusion = 1845204;
            public const int OneForOne = 2295440;
            public const int HarpiesFeatherDuster = 18144506;
            public const int CalledByTheGrave = 24224830;
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
            public const int MissusRadiant = 3987233;
            public const int LinkSpider = 98978921;
            public const int Linduriboh = 41999284;
            public const int TopologicBomberDragon = 5821478;
            public const int SummonSorceress = 61665245;
            public const int ThunderDragonStreamer = 18444733;
        }

        public ThunderDragonExecutor(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            //counter
            AddExecutor(ExecutorType.Activate, CardId.GhostBelle, DefaultGhostBelle);
            AddExecutor(ExecutorType.Activate, CardId.CalledByTheGrave, DefaultCalledByTheGrave);
            AddExecutor(ExecutorType.Activate, CardId.EffectVeiler, DefaultEffectVeiler);
            AddExecutor(ExecutorType.Activate, CardId.InfiniteImpermanence, DefaultInfiniteImpermanence);
            AddExecutor(ExecutorType.Activate, CardId.AshBlossom, DefaultAshBlossomAndJoyousSpring);
            AddExecutor(ExecutorType.Activate, CardId.MaxxC, DefaultMaxxC);
            AddExecutor(ExecutorType.Activate, CardId.Rabbit, DefaultGhostOgreAndSnowRabbit);
            //chain
            AddExecutor(ExecutorType.Activate, CardId.BatterymanSolar, BatterymanSolareff);
            AddExecutor(ExecutorType.Activate, CardId.OriginThunderDragon, OriginThunderDragoneff);
            AddExecutor(ExecutorType.Activate, CardId.BoltThunderDragon, BoltThunderDragoneff);            
            AddExecutor(ExecutorType.Activate, CardId.AviaonThunderDragon, AviaonThunderDragoneff);
            AddExecutor(ExecutorType.Activate, CardId.BeastialThunderDragon, BeastialThunderDragoneff);

            //first
            AddExecutor(ExecutorType.Activate, CardId.UpstartGoblin);
            AddExecutor(ExecutorType.Activate, CardId.HarpiesFeatherDuster, DefaultHarpiesFeatherDusterFirst);
            AddExecutor(ExecutorType.Activate, CardId.ThunderDragon, ThunderDragoneff);
            AddExecutor(ExecutorType.Summon, CardId.BatterymanSolar, BatterymanSolarsummon);
            //spell
            

            AddExecutor(ExecutorType.Repos, MonsterRepos);
        }
        bool summon_used = false;
        bool OriginThunderDragoneff_used = false;
        bool BoltThunderDragoneff_used = false;
        bool AviaonThunderDragoneff_used = false;
        bool BeastialThunderDragoneff_used = false;
        bool TwoDragon_PlanA_1 = false;
        bool TwoDragon_PlanA_2 = false;
        bool TwoDragon_PlanA_3 = false;
        bool TwoDragon_PlanB = false;
        bool TwoDragon_PlanC = false;
        public override void OnNewTurn()
        {
            summon_used = false;
            base.OnNewTurn();
        }
        public override void OnNewPhase()
        {
            base.OnNewPhase();
        }
        
        private void CheckPlan()
        {
            if(Bot.HasInHand(CardId.BatterymanSolar) && !summon_used &&
                Bot.HasInExtra(CardId.KaminariSummerVacation) &&
                Bot.HasInExtra(CardId.SuperboltThunderDragon,2))
            {
                if(Bot.HasInHand(CardId.AviaonThunderDragon) && !AviaonThunderDragoneff_used)
                {
                    if (Bot.GetRemainingCount(CardId.BeastialThunderDragon, 2) > 0 && !BeastialThunderDragoneff_used)
                        TwoDragon_PlanA_1 = true;
                    else if (Bot.GetRemainingCount(CardId.BoltThunderDragon, 3) > 0 && !BoltThunderDragoneff_used)
                        TwoDragon_PlanA_2 = true;
                }
                   
               

            }
        }
        private bool BatterymanSolarsummon()
        {
            return false;
        }
        private bool BatterymanSolareff()
        {
            return true;
        }

        private bool OriginThunderDragoneff()
        {
            if (Card.Location == CardLocation.Hand)
            {
                return false;
            }
            else
            {
                if(Bot.GetRemainingCount(CardId.OriginThunderDragon,3)>0)
                {
                    AI.SelectCard(CardId.OriginThunderDragon);
                    return true;
                }
            }
            return false;
        }

        private bool BoltThunderDragoneff()
        {            
            if (Card.Location == CardLocation.Hand)
            {

            }
            else
            {

            }
            return false;
        }

        private bool AviaonThunderDragoneff()
        {
            
            if (Card.Location == CardLocation.Hand)
            {

            }
            else
            {

            }
            return false;
        }

        private bool BeastialThunderDragoneff()
        {
            if (Card.Location == CardLocation.Hand)
            {

            }
            else
            {

            }
            return false;
        }

        private bool ThunderDragoneff()
        {
            return false;
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