using System;
using System.Collections;
using System.Collections.Generic;

namespace Forum.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<int> PostIds { get; set; }

        public Category(int id, string name, ICollection<int> postIds)
        {
            Id = id;
            Name = name;
            PostIds = new List<int>(postIds);
        }
    }
}
