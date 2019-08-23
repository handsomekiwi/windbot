using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;

namespace WindBot.Game.AI.Decks
{
    [Deck("FamiliarPossessed", "AI_FamiliarPossessed")]
    public class FamiliarPossessedExecutor : DefaultExecutor
    {
        public class CardId
        {
            public const int MetalSnake = 71197066;
            public const int FamiliarPossessedHiita= 4376658;
            public const int FamiliarPossessedWynn = 31764353;
            public const int FairyTailSnow = 55623480;
            public const int FairyTailLuna = 86937530;
            public const int AshBlossomAndJoyousSpring = 14558127;
            public const int GrenMajuDaEizo = 36584821;
            public const int HarpieFeatherDuster = 18144506;
            public const int PotOfDesires = 35261759;
            public const int PotOfExtravagance = 49238328;
            public const int CardOfDemise = 59750328;
            public const int PotOfDuality = 98645731;
            public const int Scapegoat = 73915051;
            public const int PossessedAwakening = 62256492;
            public const int InfiniteImpermanence = 10045474;
            public const int WakingTheDragon = 10813327;
            public const int Crackdown = 25704359;
            public const int AntiSpellFragrance = 58921041;
            public const int ImperialOrder = 61740673;
            public const int SkellDrain = 82732705;
            public const int SolemStrike = 40605147;
            public const int SolemnJudgment = 41420027;


            public const int NaturiaExterio = 99916754;
            public const int RaidraptorUltimateFalcon = 86221741;
            public const int MekkKnightCrusadiaAvramax = 21887175;
            public const int BorreloadDragon= 31833038;
            public const int BorrelswordDragon = 85289965;
            public const int SoldierOfChaos = 49202162;
            public const int NingirsuTheWorldChaliceWarrior = 30194529;
            public const int KnightmareUnicorn = 38342335;
            public const int KnightmarePhoenix = 2857636;
            public const int WynnTheWindCharmerVerdant = 30674956;
            public const int HiitaTheFireCharmerAblaze= 48815792;
            public const int KnightmareCerberus = 75452921;
            public const int SecurityDragon = 99111753;
            public const int Linkuriboh = 41999284;

         

            //old
            public const int InspectBoarder = 15397015;
            public const int ThunderKingRaiOh = 71564252;            
            public const int GhostReaperAndWinterCherries = 62015408;            
            public const int MaxxC = 23434538;
            public const int EaterOfMillions = 63845230;
            public const int HeavyStormDuster = 23924608;            
            public const int UpstartGoblin = 70368879;  
            public const int MoonMirrorShield = 19508728;
            public const int EvenlyMatched = 15693423;            
            public const int DrowningMirrorForce = 47475363;
            public const int MacroCosmos = 30241314;  
            public const int PhatomKnightsSword = 61936647;
            public const int UnendingNightmare = 69452756;
            public const int SolemnWarning = 84749824;            
            public const int DarkBribe = 77538567;
        }

