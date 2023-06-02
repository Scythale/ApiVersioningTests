using System.Collections.Generic;

namespace ApiVersioningTests.Data
{
    public class Project
    {
        public static List<Project> Projects = new List<Project> { new Project("A"), new Project("B"), new Project("C"), new Project("D"), new Project("E"), new Project("F") };
        private static int Counter = 1;
        /// <summary>
        /// Added in V1
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Added in V1
        /// </summary>
        public string Name { get; }

        ///// <summary>
        ///// Added in V2
        ///// </summary>
        //public string Description { get; }

        ///// <summary>
        ///// Added in V2
        ///// </summary>
        //public decimal Total { get; }

        public Project(string name)
        {
            Name = name;
            Id = Counter++;
        }
    }
}
