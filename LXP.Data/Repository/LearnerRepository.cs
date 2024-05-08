using LXP.Common;
using LXP.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LXP.Common.ViewModels;

namespace LXP.Data.Repository
{
    public class LearnerRepository : ILearnerRepository
    {
        private readonly LXPDbContext _LXPDbContext;
        public LearnerRepository (LXPDbContext lXPDbContext)
        {
            _LXPDbContext = lXPDbContext;
        }
        public void CreateUser(LearnerDTO learnerDTO)
        {
            try
            {
                var userExists = _LXPDbContext.Learners.Any(t => t.LearnerId == learnerDTO.LearnerId);
                if (userExists)
                {
                    throw new Exception("Invalid learner ID provided.");
                }
            }
            catch (Exception ex)
            {
                throw;
                Console.WriteLine($"Error Creating learner: {ex.Message}");
                throw new Exception("Invalid learner ID provided.");
            }

            //var learnerEntity = new LearnerDTO
            //{
            //    LearnerId = learnerDTO.LearnerId,
            //    Email = learnerDTO.Email,
            //    Password = learnerDTO.Password,
            //    Role = learnerDTO.Role,
            //    UnblockRequest = learnerDTO.UnblockRequest,
            //    AccountStatus = learnerDTO.AccountStatus,
            //    UserLastLogin = learnerDTO.UserLastLogin,
            //    CreatedBy = learnerDTO.CreatedBy,
            //    CreatedAt = learnerDTO.CreatedAt
            //};
            //_LXPDbContext.Learners.Add(learnerEntity);
            //_LXPDbContext.SaveChanges();
        }

        public IEnumerable<LearnerDTO> GetAll()
        {
            return _LXPDbContext.Learners
                .Select(t => new LearnerDTO
                {
                    LearnerId = t.LearnerId,
                    Email = t.Email,
                })
                .ToList();
        }

        public LearnerDTO GetByLearnerID(Guid learnerID)
        {
            throw new NotImplementedException();
        }
    }
}