        public FamiliarPossessedExecutor(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            AddExecutor(ExecutorType.GoToBattlePhase, GoToBattlePhase);
            AddExecutor(ExecutorType.Activate, CardId.EvenlyMatched, EvenlyMatchedeff);
            //Sticker           
            AddExecutor(ExecutorType.Activate, CardId.AntiSpellFragrance, AntiSpellFragranceeff);
            //counter
            AddExecutor(ExecutorType.Activate, CardId.AshBlossomAndJoyousSpring, DefaultAshBlossomAndJoyousSpring);
            AddExecutor(ExecutorType.Activate, CardId.MaxxC, DefaultMaxxC);            
            AddExecutor(ExecutorType.Activate, CardId.InfiniteImpermanence, DefaultInfiniteImpermanence);
            AddExecutor(ExecutorType.Activate, CardId.SolemnWarning, DefaultSolemnWarning);
            AddExecutor(ExecutorType.Activate, CardId.SolemStrike, DefaultSolemnStrike);
            AddExecutor(ExecutorType.Activate, CardId.ImperialOrder, ImperialOrderfirst);
            AddExecutor(ExecutorType.Activate, CardId.HeavyStormDuster, HeavyStormDustereff);
            AddExecutor(ExecutorType.Activate, CardId.UnendingNightmare, UnendingNightmareeff);
            AddExecutor(ExecutorType.Activate, CardId.DarkBribe, DarkBribeeff);
            AddExecutor(ExecutorType.Activate, CardId.ImperialOrder, ImperialOrdereff);     
            AddExecutor(ExecutorType.Activate, CardId.SolemnJudgment, DefaultSolemnJudgment);  
            //first do            
            AddExecutor(ExecutorType.Activate, CardId.HarpieFeatherDuster, DefaultHarpiesFeatherDusterFirst);
            AddExecutor(ExecutorType.Activate, CardId.PotOfExtravagance, PotOfExtravagance);
            AddExecutor(ExecutorType.Activate, CardId.PotOfDuality, PotOfDualityeff);
            AddExecutor(ExecutorType.Activate, CardId.PotOfDesires, PotOfDesireseff);
            AddExecutor(ExecutorType.Activate, CardId.CardOfDemise, CardOfDemiseeff);
            //sp
            
            AddExecutor(ExecutorType.Activate, CardId.Linkuriboh, Linkuriboheff);
            AddExecutor(ExecutorType.SpSummon, CardId.Linkuriboh, Linkuribohsp);

            AddExecutor(ExecutorType.SpSummon, CardId.BorreloadDragon, BorreloadDragonsp);
            AddExecutor(ExecutorType.Activate, CardId.BorreloadDragon, BorreloadDragoneff);            
            
            AddExecutor(ExecutorType.Activate, CardId.WakingTheDragon, WakingTheDragoneff);
            // normal summon 
            AddExecutor(ExecutorType.Summon, MonsterSummon);
            AddExecutor(ExecutorType.Summon, CardId.GrenMajuDaEizo, GrenMajuDaEizosummon);
            //spell          
            AddExecutor(ExecutorType.Activate, CardId.Crackdown, Crackdowneff);
            AddExecutor(ExecutorType.Activate, CardId.Scapegoat, DefaultScapegoat);
            AddExecutor(ExecutorType.Activate, CardId.PhatomKnightsSword, PhatomKnightsSwordeff);
            AddExecutor(ExecutorType.Repos, MonsterRepos);
            AddExecutor(ExecutorType.Activate, CardId.MetalSnake, MetalSnakesp);
            AddExecutor(ExecutorType.Activate, CardId.MetalSnake, MetalSnakeeff);
            //set
            AddExecutor(ExecutorType.SpellSet, SpellSet);
        }
        bool CardOfDemiseeff_used = false;        
       
        public override void OnNewTurn()
        {
            CardOfDemiseeff_used = false;
        }

        public override void OnNewPhase()
        {         
            base.OnNewPhase();
        }

        private bool GoToBattlePhase()
        {
            return Bot.HasInHand(CardId.EvenlyMatched) && Duel.Turn >= 2 && Enemy.GetFieldCount() >= 2 && Bot.GetFieldCount() == 0;
        }
 
        private bool MacroCosmoseff()
        {           
            return (Duel.LastChainPlayer == 1 || Duel.LastSummonPlayer == 1 || Duel.Player == 0) && UniqueFaceupSpell();
        }

        private bool AntiSpellFragranceeff()
        {
           
            int spell_count = 0;
            foreach(ClientCard check in Bot.Hand)
            {
                if (check.HasType(CardType.Spell))
                    spell_count++;
            }
            if (spell_count >= 2) return false;
            return Duel.Player == 1 && UniqueFaceupSpell();
        }
 
        private bool EvenlyMatchedeff()
        {
            return Enemy.GetFieldCount()-Bot.GetFieldCount() > 1;
        }
 
