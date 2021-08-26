﻿using RimWorld;
using UnityEngine;
using Verse;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AlphaBiomes
{
    public class AlphaBiomes_Settings : ModSettings

    {


        public static bool AB_UseAgariluxParticles = true;

        public static bool AB_SpawnFeraliskInfestedJungle = true;
        public static bool AB_SpawnGallatrossGraveyard = true;
        public static bool AB_SpawnGelatinousSuperorganism = true;
        public static bool AB_SpawnMechanoidIntrusion = true;
        public static bool AB_SpawnMycoticJungle = true;
        public static bool AB_SpawnOcularForest = true;
        public static bool AB_SpawnPropaneLakes = true;
        public static bool AB_SpawnRockyCrags = true;
        public static bool AB_SpawnPyroclasticConflagration = true;
        public static bool AB_SpawnTarPits = true;

        public static bool AB_RemoveVanillaBiomes = false;

        private static Vector2 scrollPosition = Vector2.zero;

        public const float biomeMultiplierBase = 1;
        public static float feraliskInfestedJungleMultiplier = biomeMultiplierBase;
        public static float gallatrossGraveyardMultiplier = biomeMultiplierBase;
        public static float gelatinousSuperorganismMultiplier = biomeMultiplierBase;
        public static float mechanoidIntrusionMultiplier = biomeMultiplierBase;
        public static float mycoticJungleMultiplier = biomeMultiplierBase;
        public static float ocularForestMultiplier = biomeMultiplierBase;
        public static float propaneLakesMultiplier = biomeMultiplierBase;
        public static float rockyCragsMultiplier = biomeMultiplierBase;
        public static float pyroclasticConflagrationMultiplier = biomeMultiplierBase;
        public static float tarPitsMultiplier = biomeMultiplierBase;








        public override void ExposeData()
        {
            base.ExposeData();

            Scribe_Values.Look(ref AB_UseAgariluxParticles, "AB_UseAgariluxParticles", true, true);
            Scribe_Values.Look(ref AB_SpawnFeraliskInfestedJungle, "AB_SpawnFeraliskInfestedJungle", true, true);
            Scribe_Values.Look(ref AB_SpawnGallatrossGraveyard, "AB_SpawnGallatrossGraveyard", true, true);
            Scribe_Values.Look(ref AB_SpawnGelatinousSuperorganism, "AB_SpawnGelatinousSuperorganism", true, true);
            Scribe_Values.Look(ref AB_SpawnMechanoidIntrusion, "AB_SpawnMechanoidIntrusion", true, true);
            Scribe_Values.Look(ref AB_SpawnMycoticJungle, "AB_SpawnMycoticJungle", true, true);
            Scribe_Values.Look(ref AB_SpawnOcularForest, "AB_SpawnOcularForest", true, true);
            Scribe_Values.Look(ref AB_SpawnPropaneLakes, "AB_SpawnPropaneLakes", true, true);
            Scribe_Values.Look(ref AB_SpawnRockyCrags, "AB_SpawnRockyCrags", true, true);
            Scribe_Values.Look(ref AB_SpawnPyroclasticConflagration, "AB_SpawnPyroclasticConflagration", true, true);
            Scribe_Values.Look(ref AB_SpawnTarPits, "AB_SpawnTarPits", true, true);

            Scribe_Values.Look<float>(ref feraliskInfestedJungleMultiplier, "feraliskInfestedJungleMultiplier",1, true);
            Scribe_Values.Look<float>(ref gallatrossGraveyardMultiplier, "gallatrossGraveyardMultiplier", 1, true);
            Scribe_Values.Look<float>(ref gelatinousSuperorganismMultiplier, "gelatinousSuperorganismMultiplier", 1, true);
            Scribe_Values.Look<float>(ref mechanoidIntrusionMultiplier, "mechanoidIntrusionMultiplier", 1, true);
            Scribe_Values.Look<float>(ref mycoticJungleMultiplier, "mycoticJungleMultiplier", 1, true);
            Scribe_Values.Look<float>(ref ocularForestMultiplier, "ocularForestMultiplier", 1, true);
            Scribe_Values.Look<float>(ref propaneLakesMultiplier, "propaneLakesMultiplier", 1, true);
            Scribe_Values.Look<float>(ref rockyCragsMultiplier, "rockyCragsMultiplier", 1, true);
            Scribe_Values.Look<float>(ref pyroclasticConflagrationMultiplier, "pyroclasticConflagrationMultiplier", 1, true);
            Scribe_Values.Look<float>(ref tarPitsMultiplier, "tarPitsMultiplier", 1, true);



            Scribe_Values.Look(ref AB_RemoveVanillaBiomes, "AB_RemoveVanillaBiomes", false, true);





        }
        public void DoWindowContents(Rect inRect)
        {
            Listing_Standard ls = new Listing_Standard();


            ls.Begin(inRect);
            //ls.ColumnWidth = inRect.width / 2.05f;
            ls.CheckboxLabeled("AB_UseAgariluxParticles".Translate(), ref AB_UseAgariluxParticles, null);
            ls.CheckboxLabeled("AB_SpawnFeraliskInfestedJungle".Translate(), ref AB_SpawnFeraliskInfestedJungle, null);
            ls.CheckboxLabeled("AB_SpawnGallatrossGraveyard".Translate(), ref AB_SpawnGallatrossGraveyard, null);
            ls.CheckboxLabeled("AB_SpawnGelatinousSuperorganism".Translate(), ref AB_SpawnGelatinousSuperorganism, null);
            ls.CheckboxLabeled("AB_SpawnMechanoidIntrusion".Translate(), ref AB_SpawnMechanoidIntrusion, null);
            ls.CheckboxLabeled("AB_SpawnMycoticJungle".Translate(), ref AB_SpawnMycoticJungle, null);
            ls.CheckboxLabeled("AB_SpawnOcularForest".Translate(), ref AB_SpawnOcularForest, null);
            ls.CheckboxLabeled("AB_SpawnPropaneLakes".Translate(), ref AB_SpawnPropaneLakes, null);
            ls.CheckboxLabeled("AB_SpawnRockyCrags".Translate(), ref AB_SpawnRockyCrags, null);
            ls.CheckboxLabeled("AB_SpawnPyroclasticConflagration".Translate(), ref AB_SpawnPyroclasticConflagration, null);
            ls.CheckboxLabeled("AB_SpawnTarPits".Translate(), ref AB_SpawnTarPits, null);
            ls.CheckboxLabeled("AB_RemoveVanillaBiomes".Translate(), ref AB_RemoveVanillaBiomes, null);
            ls.End();

            var scrollContainer = inRect.ContractedBy(10);
            scrollContainer.height -= ls.CurHeight;
            scrollContainer.y += ls.CurHeight;
            Widgets.DrawBoxSolid(scrollContainer, Color.grey);
            var innerContainer = scrollContainer.ContractedBy(1);
            Widgets.DrawBoxSolid(innerContainer, new ColorInt(42, 43, 44).ToColor);
            var frameRect = innerContainer.ContractedBy(5);
            frameRect.y += 15;
            frameRect.height -= 15;
            var contentRect = frameRect;
            contentRect.x = 0;
            contentRect.y = 0;
            contentRect.width -= 20;


            int numberBiomes = (from k in DefDatabase<BiomeDef>.AllDefsListForReading
                                                     where k.defName.Contains("AB_")
                                                     select k).Count();

            contentRect.height = numberBiomes * 100f;

            Listing_Standard ls2 = new Listing_Standard();
           
            Widgets.BeginScrollView(frameRect, ref scrollPosition, contentRect, true);
            ls2.Begin(contentRect.AtZero());


           
            var ferJungleLabel = ls2.LabelPlusButton("AB_BiomeMultiplier".Translate(BiomeDef.Named("AB_FeraliskInfestedJungle").LabelCap) + ": " + feraliskInfestedJungleMultiplier, "AB_MultiplierTooltip".Translate(BiomeDef.Named("AB_FeraliskInfestedJungle").LabelCap));
            feraliskInfestedJungleMultiplier = (float)Math.Round(ls2.Slider(feraliskInfestedJungleMultiplier, 0.1f, 2f), 2);
            
            if (ls2.Settings_Button("AB_Reset".Translate(BiomeDef.Named("AB_FeraliskInfestedJungle").LabelCap), new Rect(0f, ferJungleLabel.position.y+35, 250f, 29f)))
            {
                feraliskInfestedJungleMultiplier = biomeMultiplierBase;
            }
            
            var forCragsLabel = ls2.LabelPlusButton("AB_BiomeMultiplier".Translate(BiomeDef.Named("AB_RockyCrags").LabelCap) + ": " + rockyCragsMultiplier, "AB_MultiplierTooltip".Translate(BiomeDef.Named("AB_RockyCrags").LabelCap));
            rockyCragsMultiplier = (float)Math.Round(ls2.Slider(rockyCragsMultiplier, 0.1f, 2f), 2);
            
            if (ls2.Settings_Button("AB_Reset".Translate(BiomeDef.Named("AB_RockyCrags").LabelCap), new Rect(0f, forCragsLabel.position.y + 35, 250f, 29f)))
            {
                rockyCragsMultiplier = biomeMultiplierBase;
            }

            var galGraveLabel = ls2.LabelPlusButton("AB_BiomeMultiplier".Translate(BiomeDef.Named("AB_GallatrossGraveyard").LabelCap) + ": " + gallatrossGraveyardMultiplier,  "AB_MultiplierTooltip".Translate(BiomeDef.Named("AB_GallatrossGraveyard").LabelCap));
            gallatrossGraveyardMultiplier = (float)Math.Round(ls2.Slider(gallatrossGraveyardMultiplier, 0.1f, 2f), 2);

            if (ls2.Settings_Button("AB_Reset".Translate(BiomeDef.Named("AB_GallatrossGraveyard").LabelCap), new Rect(0f, galGraveLabel.position.y + 35, 250f, 29f)))
            {
                gallatrossGraveyardMultiplier = biomeMultiplierBase;
            }
            
            var gelSuperLabel = ls2.LabelPlusButton("AB_BiomeMultiplier".Translate(BiomeDef.Named("AB_GelatinousSuperorganism").LabelCap) + ": " + gelatinousSuperorganismMultiplier,  "AB_MultiplierTooltip".Translate(BiomeDef.Named("AB_GelatinousSuperorganism").LabelCap));
            gelatinousSuperorganismMultiplier = (float)Math.Round(ls2.Slider(gelatinousSuperorganismMultiplier, 0.1f, 2f), 2);

            if (ls2.Settings_Button("AB_Reset".Translate(BiomeDef.Named("AB_GelatinousSuperorganism").LabelCap), new Rect(0f, gelSuperLabel.position.y + 35, 250f, 29f)))
            {
                gelatinousSuperorganismMultiplier = biomeMultiplierBase;
            }

            var mechInvasionLabel = ls2.LabelPlusButton("AB_BiomeMultiplier".Translate(BiomeDef.Named("AB_MechanoidIntrusion").LabelCap) + ": " + mechanoidIntrusionMultiplier,  "AB_MultiplierTooltip".Translate(BiomeDef.Named("AB_MechanoidIntrusion").LabelCap));
            mechanoidIntrusionMultiplier = (float)Math.Round(ls2.Slider(mechanoidIntrusionMultiplier, 0.1f, 2f), 2);

            if (ls2.Settings_Button("AB_Reset".Translate(BiomeDef.Named("AB_MechanoidIntrusion").LabelCap), new Rect(0f, mechInvasionLabel.position.y + 35, 250f, 29f)))
            {
                mechanoidIntrusionMultiplier = biomeMultiplierBase;
            }

            var mycJungleLabel = ls2.LabelPlusButton("AB_BiomeMultiplier".Translate(BiomeDef.Named("AB_MycoticJungle").LabelCap) + ": " + mycoticJungleMultiplier,  "AB_MultiplierTooltip".Translate(BiomeDef.Named("AB_MycoticJungle").LabelCap));
            mycoticJungleMultiplier = (float)Math.Round(ls2.Slider(mycoticJungleMultiplier, 0.1f, 2f), 2);

            if (ls2.Settings_Button("AB_Reset".Translate(BiomeDef.Named("AB_MycoticJungle").LabelCap), new Rect(0f, mycJungleLabel.position.y + 35, 250f, 29f)))
            {
                mycoticJungleMultiplier = biomeMultiplierBase;
            }

            var ocForestLabel = ls2.LabelPlusButton("AB_BiomeMultiplier".Translate(BiomeDef.Named("AB_OcularForest").LabelCap) + ": " + ocularForestMultiplier,  "AB_MultiplierTooltip".Translate(BiomeDef.Named("AB_OcularForest").LabelCap));
            ocularForestMultiplier = (float)Math.Round(ls2.Slider(ocularForestMultiplier, 0.1f, 2f), 2);

            if (ls2.Settings_Button("AB_Reset".Translate(BiomeDef.Named("AB_OcularForest").LabelCap), new Rect(0f, ocForestLabel.position.y + 35, 250f, 29f)))
            {
                ocularForestMultiplier = biomeMultiplierBase;
            }

            var propLakesLabel = ls2.LabelPlusButton("AB_BiomeMultiplier".Translate(BiomeDef.Named("AB_PropaneLakes").LabelCap) + ": " + propaneLakesMultiplier,  "AB_MultiplierTooltip".Translate(BiomeDef.Named("AB_PropaneLakes").LabelCap));
            propaneLakesMultiplier = (float)Math.Round(ls2.Slider(propaneLakesMultiplier, 0.1f, 2f), 2);

            if (ls2.Settings_Button("AB_Reset".Translate(BiomeDef.Named("AB_PropaneLakes").LabelCap), new Rect(0f, propLakesLabel.position.y + 35, 250f, 29f)))
            {
                propaneLakesMultiplier = biomeMultiplierBase;
            }

            var pyroConfLabel = ls2.LabelPlusButton("AB_BiomeMultiplier".Translate(BiomeDef.Named("AB_PyroclasticConflagration").LabelCap) + ": " + pyroclasticConflagrationMultiplier,  "AB_MultiplierTooltip".Translate(BiomeDef.Named("AB_PyroclasticConflagration").LabelCap));
            pyroclasticConflagrationMultiplier = (float)Math.Round(ls2.Slider(pyroclasticConflagrationMultiplier, 0.1f, 2f), 2);

            if (ls2.Settings_Button("AB_Reset".Translate(BiomeDef.Named("AB_PyroclasticConflagration").LabelCap), new Rect(0f, pyroConfLabel.position.y + 35, 250f, 29f)))
            {
                pyroclasticConflagrationMultiplier = biomeMultiplierBase;
            }

            var tarPitsLabel = ls2.LabelPlusButton("AB_BiomeMultiplier".Translate(BiomeDef.Named("AB_TarPits").LabelCap) + ": " + tarPitsMultiplier,  "AB_MultiplierTooltip".Translate(BiomeDef.Named("AB_TarPits").LabelCap));
            tarPitsMultiplier = (float)Math.Round(ls2.Slider(tarPitsMultiplier, 0.1f, 2f), 2);

            if (ls2.Settings_Button("AB_Reset".Translate(BiomeDef.Named("AB_TarPits").LabelCap), new Rect(0f, tarPitsLabel.position.y + 35, 250f, 29f)))
            {
                tarPitsMultiplier = biomeMultiplierBase;
            }
            
            ls2.End();
            Widgets.EndScrollView();
            base.Write();

        }




    }










}
