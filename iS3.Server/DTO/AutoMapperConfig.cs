using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using iS3.Server.Models.Project;
using iS3.Server.DTO.Project;
using iS3.Server.DTO.Geology;
using iS3.Server.DTO.Structure;
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