using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;

namespace WindBot.Game.AI.Decks
{
    [Deck("DemiseTrueDraco", "AI_DemiseTrueDraco", "Normal")]
    public class DemiseTrueDracoExecutor : DefaultExecutor
    {
        public class CardId
        {/*            
            public const int TheTrueDracombatant =;
            public const int TheTrueDracofighter =;
            public const int TheTrueDracocavalry =;
            public const int TheTrueDracowarrior =;
            public const int TheTrueDracocaster =;
            public const int InspectorBoarder =;
            public const int MaxxC =;

            public const int CardOfDemise =;
            public const int Scapegoat =;
            public const int TheMonarchsStormfort =;
            public const int TrueDracoHeritage =;
            public const int DisciplesOfTheTrueDracophoenix =;

            public const int WakingTheDragon =;
            public const int WaterfallOfDragonSouls =;
            public const int VanityEmptiness =;
            public const int TrueKingReturn =;
            public const int TrueDracoApocalypse =;
            public const int ImperialOrder =;
            public const int PhantomKnightSword =;

            public const int NaturiaExterio =;
            public const int BloomDivaTheMelodiousChoir =;
            public const int SuperheavySamuraiSteamTrainKing =;
            public const int CrystalWingSynchroDragon =;
            public const int RaidraptorUltimateFalcon =;
            public const int BorreloadDragon =;
            public const int BorrelswordDragon =;
            public const int TheWorldChaliceWarrior =;
            public const int KnightmarePhoenix =;
            public const int KnightmareCerberus =;
            public const int MissusRadiant =;
            public const int Linkuriboh =;*/
        }

        public DemiseTrueDracoExecutor(GameAI ai, Duel duel)
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