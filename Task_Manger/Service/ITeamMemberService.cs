using Task_Manger.Models;

namespace Task_Manger.Service
{
    public interface ITeamMemberService
    {
        TeamMember? Get(int id);
        int Delete(TeamMember task);
        int Update(TeamMember task);
        List<TeamMember> GetAll();
        TeamMember Add(TeamMember task);
    }
}
