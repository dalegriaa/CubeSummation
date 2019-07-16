using Application.Dto;
using System.Collections.Generic;

namespace Application.Contracts
{
    public interface ICubeSummationService
    {
        List<InputLineDto> GetOutput(string routeArchive);
    }
}
