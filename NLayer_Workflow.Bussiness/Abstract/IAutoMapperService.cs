using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.Bussiness.Abstract
{
    public interface IAutoMapperService
    {
        IMapper Mapper { get; }
    }
}
