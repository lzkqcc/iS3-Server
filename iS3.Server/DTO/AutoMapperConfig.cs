using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using iS3.Server.Models.Project;
using iS3.Server.DTO.Project;
using IS3.Core;
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

            // Class
            Mapper.CreateMap<Project_ProjectInfo, Project_ProjectInfoDTO>().ReverseMap();
            Mapper.CreateMap<Tree, TreeDTO>().ReverseMap();
            Mapper.CreateMap<ProjectDefinition, ProjectDefinitionDTO>().ReverseMap();
            Mapper.CreateMap<Domain, DomainDTO>().ReverseMap();
            Mapper.CreateMap<ProjectInformation, ProjectInformationDTO>().ReverseMap();
            Mapper.CreateMap<EngineeringMap, EngineeringMapDTO>().ReverseMap();
            Mapper.CreateMap<LayerDef, LayerDefDTO>().ReverseMap();

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