using AutoMapper;
using HVKTQS.Model.Models;
using HVKTQS.UI.Models;

namespace HVKTQS.UI.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Department, DepartmentViewModel>();
                cfg.CreateMap<Position, PositionViewModel>();
                cfg.CreateMap<Subject, SubjectViewModel>();
            });
        }
    }
}