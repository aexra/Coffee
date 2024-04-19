using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Coffee.Application.Users.Commands.UpdateUser;
public class UpdateUserCommand : IRequest
{
    public Guid Id
    {
        get; set; 
    }
    public string FIO
    {
        get; set;
    }
    public string Coffee
    {
        get; set;
    }
    public DateOnly BirthDate
    {
        get; set;
    }
    public DateOnly HiredSince
    {
        get; set;
    }
    public string JobTitle
    {
        get; set;
    }
    public string Hobbies
    {
        get; set;
    }
    public string Interests
    {
        get; set;
    }
    public string PhoneNumber
    {
        get; set;
    }
    public string TGID
    {
        get; set;
    }
    public string Pets
    {
        get; set;
    }
}
