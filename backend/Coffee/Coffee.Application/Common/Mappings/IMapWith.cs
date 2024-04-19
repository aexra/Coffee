﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Coffee.Application.Common.Mappings;
public interface IMapWith<T>
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}
