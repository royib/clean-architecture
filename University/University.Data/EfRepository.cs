﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Data;
using University.Core.Data;
using University.Core.Domain;
using System.Data.Entity;

namespace University.Data
{
    public partial class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        private IDbSet<T> _entities;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public EfRepository(DbContext context)
        {
            this._context = context;
        }

        public T GetById(object id)
        {
            return this.Entities.Find(id);
        }

        public void Insert(T entity)
        {
            // try
            //  {
            if (entity == null)
                throw new ArgumentNullException("entity");

            this.Entities.Add(entity);

            this._context.SaveChanges();
            //   }
            //catch (DbEntityValidationException dbEx)
            //{
            //    var msg = string.Empty;

            //    foreach (var validationErrors in dbEx.EntityValidationErrors)
            //        foreach (var validationError in validationErrors.ValidationErrors)
            //            msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;

            //    var fail = new Exception(msg, dbEx);
            //    //Debug.WriteLine(fail.Message, fail);
            //    throw fail;
            //}
        }

        public void Update(T entity)
        {
            // try
            // {
            if (entity == null)
                throw new ArgumentNullException("entity");

            this._context.Entry(entity).State = EntityState.Modified;
            this._context.SaveChanges();
            // }
            //catch (DbEntityValidationException dbEx)
            //{
            //    var msg = string.Empty;

            //    foreach (var validationErrors in dbEx.EntityValidationErrors)
            //        foreach (var validationError in validationErrors.ValidationErrors)
            //            msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

            //    var fail = new Exception(msg, dbEx);
            //    //Debug.WriteLine(fail.Message, fail);
            //    throw fail;
            //}
        }

        public void Delete(T entity)
        {
            // try
            // {
            if (entity == null)
                throw new ArgumentNullException("entity");

            this.Entities.Remove(entity);

            this._context.SaveChanges();
            //}
            //catch (DbEntityValidationException dbEx)
            //{
            //    var msg = string.Empty;

            //    foreach (var validationErrors in dbEx.EntityValidationErrors)
            //        foreach (var validationError in validationErrors.ValidationErrors)
            //            msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

            //    var fail = new Exception(msg, dbEx);
            //    //Debug.WriteLine(fail.Message, fail);
            //    throw fail;
            //}
        }

        public virtual IQueryable<T> Table
        {
            get
            {

                return this.Entities;
            }
        }

        private IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }
    }
}