        private bool HeavyStormDustereff()
        {
            IList<ClientCard> targets = new List<ClientCard>();
            foreach (ClientCard check in Enemy.GetSpells())
            {
                if (check.HasType(CardType.Continuous) || check.HasType(CardType.Field))
                    targets.Add(check);
                
            }
            if (Util.GetPZone(1, 0) != null && Util.GetPZone(1, 0).Type == 16777218)
            {
                targets.Add(Util.GetPZone(1, 0));
                
            }
            if (Util.GetPZone(1, 1) != null && Util.GetPZone(1, 1).Type == 16777218)
            {
                targets.Add(Util.GetPZone(1, 1));               
            }
            foreach (ClientCard check in Enemy.GetSpells())
            {
                if (!check.HasType(CardType.Continuous) && !check.HasType(CardType.Field))
                    targets.Add(check);
            }
            if(DefaultOnBecomeTarget())
            {
                AI.SelectCard(targets);
                return true;
            }
            int count = 0;
            foreach(ClientCard check in Enemy.GetSpells())
            {
                if (check.Type == 16777218)
                    count++;
            }
            if(Util.GetLastChainCard()!=null && 
                (Util.GetLastChainCard().HasType(CardType.Continuous)||
                Util.GetLastChainCard().HasType(CardType.Field) || count==2) &&
                Duel.LastChainPlayer==1)               
                {
                AI.SelectCard(targets);
                return true;
                }
            return false;
        }
        private bool UnendingNightmareeff()
        {
            ClientCard card = null;
            foreach(ClientCard check in Enemy.GetSpells())
            {
                if (check.HasType(CardType.Continuous) || check.HasType(CardType.Field))                   
                    card = check;
                break;
            }
            int count = 0;
            foreach (ClientCard check in Enemy.GetSpells())
            {
                if (check.Type == 16777218)
                    count++;
            }
            if(count==2)
            {
                if (Util.GetPZone(1, 1) != null && Util.GetPZone(1, 1).Type == 16777218)
                {
                    card=Util.GetPZone(1, 1);
                }
            }
                
            if (card!=null && Bot.LifePoints>1000)
            {
                AI.SelectCard(card);
                return true;
            }
            return false;
        }

        private bool DarkBribeeff()
        {
            if (Util.GetLastChainCard()!=null && Util.GetLastChainCard().IsCode(CardId.UpstartGoblin))
                return false;
            return true;

        }
        private bool ImperialOrderfirst()
        {
            if (Util.GetLastChainCard() != null && Util.GetLastChainCard().IsCode(CardId.UpstartGoblin))
                return false;
            return DefaultOnBecomeTarget() && Util.GetLastChainCard().HasType(CardType.Spell);
        }

        private bool ImperialOrdereff()
        {
            if (Util.GetLastChainCard() != null && Util.GetLastChainCard().IsCode(CardId.UpstartGoblin))
                return false;
            if (Duel.LastChainPlayer == 1)
            {
                foreach(ClientCard check in Enemy.GetSpells())
                {
                    if (Util.GetLastChainCard() == check)
                        return true;
                }
            }
            return false;
        }
        
        private bool UpstartGoblineff()
        {         
            return !DefaultSpellWillBeNegated();
        }

        private bool PotOfExtravagance()
        {
            if (DefaultSpellWillBeNegated())
                return false;
            AI.SelectOption(1);
            return true;
        }

        private bool PotOfDualityeff()
        {
            if (DefaultSpellWillBeNegated())
                return false;          
            int count = 0;
            if (Bot.GetMonsterCount() > 0)
                count = 1;
            foreach(ClientCard card in Bot.Hand)
            {
                if (card.HasType(CardType.Monster))
                    count++;
            }
            if(Util.GetBestEnemyMonster()!=null && Util.GetBestEnemyMonster().Attack>=1900)
                AI.SelectCard(
                    CardId.EaterOfMillions,
                    CardId.PotOfDesires,
                    CardId.GrenMajuDaEizo,
                    CardId.InspectBoarder,
                    CardId.ThunderKingRaiOh,
                    CardId.Scapegoat,
                    CardId.SolemnJudgment,
                    CardId.SolemnWarning,
                    CardId.SolemStrike,
                    CardId.InfiniteImpermanence
                    );
            if (count == 0)
                AI.SelectCard(
                    CardId.PotOfDesires,
                    CardId.InspectBoarder,
                    CardId.ThunderKingRaiOh,
                    CardId.EaterOfMillions,
                    CardId.GrenMajuDaEizo,
                    CardId.Scapegoat
                    );
            else
            {
                AI.SelectCard(
                    CardId.PotOfDesires,
                    CardId.CardOfDemise,
                    CardId.SolemnJudgment,
                    CardId.SolemnWarning,
                    CardId.SolemStrike,
                    CardId.InfiniteImpermanence,
                    CardId.Scapegoat
                    );
            }
            return true;
        }

