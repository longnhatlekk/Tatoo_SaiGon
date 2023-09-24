using AutoMapper;
using Tatoo_SaiGon.EntityTatoo;
using Tatoo_SaiGon.Model;

namespace Tatoo_SaiGon.Mapping
{
    public class Mapper : Profile
    {
        public Mapper() {
            CreateMap<TblUser, UserRegister>().ReverseMap();
            CreateMap<TblMember, MemberRegister>().ReverseMap();
            
        }
    }
}
