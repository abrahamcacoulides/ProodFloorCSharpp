﻿using ProdFloor.Models.ViewModels;
using ProdFloor.Models.ViewModels.Job;
using System.Linq;

namespace ProdFloor.Models
{
    public interface IJobRepository
    {
        IQueryable<Job> Jobs { get; }
        IQueryable<JobExtension> JobsExtensions { get; }
        IQueryable<HydroSpecific> HydroSpecifics { get; }
        IQueryable<GenericFeatures> GenericFeaturesList { get; }
        IQueryable<Indicator> Indicators { get; }
        IQueryable<HoistWayData> HoistWayDatas { get; }
        IQueryable<SpecialFeatures> SpecialFeatures { get; }
        IQueryable<PO> POs { get; }
        IQueryable<CustomSoftware> CustomSoftwares { get;}
        IQueryable<TriggeringCustSoft> TriggeringCustSofts { get;}
        IQueryable<CustomFeature> CustomFeatures { get;}
        IQueryable<Element> Elements { get; }
        IQueryable<ElementHydro> ElementHydros { get; }
        IQueryable<ElementTraction> ElementTractions { get; }
        IQueryable<JobAdditional> JobAdditionals { get;}
        IQueryable<StatusPO> StatusPOs { get;}
        IQueryable<M3000> M3000s { get;}
        IQueryable<MotorInfo> MotorInfos { get;}
        IQueryable<OperatingFeatures> OperatingFeatures { get;}

        void SaveJob(Job job);
        void SaveJobExtension(JobExtension jobExtension);
        void SaveHydroSpecific(HydroSpecific hydroSpecific);
        void SaveGenericFeatures(GenericFeatures genericFeatures);
        void SaveIndicator(Indicator indicator);
        void SaveHoistWayData(HoistWayData hoistWayData);
        void SaveSpecialFeatures(SpecialFeatures specialFeatures);
        void SavePO(PO po);
        void SaveStatusPO(StatusPO statusPO);
        void SaveJobAdditional(JobAdditional jobAdditional);
        void SaveEngJobView(JobViewModel viewModelToSave);
        void SaveCustomSoftware(CustomSoftware customSoftware);
        void SaveTriggeringCustSoft(TriggeringCustSoft triggeringCustSoft);
        void SaveCustomFeature(CustomFeature customFeature);
        void SaveJobCustomSoftware(CustomSoftwareViewModel viewModel);
        void SaveElement(Element element);
        void SaveElementHydro(ElementHydro elementHydro);
        void SaveElementTraction(ElementTraction elementTraction);
        void SaveEngElementHydroJobView(JobElementHydroViewModel viewModelToSave);
        void SaveEngElementTractionJobView(JobElementTractionViewModel viewModelToSave);
        void SaveEngM3000JobView(JobM3000ViewModel viewModelToSave);
        void SaveM3000(M3000 m3000);
        void SaveMotorInfo(MotorInfo motor);
        void SaveOperatingFeatures(OperatingFeatures feature);


        Job DeleteJob(int jobID);
        Job DeleteEngJob(int JobID);
        Job DeleteEngElementHydroJob(int JobID);
        Job DeleteEngElementTractionJob(int JobID);
        Job DeleteEngM3000Job(int JobID);
        JobExtension DeleteJobExtension(int jobExtensionID);
        HydroSpecific DeleteHydroSpecific(int hydroSpecificID);
        GenericFeatures DeleteGenericFeatures(int genericFeaturesID);
        Indicator DeleteIndicator(int indicatorID);
        HoistWayData DeleteHoistWayData(int hoistWatDataID);
        SpecialFeatures DeleteSpecialFeatures(int specialFeaturesID);
        PO DeletePO(int POID);
        StatusPO DeleteStatusPO(int StatusPOID);
        JobAdditional DeleteJobAdditional(int JobAdditionalID);
        CustomSoftware DeleteCustomSoftware(int CustomSoftwareID);
        TriggeringCustSoft DeleteTriggeringCustSoft(int TriggeringCustSoftID);
        CustomFeature DeleteCustomFeature(int CustomFeatureID);
        CustomSoftware DeleteJobCustomSoftware(int CustomSoftwareID);
        Element DeleteElement(int ElementID);
        ElementHydro DeleteElementHydro(int ElementHydroID);
        ElementTraction DeleteElementTraction(int ElementTractionID);
        M3000 DeleteM3000(int M3000ID);
        MotorInfo DeleteMotorInfo(int MotorInfoID);
        OperatingFeatures DeleteOperatingFeatures(int OperatingFeaturesID);
    }
}
