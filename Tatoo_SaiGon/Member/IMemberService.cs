using Tatoo_SaiGon.Model;

namespace Tatoo_SaiGon.Member
{
    public interface IMemberService
    {
        public Task RegisterMember(int userID, MemberRegister member);
    }
}
