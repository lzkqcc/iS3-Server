﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using iS3.Server.Models.Project;
using iS3.Server.DTO.Project;
using iS3.Server.DTO.Geology;
using iS3.Server.DTO.Structure;
using iS3.Server.DTO.Monitoring;
using IS3.Core;
using IS3.Geology;
using IS3.Structure;
using System.Text;

namespace iS3.Server.DTO
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<List<int>, string>().ConvertUsing(new ListToStringConvertert());
                config.CreateMap<string, List<int>>().ConvertUsing(new StringToListConvertert());
            });

            // For iS3 core
            // DGObject DTO
            Mapper.CreateMap<DGObject, DGObjectDTO>().ReverseMap();
            // Project DTO
            Mapper.CreateMap<Project_ProjectInfo, Project_ProjectInfoDTO>().ReverseMap();
            Mapper.CreateMap<Tree, TreeDTO>().ReverseMap();
            Mapper.CreateMap<ProjectDefinition, ProjectDefinitionDTO>().ReverseMap();
            Mapper.CreateMap<Domain, DomainDTO>().ReverseMap();
            Mapper.CreateMap<ProjectInformation, ProjectInformationDTO>().ReverseMap();
            Mapper.CreateMap<EngineeringMap, EngineeringMapDTO>().ReverseMap();
            Mapper.CreateMap<LayerDef, LayerDefDTO>().ReverseMap();
            // Geology DTO
            Mapper.CreateMap<BoreholeGeology, BoreholeGeologyDTO>().ReverseMap();
            Mapper.CreateMap<Borehole, BoreholeDTO>().ReverseMap();
            Mapper.CreateMap<StratumSection, StratumSectionDTO>().ReverseMap();
            Mapper.CreateMap<SoilDynamicProperty, SoilDynamicPropertyDTO>().ReverseMap();
            Mapper.CreateMap<SoilStaticProperty, SoilStaticPropertyDTO>().ReverseMap();
            Mapper.CreateMap<SoilProperty, SoilPropertyDTO>().ReverseMap();
            Mapper.CreateMap<Stratum, StratumDTO>().ReverseMap();
            Mapper.CreateMap<Water, WaterDTO>().ReverseMap();
            Mapper.CreateMap<RiverWater, RiverWaterDTO>().ReverseMap();
            Mapper.CreateMap<PhreaticWater, PhreaticWaterDTO>().ReverseMap();
            Mapper.CreateMap<ConfinedWater, ConfinedWaterDTO>().ReverseMap();
            Mapper.CreateMap<WaterProperty, WaterPropertyDTO>().ReverseMap();
            // Structure DTO
            Mapper.CreateMap<Pillar, PillarDTO>().ReverseMap();

            // For EF
            // Geology DTO
            Mapper.CreateMap<Geology_Boreholes, BoreholeDTO>()
                .ForMember(dest => dest.Top, opt => opt.MapFrom(src => src.TopElevation))
                .ForMember(dest => dest.Base, opt => opt.MapFrom(src => src.TopElevation - src.BoreholeLength))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.BoreholeType))
                .ReverseMap();
            Mapper.CreateMap<Geology_BoreholeStrataInfo, BoreholeGeologyDTO>()
                .ForMember(dest => dest.Base, opt => opt.MapFrom(src => src.ElevationOfStratumBottom))
                .ReverseMap();
            Mapper.CreateMap<Geology_Strata, StratumDTO>()
                .ForMember(dest => dest.GeologyAge, opt => opt.MapFrom(src => src.GeologicalAge))
                .ForMember(dest => dest.ThicknessRange, opt => opt.MapFrom(src => src.Thickness))
                .ForMember(dest => dest.ElevationRange, opt => opt.MapFrom(src => src.ElevationOfStratumBottom))
                .ReverseMap();
            Mapper.CreateMap<StratumSectionDTO, Geology_StrataSection>().ReverseMap();
            Mapper.CreateMap<SoilPropertyDTO, Geology_SoilProperties>().ReverseMap();
            Mapper.CreateMap<SoilStaticPropertyDTO, Geology_SoilProperties>().ReverseMap();
            Mapper.CreateMap<SoilDynamicPropertyDTO, Geology_SoilProperties>().ReverseMap();
            Mapper.CreateMap<PhreaticWaterDTO, Geology_PhreaticWater>().ReverseMap();
            Mapper.CreateMap<ConfinedWaterDTO, Geology_ConfinedWater>().ReverseMap();
            Mapper.CreateMap<WaterPropertyDTO, Geology_WaterProperties>().ReverseMap();
            Mapper.CreateMap<MonPointDTO, Monitoring_MonPointInfo>().ReverseMap();
            Mapper.CreateMap<MonGroupDTO, Monitoring_MonGroupInfo>().ReverseMap();
            Mapper.CreateMap<MonProjectDTO, Monitoring_MonProjectInfo>().ReverseMap();
            Mapper.CreateMap<MonPointDataDTO, Monitoring_MonData>().ReverseMap();
        }

        class ListToStringConvertert : ITypeConverter<List<int>, string>
        {  
            public string Convert(ResolutionContext context)
            {
                List<int> source = context.SourceValue as List<int>;
                string destination;
                if (source == null || source.Count() == 0)
                {
                    destination = "";
                    return destination;
                }

                StringBuilder sb = new StringBuilder();
                sb.Append(source[0]);
                for (int i = 1; i < source.Count(); i++)
                {
                    sb.Append(",");
                    sb.Append(source[i]);
                }
                destination = sb.ToString();
                return destination;
            }
        }

        class StringToListConvertert : ITypeConverter<string, List<int>>
        {
            public List<int> Convert(ResolutionContext context)
            {
                string source = context.SourceValue as string;
                List<int> destination;

                if (source == null || source.Count() == 0)
                {
                    destination = null;
                    return destination;
                }

                destination = new List<int>();
                string[] ss = source.Split(',');
                foreach (string s in ss)
                    destination.Add(System.Convert.ToInt32(s));
                return destination;
            }
        }
    }

    
}