using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tatoo_SaiGon.EntityTatoo;
using Tatoo_SaiGon.Model;

namespace Tatoo_SaiGon.Member
{
    public class MemberService : IMemberService
    {
        private TattooSaigonContext _context;
        private IMapper _mapper;

        public MemberService(TattooSaigonContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task RegisterMember(int userID, MemberRegister member)
        {
            var user = _context.TblMembers.FirstOrDefaultAsync(x => x.UserId == userID);
            if (user == null) throw new Exception("No member");
            var mapper = _mapper.Map<TblMember>(member);
            _context.TblMembers.Add(mapper);
            _context.SaveChangesAsync();           
        }
    }
}
