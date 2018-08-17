using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;

namespace WindBot.Game.AI.Decks
{
    [Deck("Phantasm", "AI_Phantasm", "Normal")]
    public class PhantasmExecutor : DefaultExecutor
    {
        public class CardId
        {
            public const int MegalosmasherX = 81823360;
            public const int AshBlossom = 14558127;
            public const int EaterOfMillions = 63845230;

            public const int HarpieFeatherDuster = 18144507;
            public const int PotOfDesires = 35261759;
            public const int FossilDig = 47325505;
            public const int CardOfDemise = 59750328;
            public const int Terraforming = 73628505;
            public const int PotOfDuality = 98645731;
            public const int Scapegoat = 73915051;
            public const int PacifisThePhantasmCity = 2819435;

            public const int InfiniteImpermanence = 10045474;
            public const int PhantasmSprialBattle = 34302287;
            public const int DrowningMirrorForce = 47475363;
            public const int StarlightRoad = 58120309;
            public const int PhantasmSpiralPower = 61397885;
            public const int Metaverse = 89208725;
            public const int SeaStealthAttack = 19089195;
            public const int GozenMatch = 53334471;
            public const int SkillDrain = 82732705;
            public const int TheHugeRevolutionIsOver = 99188141;

            public const int StardustDragon = 44508094;
            public const int TopologicBomberDragon = 5821478;
            public const int BorreloadDragon = 31833038;
            public const int BorrelswordDragon = 85289965;
            public const int KnightmareGryphon = 65330383;
            public const int TopologicTrisbaena = 72529749;
            public const int SummonSorceress = 61665245;
            public const int KnightmareUnicorn = 38342335;
            public const int KnightmarePhoenix = 2857636;
            public const int KnightmareCerberus = 75452921;
            public const int CrystronNeedlefiber = 50588353;
            public const int MissusRadiant = 3987233;
            public const int LinkSpider = 98978921;
            public const int Linkuriboh = 41999284;
        }

        public PhantasmExecutor(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            //counter
            AddExecutor(ExecutorType.ToBattlePhase, ToBattlePhaseeff);            
            AddExecutor(ExecutorType.Activate, _CardId.GhostBelle, DefaultGhostBelle);
            AddExecutor(ExecutorType.Activate, _CardId.CalledByTheGrave, DefaultCalledByTheGrave);
            AddExecutor(ExecutorType.Activate, _CardId.EffectVeiler, DefaultEffectVeiler);
            AddExecutor(ExecutorType.Activate, _CardId.InfiniteImpermanence, DefaultInfiniteImpermanence);
            AddExecutor(ExecutorType.Activate, _CardId.AshBlossom, DefaultAshBlossomAndJoyousSpring);
            AddExecutor(ExecutorType.Activate, _CardId.GhostOgreAndSnowRabbit, DefaultGhostOgreAndSnowRabbit);
            AddExecutor(ExecutorType.SpSummon);
            AddExecutor(ExecutorType.Activate, DefaultDontChainMyself);
            AddExecutor(ExecutorType.SummonOrSet);
            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);
            AddExecutor(ExecutorType.SpellSet);
        }
        private bool ToBattlePhaseeff()
        {           
            if (Enemy.GetMonsterCount() == 0)
            {
                if (AI.Utils.GetTotalAttackingMonsterAttack(0) >= Enemy.LifePoints)
                {
                    AI.ManualPhaseChange = true;
                    return true;
                }
            }
            return false;
        }

    }
}