using System.Web.Http;
using System.Web.Mvc;
using StructureMap;
using University.DependencyResolution;
using AutoMapper;

[assembly: WebActivator.PreApplicationStartMethod(typeof(University.App_Start.AutoMapperConfig), "Start")]
namespace University.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Start()
        {
            Mapper.CreateMap<University.Core.Domain.Student, University.Core.Domain.studentIndex>();
        }
    }
}