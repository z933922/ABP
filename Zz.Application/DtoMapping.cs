using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Zz.DTOS;
using Model;

namespace Zz
{
    public class DtoMapping : IDtoMapping
    {
        void IDtoMapping.CreateMapping(IMapperConfigurationExpression mapperConfig)
        {
            //定义单向映射
            mapperConfig.CreateMap<ZPeopleInput, Person>();
            mapperConfig.CreateMap<ZPeopleOutput, Person>();
          //  mapperConfig.CreateMap<Person, ZPeopleOutput>();
          //mapperConfig.CreateMap<TaskDto, UpdateTaskInput>();
          //mapperConfig.CreateMap <List<ZPeopleOutput>, List <Person> >();

         
            //自定义映射
            var taskDtoMapper = mapperConfig.CreateMap<Person, ZPeopleOutput>();
              taskDtoMapper.ForMember(dto => dto.DoubleName, map => map.MapFrom(m =>m.Name+"-"));
          
        
            // Mapping types:
            //Person->ZPeopleOutput
            //Model.Person->Zz.DTOS.ZPeopleOutput
        }
    }
}
