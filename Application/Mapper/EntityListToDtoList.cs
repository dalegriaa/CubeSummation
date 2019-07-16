using Application.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Mapper
{
   public static class EntityListToDtoList 
    {
        public static List<InputLineDto> EntityListToDtoListInput(List<long> listInputLine)
        {
            List<InputLineDto> listInputLineDto = new List<InputLineDto>();
            foreach (var inputLineString in listInputLine)
            {
                listInputLineDto.Add(new InputLineDto()
                {
                    InputLine = inputLineString
                });
            }
            return listInputLineDto;
        }
    }
}
