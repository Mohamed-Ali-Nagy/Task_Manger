using Task_Manger.Models;

namespace Task_Manger.Service
{
    public class TeamMemberService : ITeamMemberService
    {
        private readonly TaskMangerContext _context;
        public TeamMemberService(TaskMangerContext context)
        {
            _context = context;
        }
        public TeamMember Add(TeamMember task)
        {
            _context.TeamMembers.Add(task);
            _context.SaveChanges();
            return task;
        }

        public int Delete(TeamMember task)
        {
            _context.Remove(task);
           return _context.SaveChanges();
        }

        public TeamMember? Get(int id)
        {
           return _context.TeamMembers.FirstOrDefault(t=>t.MemberId == id);
        }

        public List<TeamMember> GetAll()
        {
            return _context.TeamMembers.ToList();
        }

        public int Update(TeamMember task)
        {
            _context.TeamMembers.Update(task);
           return _context.SaveChanges();
        }
    }
}
