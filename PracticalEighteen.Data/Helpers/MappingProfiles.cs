using AutoMapper;
using PracticalEighteen.Domain.DTO;
using PracticalEighteen.Domain.Models;

namespace PracticalEighteen.Data.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Student, StudentModel>().ReverseMap();
        }
    }
}
