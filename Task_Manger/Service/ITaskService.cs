using Task_Manger.Models;

namespace Task_Manger.Service
{
    public interface ITaskService
    {
        ProjectTask? Get(int id);
        int Delete(ProjectTask task);
        int Update(ProjectTask task);
        List<ProjectTask> GetAll();
        ProjectTask Add(ProjectTask task);
        

    }
}
