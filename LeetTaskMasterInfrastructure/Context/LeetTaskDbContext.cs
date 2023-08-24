using Microsoft.EntityFrameworkCore;
using LeetTaskMaster.Domain.Entities;
using LeetTaskMasterInfrastructure.Interface;
using System.Threading.Tasks;


namespace LeetTaskMasterInfrastructure.Context
{
    public class LeetTaskDbContext : DbContext, IDataContext<LeetTask>
    {
        public DbSet<LeetTask> LeetTasks { get; set; }
        private readonly IConfiguration _configuration;

        public LeetTaskDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //for configuration sql connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));

        }
        #region Realization IDataContext
        public async Task AddAsync(LeetTask item)
        {
            await LeetTasks.AddAsync(item);
        }

        public void Delete(int id)
        {
            var task = LeetTasks.Find(id);
            if (task != null)
                LeetTasks.Remove(task);
        }

        public LeetTask Get(int id)
        {
            var task = LeetTasks.SingleOrDefault(t => t.Id == id);
            if (task == null)
            {
                // Можно выбросить исключение или выполнить другие действия по обработке
                throw new InvalidOperationException("Task not found.");
            }
            return task;
        }

        public IEnumerable<LeetTask> GetAll()
        {
            return LeetTasks.OrderBy(t => t.Id);
        }

        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        public async Task Update(LeetTask item)
        {
            var existingTask = await LeetTasks.FindAsync(item.Id);
            if (existingTask != null)
            {
                // Производим обновление полей существующей задачи
                Entry(existingTask).CurrentValues.SetValues(item);

            }
        }
        #endregion

    }
}
