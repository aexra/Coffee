using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Coffee.Application.Common.Mappings;
using Coffee.Domain.Models;

namespace Coffee.Application.Users.Queries.GetUserDetails;
public class UserDetailsVm : IMapWith<User>
{
    public Guid Id { get; set; }
    public string FIO { get; set; }
    public string Coffee { get; set; }
    public DateOnly BirthDate
    {
        get; set;
    }
    public DateOnly HiredSince
    {
        get; set;
    }
    public string JobTitle { get; set; }
    public string Hobbies { get; set; }
    public string Interests { get; set; }
    public string PhoneNumber { get; set; }
    public string TGID { get; set; }
    public string Pets { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, UserDetailsVm>()
            .ForMember(userVm => userVm.Id, opt => opt.MapFrom(user => user.Id))
            .ForMember(userVm => userVm.FIO, opt => opt.MapFrom(user => user.FIO))
            .ForMember(userVm => userVm.Coffee, opt => opt.MapFrom(user => user.Coffee))
            .ForMember(userVm => userVm.BirthDate, opt => opt.MapFrom(user => user.BirthDate))
            .ForMember(userVm => userVm.HiredSince, opt => opt.MapFrom(user => user.HiredSince))
            .ForMember(userVm => userVm.JobTitle, opt => opt.MapFrom(user => user.JobTitle))
            .ForMember(userVm => userVm.Hobbies, opt => opt.MapFrom(user => user.Hobbies))
            .ForMember(userVm => userVm.Interests, opt => opt.MapFrom(user => user.Interests))
            .ForMember(userVm => userVm.PhoneNumber, opt => opt.MapFrom(user => user.PhoneNumber))
            .ForMember(userVm => userVm.TGID, opt => opt.MapFrom(user => user.TGID))
            .ForMember(userVm => userVm.Pets, opt => opt.MapFrom(user => user.Pets));
    }
}
