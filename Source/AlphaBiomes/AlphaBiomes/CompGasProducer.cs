﻿
using RimWorld;
using Verse;


namespace AlphaBiomes
{
    class CompGasProducer : ThingComp
    {

        private int gasProgress = 0;
        private int gasTickMax = 64;
        private System.Random rand = new System.Random();


        public CompProperties_GasProducer Props
        {
            get
            {
                return (CompProperties_GasProducer)this.props;
            }
        }


        public override void CompTick()
        {
            this.gasProgress += 1;
            if (this.gasProgress > gasTickMax)
            {
               
                if (this.parent.Map != null)
                {
                    
                    int num = GenRadial.NumCellsInRadius(Props.radius);
                    for (int i = 0; i < num; i++)
                    {
                       IntVec3 current = this.parent.Position + GenRadial.RadialPattern[i];
                       if (current.InBounds(this.parent.Map) && rand.NextDouble() < Props.rate)
                        {
                            Thing thing = ThingMaker.MakeThing(ThingDef.Named(Props.gasType), null);

                            GenSpawn.Spawn(thing, current, this.parent.Map);
                        }
                    }


                    
                        

                    
                    // FilthMaker.MakeFilth(this.parent.PositionHeld, this.parent.MapHeld, ThingDef.Named("GR_FilthMucus"), 1);
                    this.gasProgress = 0;
                }

            }
        }
    }
}