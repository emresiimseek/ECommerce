﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.FrameworkCore.Utilities.Mappings
{
    public class AutoMapperBase : IAutoMapper
    {
        public List<TDest> MapToSameList<TSource, TDest>(List<TSource> list) where TSource : new()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDest>());
            IMapper mapper = config.CreateMapper();
            return mapper.Map<List<TSource>, List<TDest>>(list);
            ;
        }

        public TDest MapToSameTpe<TSource, TDest>(TSource obj) where TSource : new()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDest>());
            IMapper mapper = config.CreateMapper();
            return mapper.Map<TSource, TDest>(obj);
        }
    }
}
