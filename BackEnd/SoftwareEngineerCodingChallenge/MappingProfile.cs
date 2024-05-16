using AutoMapper;
using SoftwareEngineerCodingChallenge.CQRS.Customers.ViewModel;
using SoftwareEngineerCodingChallenge.Models;

namespace SoftwareEngineerCodingChallenge
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>()
                .ForMember(a => a.Id, b => b.MapFrom(c => c.Id))
                .ForMember(a => a.FirstName, b => b.MapFrom(c => c.FirstName))
                .ForMember(a => a.LastName, b => b.MapFrom(c => c.LastName))
                .ForMember(a => a.Email, b => b.MapFrom(c => c.Email))
                .ForMember(a => a.CreatedDateTime, b => b.MapFrom(c => c.CreatedDateTime))
                .ForMember(a => a.LastUpdatedDateTime, b => b.MapFrom(c => c.LastUpdatedDateTime));
        }
    }   
}
