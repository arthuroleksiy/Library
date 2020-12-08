using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Repositories
{
    /// <summary>
    /// Repository for form data
    /// </summary>
    public class FormRepository: IFormRepository
    {
        /// <summary>
        /// Context property
        /// </summary>
        private LibraryDbContext db;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="context">Context argument</param>
        public FormRepository(LibraryDbContext context)
        {
            this.db = context;
        }

        /// <summary>
        /// Get all questionnary results from context
        /// </summary>
        /// <returns>Questionnary results</returns>
        public IEnumerable<FormModel> GetAllForms()
        {
            return db.FormModels;
        }
        /// <summary>
        /// Add results of input questionnay to context
        /// </summary>
        /// <param name="form">Input questionnary result</param>
        public void AddForm(FormModel form)
        {
            
            this.db.FormModels.Add(form);
        }
        /// <summary>
        /// Get last index
        /// </summary>
        /// <returns>Last form id</returns>
        public int GetLastForm()
        {
            return db.FormModels.OrderByDescending(o => o.FormModelId).FirstOrDefault().FormModelId;
        }


    }
}