        private bool PotOfDesireseff()
        {
            if (CardOfDemiseeff_used) return false;          
            return Bot.Deck.Count > 14 && !DefaultSpellWillBeNegated();
        }

        private bool CardOfDemiseeff()
        {          
            if (Bot.Hand.Count == 1 && Bot.GetSpellCountWithoutField() <= 3 && !DefaultSpellWillBeNegated())
            {
                CardOfDemiseeff_used = true;
                return true;
            }
            return false;
        }        

        private bool PhatomKnightsSwordeff()
        {
            if (Card.IsFaceup())
                return true;
            if(Duel.Phase==DuelPhase.BattleStart && Bot.BattlingMonster!=null && Enemy.BattlingMonster!=null)
            {                
                if (Bot.BattlingMonster.Attack + 800 >= Enemy.BattlingMonster.GetDefensePower())
                {
                    AI.SelectCard(Bot.BattlingMonster);
                    return DefaultUniqueTrap();
                }                
            }
            return false;
        }
        
        private bool MonsterSummon()
        {
            return false;
        }

        private bool GrenMajuDaEizosummon()
        {
            if (Duel.Turn == 1) return false;           
            if (Bot.MonsterZone[0] == null)
                AI.SelectPlace(Zones.z0);
            else
                AI.SelectPlace(Zones.z4);
            return Bot.Banished.Count >= 6;
        }

        private bool Crackdowneff()
        {
            if (Util.GetOneEnemyBetterThanMyBest(true, true) != null && Bot.UnderAttack)
            {
                AI.SelectCard(Util.GetOneEnemyBetterThanMyBest(true, true));
                return true;
            }           
            return false;
        }
        private bool MetalSnakesp()
        {
            if (ActivateDescription == Util.GetStringId(CardId.MetalSnake, 0) && !Bot.HasInMonstersZone(CardId.MetalSnake))
            {
                if (Duel.Player == 1 && Duel.Phase >= DuelPhase.BattleStart)
                    return Bot.Deck.Count >= 12;
                if (Duel.Player == 0 && Duel.Phase >= DuelPhase.Main1)
                    return Bot.Deck.Count >= 12;
            }
            return false;
        }

        private bool MetalSnakeeff()
        {
            ClientCard target = Util.GetOneEnemyBetterThanMyBest(true, true);
            if (ActivateDescription == Util.GetStringId(CardId.MetalSnake, 1) && target != null)
            {
                AI.SelectCard(new[]
                {
                    CardId.RaidraptorUltimateFalcon,
                    CardId.NingirsuTheWorldChaliceWarrior
                });
                AI.SelectNextCard(target);
                return true;
            }
            return false;

        }
        private bool BorreloadDragonsp()
        {
          
            IList<ClientCard> material_list = new List<ClientCard>();
            foreach (ClientCard monster in Bot.GetMonsters())
            {              
                if (material_list.Count == 3) break;
            }
            if(material_list.Count>=3)
            {
                AI.SelectMaterials(material_list);
                return true;
            }
            return false;
        }
        
        public bool BorreloadDragoneff()
        {
            if (ActivateDescription == -1 && (Duel.Phase==DuelPhase.BattleStart||Duel.Phase==DuelPhase.End))
            {
                ClientCard enemy_monster = Enemy.BattlingMonster;
                if (enemy_monster != null && enemy_monster.HasPosition(CardPosition.Attack))
                {
                    return (Card.Attack - enemy_monster.Attack < Enemy.LifePoints);
                }
                return true;
            };
            ClientCard BestEnemy = Util.GetBestEnemyMonster(true);
            ClientCard WorstBot = Bot.GetMonsters().GetLowestAttackMonster();
            if (BestEnemy == null || BestEnemy.HasPosition(CardPosition.FaceDown)) return false;
            if (WorstBot == null || WorstBot.HasPosition(CardPosition.FaceDown)) return false;
            if (BestEnemy.Attack >= WorstBot.RealPower)
            {
                AI.SelectCard(BestEnemy);
                return true;
            }
            return false;
        }

 
      

