﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeTests
{
    public class TreeTestInitialDataBuilder
    {
        public void Build(TreeTestDbContext context)
        {
            //Add some people            
            /*
            context.People.AddOrUpdate(
                p => p.Name,
                new Person { Name = "Isaac Asimov" },
                new Person { Name = "Thomas More" },
                new Person { Name = "George Orwell" },
                new Person { Name = "Douglas Adams" }
                );
            context.SaveChanges();

            //Add some tasks
            context.Tasks.AddOrUpdate(
                t => t.Description,
                new Task
                {
                    Description = "my initial task 1"
                },
                new Task
                {
                    Description = "my initial task 2",
                    State = TaskState.Completed
                },
                new Task
                {
                    Description = "my initial task 3",
                    AssignedPerson = context.People.Single(p => p.Name == "Douglas Adams")
                },
                new Task
                {
                    Description = "my initial task 4",
                    AssignedPerson = context.People.Single(p => p.Name == "Isaac Asimov"),
                    State = TaskState.Completed
                });
            context.SaveChanges();
            */
        }
    }
}
