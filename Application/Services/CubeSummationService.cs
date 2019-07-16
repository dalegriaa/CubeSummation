using Application.Contracts;
using Application.Dto;
using Application.Helpers;
using Application.Mapper;
using Domain.Entities;
using Domain.Repositories;
using System.Collections.Generic;


namespace Application.Services
{
    public class CubeSummationService : ICubeSummationService
    {
        private readonly ITextDataSourceRepository textDataSourceRepository;

        public CubeSummationService(ITextDataSourceRepository textDataSourceRepository)
        {
            this.textDataSourceRepository = textDataSourceRepository;
        }
        public List<InputLineDto> GetOutput(string routeArchive)
        {
            List<Cube> listCube = new List<Cube>();
            var inputList = textDataSourceRepository.GetListInputLine(routeArchive);
            Cube inputLine = ListLineToObjList.ListLineToObjListMap(inputList);
            // get cube summation from helper
            List<long> sumList = CubeSummationHelper.CubeSummation(inputLine);
            var listDtoSum = EntityListToDtoList.EntityListToDtoListInput(sumList);

            return listDtoSum;
        }
    }
}
