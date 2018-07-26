using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;

namespace WindBot.Game.AI.Decks
{
    [Deck("Infernoid", "AI_Infernoid", "Normal")]
    public class InfernoidExecutor : DefaultExecutor
    {
        public class CardId
        {
            public const int PSYFrameDriver = 49036338;
            public const int InfernoidOnuncu = 14799437;
            public const int InfernoidDevyaty = 23440231;
            public const int LordOfTheLair = 50383626;
            public const int InfernoidAttondel = 88301393;
            public const int InfernoidSeitsemas = 51316684;
            public const int InfernoidSjette = 96055137;
            public const int AhrimaTheWichedWarden = 86377375;
            public const int LilithLadyOfLament = 23898021;
            public const int AshBlossom = 14558127;
            public const int PSYFramegearGamma = 38814750;
            public const int MaxxC = 23434538;
            public const int InfernoidDecatron = 58446973;
            public const int GlowUpBulb = 67441435;

            public const int OneforOne = 2295440;
            public const int Terraforming = 73628505;
            public const int VoidImagination = 31444249;
            public const int VoidVanishment = 78748366;
            public const int LairOfDarkness = 59160188;
            public const int VoidFeast = 31548814;
            public const int Metaverse = 89208725;

            public const int InfernoidTierra = 82734805;
            public const int ElderEntityNtss = 80532587;
            public const int PSYGramelordOmega = 74586817;
            public const int TGWonderMagician = 98558751;
            public const int TopologicBomberDragon = 5821478;
            public const int BorreloadDragon = 31833038;
            public const int BorrelswordDragon = 85289965;
            public const int TopologicTrisbaena = 72529749;
            public const int KnightmareUnicorn = 38342335;
            public const int CrystronNeedlefiber = 50588353;
            public const int LinkSpider = 98978921;
            public const int Linduriboh = 41999284;           
            
        }

        public InfernoidExecutor(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            //counter 
            AddExecutor(ExecutorType.Activate, CardId.PSYFramegearGamma, PSYFramegearGammaeff);
            AddExecutor(ExecutorType.Activate, CardId.AshBlossom, DefaultAshBlossomAndJoyousSpring);
            AddExecutor(ExecutorType.Activate, CardId.MaxxC, MaxxCeff);
            //first do
            AddExecutor(ExecutorType.Activate, CardId.Terraforming);
            AddExecutor(ExecutorType.Activate, CardId.LairOfDarkness, LairOfDarknesseff);
            AddExecutor(ExecutorType.Activate, CardId.VoidImagination, VoidImaginationeff);
            AddExecutor(ExecutorType.Activate, CardId.VoidFeast, VoidFeasteff);
            AddExecutor(ExecutorType.Activate, CardId.Metaverse, Metaverseeff);
            AddExecutor(ExecutorType.SpSummon, CardId.PSYGramelordOmega);
            //chain
            AddExecutor(ExecutorType.Activate, CardId.InfernoidTierra, InfernoidTierraeff);
            //normal
            AddExecutor(ExecutorType.Summon, CardId.LilithLadyOfLament, LilithLadyOfLamentsummon);
            AddExecutor(ExecutorType.Summon, CardId.InfernoidDecatron, InfernoidDecatronsummon);
            AddExecutor(ExecutorType.Summon, CardId.AhrimaTheWichedWarden, AhrimaTheWichedWardensummon);

            //overthing 
            AddExecutor(ExecutorType.Activate, CardId.AhrimaTheWichedWarden, AhrimaTheWichedWardeneff);
            AddExecutor(ExecutorType.Activate, CardId.LilithLadyOfLament, LilithLadyOfLamenteff);
            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);
        }
        bool LilithLadyOfLament_summon = false;
        bool InfernoidDecatron_summon = false;
        bool AhrimaTheWichedWarden_summon = false;
        public override void OnNewTurn()
        {
            base.OnNewTurn();
        }

        public override void OnNewPhase()
        {
            base.OnNewPhase();
        }

        private bool PSYFramegearGammaeff()
        {
            if(Duel.Player== 0 && Duel.LastChainPlayer==1)
            {
                AI.SelectPosition(CardPosition.FaceUpAttack);
                return true;
            }
            if (Duel.Player == 1 && Duel.LastChainPlayer == 1)
            {
                AI.SelectPosition(CardPosition.FaceUpAttack);
                AI.SelectPosition(CardPosition.FaceUpDefence);                
                return true;
            }
            return false;
        }
        private bool MaxxCeff()
        {
            return Duel.Player == 1;
        }

