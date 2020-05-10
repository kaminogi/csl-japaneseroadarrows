using ICities;
using UnityEngine;

namespace JapaneseRoadArrows
{
    public class LoadingExtension : LoadingExtensionBase
    {

        public override void OnLevelLoaded(LoadMode mode)
        {
            base.OnLevelLoaded(mode);
            if (mode != LoadMode.LoadGame && mode != LoadMode.NewGame && mode != LoadMode.NewGameFromScenario)
            {
                return;
            }

            var workshopID = "1568009578";
            var arrowRight         = PrefabCollection<PropInfo>.FindLoaded(workshopID + ".JP Arrow Right_Data");
            var arrowLeft          = PrefabCollection<PropInfo>.FindLoaded(workshopID + ".JP Arrow Left_Data");
            var arrowForward       = PrefabCollection<PropInfo>.FindLoaded(workshopID + ".JP Arrow Forward_Data");
            var arrowForwardLeft   = PrefabCollection<PropInfo>.FindLoaded(workshopID + ".JP Arrow Forward Left_Data");
            var arrowForwardRight  = PrefabCollection<PropInfo>.FindLoaded(workshopID + ".JP Arrow Forward Right_Data");
            var arrowLeftRight     = PrefabCollection<PropInfo>.FindLoaded(workshopID + ".JP Arrow Left Right_Data");


            if (arrowRight == null || arrowLeft == null || arrowForward == null || arrowForwardLeft == null || arrowForwardRight == null || arrowLeftRight == null)
            {
                return;
            }

            var roads = Resources.FindObjectsOfTypeAll<NetInfo>();
            foreach (var road in roads)
            {
                if (road.m_lanes == null)
                {
                    return;
                }
                foreach (var lane in road.m_lanes)
                {
                    if (lane?.m_laneProps?.m_props == null)
                    {
                        continue;
                    }
                    foreach (var laneProp in lane.m_laneProps.m_props)
                    {
                        var prop = laneProp.m_finalProp;
                        if (prop == null)
                        {
                            continue;
                        }
                        var name = prop.name;

                        if (name == "Road Arrow F")
                        {
                            laneProp.m_finalProp = arrowForward;
                            laneProp.m_prop      = arrowForward;
                            laneProp.m_angle = 0;

                        }
                        if (name == "Road Arrow R")
                        {
                            laneProp.m_finalProp = arrowRight;
                            laneProp.m_prop = arrowRight;
                            laneProp.m_angle = 0;
                        }
                        if (name == "Road Arrow L")
                        {
                            laneProp.m_finalProp = arrowLeft;
                            laneProp.m_prop = arrowLeft;
                            laneProp.m_angle = 0;
                        }
                        if (name == "Road Arrow FR")
                        {
                            laneProp.m_finalProp = arrowForwardRight;
                            laneProp.m_prop = arrowForwardRight;
                            laneProp.m_angle = 0;
                        }
                        if (name == "Road Arrow LF")
                        {
                            laneProp.m_finalProp = arrowForwardLeft;
                            laneProp.m_prop = arrowForwardLeft;
                            laneProp.m_angle = 0;
                        }
                        if (name == "Road Arrow LR")
                        {
                            laneProp.m_finalProp = arrowLeftRight;
                            laneProp.m_prop = arrowLeftRight;
                            laneProp.m_angle = 0;
                        }
                        if (name == "Road Arrow LFR")
                        {
                            laneProp.m_finalProp = null;
                            laneProp.m_prop = null;
                        }
                    }
                }
            }
        }
    }
}