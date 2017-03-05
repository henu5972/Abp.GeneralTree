﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.TestBase;
using EntityFramework.DynamicFilters;
using System.Data.Entity;
using Abp;
using Abp.Configuration.Startup;
using Abp.Domain.Uow;
using Abp.Runtime.Session;
using Castle.MicroKernel.Registration;
using Effort;

namespace TreeTests
{
    public class TreeTestBase : AbpIntegratedTestBase<TreeTestModule>
    {
        protected TreeTestBase()
        {
            //Seed initial data
            UsingDbContext(context => new TreeTestInitialDataBuilder().Build(context));
        }

        protected override void PreInitialize()
        {
            //Fake DbConnection using Effort!
            LocalIocManager.IocContainer.Register(
                Component.For<DbConnection>()
                    .UsingFactoryMethod(Effort.DbConnectionFactory.CreateTransient)
                    .LifestyleSingleton()
                );

            base.PreInitialize();
        }

        public void UsingDbContext(Action<TreeTestDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<TreeTestDbContext>())
            {
                context.DisableAllFilters();
                action(context);
                context.SaveChanges();
            }
        }

        public T UsingDbContext<T>(Func<TreeTestDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<TreeTestDbContext>())
            {
                context.DisableAllFilters();
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
