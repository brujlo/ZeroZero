
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleaningSolution.Model
{
    public interface ICleaningPlan
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public int customerId { get; set; }
        public DateTime createdAt { get; set; }
        public string description { get; set; }

        Task<IEnumerable<CleaningPlan_Impl>> Get_All();
        Task<IEnumerable<CleaningPlan_Impl>> Get_By_cId(int CustomerID);
        Task<CleaningPlan_Impl> Get_By_Guid(Guid guid);
        Task<CleaningPlan_Impl> Add(CleaningPlan_Impl cp);
        Task<CleaningPlan_Impl> Update_By_Id(Guid guid, CleaningPlan_Impl cp);
        Task<IEnumerable<CleaningPlan_Impl>> Delete_By_ID(int CustomerID);
    }
}
