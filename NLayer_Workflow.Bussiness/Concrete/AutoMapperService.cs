using AutoMapper;
using NLayer_Workflow.Bussiness.Abstract;
using NLayer_Workflow.Bussiness.EntityMapper.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.Bussiness.Concrete
{
   public class AutoMapperService : IAutoMapperService
    {
        public IMapper Mapper
        {
            get { return ObjectMapper.Mapper; }
        }
    }
}