        private bool LairOfDarknesseff()
        {            
            if (Card.Location == CardLocation.Hand && !Bot.HasInSpellZone(CardId.LairOfDarkness))
                return true;
            if (Card.Location == CardLocation.SpellZone)
                return true;
            return false;
        }

        private bool VoidImaginationeff()
        {
            foreach(ClientCard check in Enemy.GetMonsters())
            {
                if(check.IsExtraCard())
                {
                    IList<ClientCard> fusion = new List<ClientCard>();
                    foreach (ClientCard m in Bot.Deck)
                    {
                        if (m.HasAttribute(CardAttribute.Dark))
                            fusion.Add(m);
                    }
                    AI.SelectMaterials(fusion);
                    return true;
                }
            }
            return false;
        }

        private bool VoidFeasteff()
        {
            AI.SelectCard(CardId.VoidImagination);
            AI.SelectNextCard(new[] { CardId.InfernoidDecatron, CardId.InfernoidDecatron, CardId.InfernoidSjette });
            AI.SelectPosition(CardPosition.FaceUpAttack);
            AI.SelectPosition(CardPosition.FaceUpDefence);
            AI.SelectPosition(CardPosition.FaceUpDefence);            
            return true;
        }

        private bool Metaverseeff()
        {
            if(AI.Utils.IsChainTarget(Card))
            {
                if (Bot.HasInSpellZone(CardId.LairOfDarkness))
                    AI.SelectYesNo(false);
                return true;
            }
            if(DefaultOnBecomeTarget())
            {
                AI.SelectYesNo(false);
                return true;
            }
            if (Bot.HasInMonstersZone(new[] { CardId.LilithLadyOfLament,
            CardId.InfernoidAttondel,CardId.InfernoidDecatron,
            CardId.InfernoidDevyaty,CardId.InfernoidOnuncu,
            CardId.InfernoidSeitsemas,CardId.InfernoidSjette,CardId.InfernoidTierra}))
            {
                if(Duel.Player==1)
                {
                    if (!Bot.HasInSpellZone(CardId.LairOfDarkness))
                        return true;
                }
                if(Duel.Player==0)
                {
                    if (!Bot.HasInHandOrInSpellZone(CardId.LordOfTheLair))
                        return true;
                }                
            }
            if (Duel.Player == 0 && Bot.HasInMonstersZone(new[] { CardId.LordOfTheLair, CardId.AhrimaTheWichedWarden }))
            {
                if (!Bot.HasInHandOrInSpellZone(CardId.LordOfTheLair))
                    return true;
            }
            return false;
        }

        private bool InfernoidTierraeff()
        {
            AI.SelectCard(CardId.ElderEntityNtss);
            AI.SelectNextCard(CardId.ElderEntityNtss);
            AI.SelectThirdCard(CardId.PSYGramelordOmega);
            return true;
        }
        private bool LilithLadyOfLamentsummon()
        {
            if (LilithLadyOfLament_summon)
                return true;
            return false;
        }
        private bool LilithLadyOfLamenteff()
        {
            if(Bot.GetMonsterCount()<3)
            {
                AI.SelectCard(CardId.LilithLadyOfLament);
                AI.SelectNextCard(new[] { CardId.VoidFeast, CardId.VoidFeast, CardId.VoidFeast });
                return true;
            }
            if(!Bot.HasInHandOrInSpellZone(CardId.LairOfDarkness))
            {
                AI.SelectCard(CardId.LilithLadyOfLament);
                AI.SelectNextCard(CardId.Metaverse);
                return true;
            }
            return false;
        }

        private bool InfernoidDecatronsummon()
        {
            if (InfernoidDecatron_summon) return true;
            return false;
        }

        private bool AhrimaTheWichedWardensummon()
        {
            if (AhrimaTheWichedWarden_summon) return true;
            return false;
        }

        private bool AhrimaTheWichedWardeneff()
        {
            if(Card.Location==CardLocation.Hand)
            {
                if (!Bot.HasInHandOrInSpellZone(CardId.LairOfDarkness) && !Bot.HasInHandOrInSpellZone(CardId.Metaverse))
                    return true;
            }
            return false;
        }
    }
}