        private bool WakingTheDragoneff()
        {
            AI.SelectCard(new[] { CardId.RaidraptorUltimateFalcon,CardId.NaturiaExterio});
            return true;
        }

        

       
        private bool Linkuribohsp()
        {            
            foreach (ClientCard c in Bot.GetMonsters())
            {
                if (!c.IsCode(CardId.EaterOfMillions, CardId.Linkuriboh) && c.Level==1)
                {
                    AI.SelectMaterials(c);
                    return true;
                }
            }
            return false;
        }

        private bool Linkuriboheff()
        {
            if (Duel.LastChainPlayer == 0 && Util.GetLastChainCard().IsCode(CardId.Linkuriboh)) return false;           
            return true;
        }
        private bool MonsterRepos()
        {
            if (Card.IsCode(CardId.EaterOfMillions) && Card.IsAttack()) return false;
            return DefaultMonsterRepos();
        }

        private bool SpellSet()
        {
            int count = 0;
            foreach(ClientCard check in Bot.Hand)
            {
                if (check.IsCode(CardId.CardOfDemise))
                    count++;
            }
            if (count == 2 && Bot.Hand.Count == 2 && Bot.GetSpellCountWithoutField() <= 2)
                return true;            
            if (Card.IsCode(CardId.MacroCosmos) && Bot.HasInSpellZone(CardId.MacroCosmos)) return false;
            if (Card.IsCode(CardId.AntiSpellFragrance) && Bot.HasInSpellZone(CardId.AntiSpellFragrance)) return false;
            if (CardOfDemiseeff_used)return true;            
            if (Card.IsCode(CardId.EvenlyMatched) && (Enemy.GetFieldCount() - Bot.GetFieldCount()) < 0) return false;
            if (Card.IsCode(CardId.AntiSpellFragrance) && Bot.HasInSpellZone(CardId.AntiSpellFragrance)) return false;
            if (Card.IsCode(CardId.MacroCosmos) && Bot.HasInSpellZone(CardId.MacroCosmos)) return false;
            if (Duel.Turn > 1 && Duel.Phase == DuelPhase.Main1 && Bot.HasAttackingMonster())
                return false;
            if (Card.IsCode(CardId.InfiniteImpermanence))
                return Bot.GetFieldCount() > 0 && Bot.GetSpellCountWithoutField() < 4;
            if (Card.IsCode(CardId.Scapegoat))
                return true;
            if (Card.HasType(CardType.Trap))
                return Bot.GetSpellCountWithoutField() < 4;
            if(Bot.HasInSpellZone(CardId.AntiSpellFragrance,true))
            {
                if (Card.IsCode(CardId.UpstartGoblin, CardId.PotOfDesires, CardId.PotOfDuality)) return true;
                if (Card.IsCode(CardId.CardOfDemise) && Bot.HasInSpellZone(CardId.CardOfDemise)) return false;
                if (Card.HasType(CardType.Spell))
                    return Bot.GetSpellCountWithoutField() < 4;
            }
            return false;
        }
        public override bool OnPreBattleBetween(ClientCard attacker, ClientCard defender)
        {
            if (attacker.IsCode(_CardId.EaterOfMillions) && !attacker.IsDisabled())
            {
                attacker.RealPower = 9999;
                return true;
            }
            if (attacker.IsCode(_CardId.EaterOfMillions) && !Bot.HasInMonstersZone(CardId.InspectBoarder) && !attacker.IsDisabled())
            {
                attacker.RealPower = 9999;
                return true;
            }            
            return base.OnPreBattleBetween(attacker, defender);
        }
        public override ClientCard OnSelectAttacker(IList<ClientCard> attackers, IList<ClientCard> defenders)
        {
            for (int i = 0; i < attackers.Count; ++i)
            {
                ClientCard attacker = attackers[i];
                if (attacker.IsCode(CardId.BorrelswordDragon, CardId.EaterOfMillions)) return attacker;
            }
            return null;
        }
        public override bool OnSelectHand()
        {
            return true;
        }        
    }
}